using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // player.SetVelocityX(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (stateMachine.currentState != player.playerIdleState)
        {
            return;
        }

        if (normalInputX != 0)
        {
            stateMachine.ChangeState(player.playerRunState);
        }
    }
}
