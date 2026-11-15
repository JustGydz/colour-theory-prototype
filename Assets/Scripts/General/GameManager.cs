using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{

	public  List<string> doorSequence;
	private GameObject m_player;
	private GameObject m_EndPanel;
	private TextMeshProUGUI m_EndSequenceText;

	private string m_Sequence = "";


	void Awake()
	{
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		m_EndPanel = GameObject.Find("EndScreen");
		m_EndSequenceText = GameObject.Find("SequenceText").GetComponent<TextMeshProUGUI>();
		m_EndPanel.SetActive(false);
		CheckCount();
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void ChangeDoorSequence(string name)
	{
		if (doorSequence.Count < 5)
		{
			doorSequence.Add(name);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			m_Sequence += " " + name+ ",";
		}
		CheckCount();
	}

	private void CheckCount()
	{
		if (doorSequence.Count == 5)
		{
			DisablePlayer();
			EndSimulationSequence();
		}
	}

	void DisablePlayer()
	{
		m_player = GameObject.Find("Player");
		Destroy(m_player);
	}

	private void EndSimulationSequence()
	{
		m_EndPanel.SetActive(true);
		m_EndSequenceText.text += m_Sequence;
	}

}
