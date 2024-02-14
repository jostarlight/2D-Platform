using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{

    protected Player player;
    protected StateMachine stateMachine;
    protected PlayerData playerData;

    public float startTime;

    private string animationName;

    public PlayerState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        DoCheck();
        player.animator.SetBool(animationName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animationName, false);


    }

    public virtual void PhysicUpdate()
    {
        DoCheck();

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void DoCheck()
    {

    }
}
