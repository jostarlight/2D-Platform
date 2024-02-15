using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool jumpPress;
    protected bool jumpInput;


    protected bool isGrounded;

    public PlayerAbilityState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }
    public override void Enter()
    {
        base.Enter();

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
        jumpInput = player.playerInputHandler.jumpInput;

        

    }
}
