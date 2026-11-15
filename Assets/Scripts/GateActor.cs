using System.Collections;
using Unity.Android.Types;
using UnityEngine;

public class GateActor : MonoBehaviour
{
	[SerializeField] int m_destination;
	[SerializeField] GameObject m_confirmScreen;

	private bool m_confirmRejected;

	private void Start()
	{
		m_confirmScreen.SetActive(false);
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

	public void SwitchScene()
	{
		switch (m_destination)
		{
			default:
				break;
			case 4:
				FindFirstObjectByType<SceneNavigation>().LoadWorldsHubScene();
				break;
			case 5:
				FindFirstObjectByType<SceneNavigation>().LoadRedRestScene();
				break;
			case 6:
				FindFirstObjectByType<SceneNavigation>().LoadGreenRestScene();
				break;
			case 7:
				FindFirstObjectByType<SceneNavigation>().LoadBlueRestScene();
				break;
		}
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
