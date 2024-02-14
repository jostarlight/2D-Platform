using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput;
    internal bool jumpInput;
    internal bool jumpPress;

    public bool endedJumpEarly = false;
    public bool bufferedJumpUsable = false;
    public bool coyoteUsable = false;

    public float timeJumpWasPressed;


    public void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    public void OnJumpInput(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            jumpInput = true;

        }

        jumpPress = context.performed;

    }

    public void UseJumpInput()
    {
        jumpInput = false;
        timeJumpWasPressed = 0;
        bufferedJumpUsable = false;
        coyoteUsable = false;
    }
}
