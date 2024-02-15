using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // player.AddForce(playerData.jumpVelocity);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityY(playerData.jumpForce);

        stateMachine.ChangeState(player.playerUpState);
        // if (isGrounded)
        // {

        //     // var tmp = player.rigidbody2D.velocity.y + playerData.jumpForce;


        // }
        // else
        // {

        // }


        // if (isGrounded && player.rigidbody2D.velocity.y < 0.01f)
        // {
        //     stateMachine.ChangeState(player.playerIdleState);
        // }
        // else
        // {
        //     if (player.rigidbody2D.velocity.y > 0)
        //     {

        //     }
        //     else if (player.rigidbody2D.velocity.y < 0)
        //     {
        //         stateMachine.ChangeState(player.playerFallState);
        //     }

        // }
    }
}
