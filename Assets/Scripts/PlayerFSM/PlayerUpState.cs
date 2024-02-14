using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpState : PlayerInAirState
{
    public PlayerUpState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.rigidbody2D.velocity.y < 0)
        {
            stateMachine.ChangeState(player.playerFallState);
        }
    }
}
