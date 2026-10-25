using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D m_RB;
    [SerializeField] float m_moveSpeed;
    [SerializeField] float m_jumpStrength;
    Vector2 m_dir;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    public void Handle_MoveInput(InputAction.CallbackContext ctx)
    {
        m_dir.x = ctx.ReadValue<Vector2>().x;
        m_RB.linearVelocity = m_dir * m_moveSpeed;
    }

    public void Handle_MoveCancel()
    {
        m_dir = Vector2.zero;
        m_RB.linearVelocity = Vector2.zero;
    }

    public void Handle_JumpInput()
    {
        m_RB.AddForceY(m_jumpStrength, ForceMode2D.Impulse);
    }

    public void Handle_JumpCancel()
    {

    }
}