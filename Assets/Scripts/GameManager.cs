using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public  List<string> doorSequence;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	//void Start()
	//   {

	//   }

	// Update is called once per frame
	void Update()
	{
		Debug.Log(" ");
	}

	public void ChangeDoorSequence(string name)
	{
		if (doorSequence.Count < 5)
		{
			doorSequence.Add(name);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
