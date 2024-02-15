using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected Vector2 input;
    protected int normalInputX;

    protected bool isGrounded;

    public bool jumpPress { get; private set; }

    public bool endedJumpEarly = false;

    public PlayerInAirState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckIfTouchGround();
        jumpPress = player.playerInputHandler.jumpPress;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        input = player.playerInputHandler.movementInput;
        normalInputX = player.playerInputHandler.normalInputX;

        player.CheckIfShouldFlip(normalInputX);

        if (player.playerInputHandler.jumpInput)
        {
            player.playerInputHandler.timeJumpWasPressed = Time.time;
        }



        // if (player.rigidbody2D.velocity.y <= 0)
        // {
        //     player.rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (playerData.fallMultiplier - 1) * Time.deltaTime;
        // }
        // else if (player.rigidbody2D.velocity.y > 0)
        // {
        //     player.rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (playerData.lowJumpMultiplier - 1) * Time.deltaTime;
        // }

        // Debug.Log(isGrounded + "     " + player.rigidbody2D.velocity);


    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        if (normalInputX != 0)
        {
            var velocityX = Mathf.MoveTowards(player.rigidbody2D.velocity.x, normalInputX * playerData.MaxSpeed, playerData.Acceleration * Time.fixedDeltaTime);
            player.SetVelocityX(velocityX);
        }
        else
        {
            var velocityX = Mathf.MoveTowards(player.rigidbody2D.velocity.x, 0, playerData.AirDeceleration * Time.fixedDeltaTime);
            player.SetVelocityX(velocityX);
        }

        if (!jumpPress && player.rigidbody2D.velocity.y > 0 && !player.playerInputHandler.endedJumpEarly)
        {
            player.playerInputHandler.endedJumpEarly = true;
        }
        var inAirGravity = playerData.FallAcceleration;

        if (player.playerInputHandler.endedJumpEarly)
        {

            inAirGravity *= playerData.JumpEndEarlyGravityModifier;
        }


        var velocityY = Mathf.MoveTowards(player.rigidbody2D.velocity.y, -playerData.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
        player.SetVelocityY(velocityY);

        if (isGrounded && player.rigidbody2D.velocity.y < 0.1f)
        {
            player.playerInputHandler.endedJumpEarly = false;
            player.playerInputHandler.bufferedJumpUsable = true;
            player.playerInputHandler.coyoteUsable = true;


            if (player.rigidbody2D.velocity.x != 0)
            {
                stateMachine.ChangeState(player.playerRunState);
            }
            else
            {
                stateMachine.ChangeState(player.playerIdleState);

            }
        }
    }
}
