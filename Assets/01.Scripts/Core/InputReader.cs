using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader", fileName = "PlayerInput")]
public class InputReader : ScriptableObject, Controls.IPlayerActions
{
    public Action UpEvent;
    public Action DownEvent;
    public Action SkillEvent;
    
    private Controls _controls;

    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }

        _controls.Player.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() == Vector2.up)
            UpEvent?.Invoke();
        if (context.ReadValue<Vector2>() == Vector2.down)
            DownEvent?.Invoke();
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
            SkillEvent?.Invoke();
    }
}
