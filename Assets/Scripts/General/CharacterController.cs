using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D m_RB;
    public SpriteRenderer m_PlayerSprite;
    [SerializeField] float m_moveSpeed;
    [SerializeField] float m_jumpStrength;
	[SerializeField] GameManager m_GameManager;
	[SerializeField] Vector3 m_Spawn;
	private Animator m_Animator;

	bool hasSentData = false;
    Vector2 m_dir;

    private void Awake()
    {
		m_GameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>(); // Auto Find
        m_RB = GetComponent<Rigidbody2D>();
		m_Animator = GetComponent<Animator>();
		m_Animator.SetBool("IsResting", false);
    }

    public void Handle_MoveInput(InputAction.CallbackContext ctx)
    {
        m_dir.x = ctx.ReadValue<Vector2>().x;
        m_RB.linearVelocity = m_dir * m_moveSpeed;
		m_PlayerSprite.flipX = (m_dir.x < 0.0f);
		m_Animator.SetFloat("Speed",Mathf.Abs( m_RB.linearVelocityX));
    }

    public void Handle_MoveCancel()
    {
        m_dir = Vector2.zero;
        m_RB.linearVelocity = Vector2.zero;
		m_Animator.SetFloat("Speed",Mathf.Abs( m_RB.linearVelocityX));
    }

	public void RestCharacter()
	{
		m_Animator.SetBool("IsResting",true);
		Destroy(this.m_RB);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if (m_GameManager != null)
		//{
		//	if (!hasSentData && collision.gameObject.CompareTag("Door") == true)
		//	{
		//		gameObject.transform.position = m_Spawn;
		//		m_GameManager.ChangeDoorSequence(collision.gameObject.name);
		//		hasSentData = true;
		//		Destroy(collision.gameObject);
		//	}
		//}
	}
}