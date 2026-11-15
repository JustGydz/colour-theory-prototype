using TMPro;
using UnityEngine;

public class DialogueActor : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_textBox;
	[SerializeField] string m_dialogue;

	private void Start()
	{
		m_textBox.text = m_dialogue;
		m_textBox.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			m_textBox.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			m_textBox.gameObject.SetActive(false);
		}
	}
}
