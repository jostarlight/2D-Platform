using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerInAirState
{
    public PlayerFallState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.rigidbody2D.velocity.y > 0)
        {
            stateMachine.ChangeState(player.playerUpState);
        }

        var canUseCoyote = player.playerInputHandler.coyoteUsable && Time.time < startTime + playerData.CoyoteTime;

        if (player.playerInputHandler.jumpInput && canUseCoyote)
        {
            player.playerInputHandler.UseJumpInput();
            stateMachine.ChangeState(player.playerJumpState);
        }
    }
}
