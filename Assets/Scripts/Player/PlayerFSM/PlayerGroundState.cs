using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 input;
    protected int normalInputX;
    protected bool jumpPress;


    protected bool isGrounded;

    public PlayerGroundState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckIfTouchGround();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jumpPress = player.playerInputHandler.jumpPress;
        input = player.playerInputHandler.movementInput;
        normalInputX = player.playerInputHandler.normalInputX;

        if (!isGrounded)
        {

            if (player.rigidbody2D.velocity.y > 0)
            {

                stateMachine.ChangeState(player.playerUpState);
            }
            else if (player.rigidbody2D.velocity.y < 0)
            {
                stateMachine.ChangeState(player.playerFallState);
            }
        }
        else
        {
            var HasBufferedJump = player.playerInputHandler.bufferedJumpUsable && Time.time < player.playerInputHandler.timeJumpWasPressed + playerData.JumpBuffer;
            if (player.playerInputHandler.jumpInput || HasBufferedJump)
            {
                player.playerInputHandler.UseJumpInput();
                stateMachine.ChangeState(player.playerJumpState);
            }


        }

    }
}


