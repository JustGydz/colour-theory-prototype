using System.Collections;
using UnityEngine;

public class RestingSpot : MonoBehaviour
{
	[SerializeField] GameObject m_confirmScreen;
	[SerializeField] GameObject m_restScreen;

	 private bool m_confirmRejected;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		m_confirmScreen.SetActive(false);
		m_restScreen.SetActive(false);
		m_confirmRejected = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !m_confirmRejected)
		{
			m_confirmScreen.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			m_confirmScreen.SetActive(false);
		}
	}

	public void ShowRestPanel()
	{
		m_confirmScreen.SetActive(false);
		m_restScreen.SetActive(true);
	}
	public void HidePanel()
	{
		m_confirmRejected = true;
		m_confirmScreen.SetActive(false);
		StartCoroutine("ResetConfirm");
	}

	IEnumerator ResetConfirm()
	{
		yield return new WaitForSeconds(1.0f);
		m_confirmRejected = false;
	}
}
