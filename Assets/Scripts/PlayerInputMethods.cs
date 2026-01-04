using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMethods: MonoBehaviour
{
    public static event Action<InputType, Vector2> OnInputPerformed;

    public void OnMove1(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var inputPosition = context.ReadValue<Vector2>();
        OnInputPerformed?.Invoke(InputType.LeftClick, inputPosition);
    }
    
    public void OnMove2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var inputPosition = context.ReadValue<Vector2>();
        OnInputPerformed?.Invoke(InputType.RightClick, inputPosition);
    }
}

public enum InputType
{
    RightClick,
    LeftClick,
}
