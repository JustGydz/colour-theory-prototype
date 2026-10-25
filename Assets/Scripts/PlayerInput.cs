using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputSystem_Actions m_inputActions;
    [SerializeField] public CharacterController m_characterController;

    private void Awake()
    {
        m_inputActions = new InputSystem_Actions();
        Debug.Log("Map generated");
    }

    private void OnEnable()
    {
        m_inputActions.Enable();
        m_inputActions.Player.Move.performed += HandleMovePerformed;
        m_inputActions.Player.Move.canceled += HandleMoveCancelled;
        m_inputActions.Player.Jump.performed += HandleJumpPerformed;
        m_inputActions.Player.Jump.canceled += HandleJumpCancelled;

    }
    private void OnDisable()
    {
        m_inputActions.Disable();
        m_inputActions.Player.Move.performed -= HandleMovePerformed;
        m_inputActions.Player.Move.canceled -= HandleMoveCancelled;
        m_inputActions.Player.Jump.performed -= HandleJumpPerformed;
        m_inputActions.Player.Jump.canceled -= HandleJumpCancelled;
    }

    private void HandleMoveCancelled(InputAction.CallbackContext context)
    {
        m_characterController.Handle_MoveCancel();
    }

    public void HandleMovePerformed(InputAction.CallbackContext ctx)
    {
        m_characterController.Handle_MoveInput(ctx);
    }

    public void HandleJumpPerformed(InputAction.CallbackContext ctx)
    {
        m_characterController.Handle_JumpInput();
    }

    public void HandleJumpCancelled(InputAction.CallbackContext context)
    {
        m_characterController.Handle_JumpCancel();
    }
}