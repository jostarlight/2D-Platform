using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    // Start is called before the first frame update
    public PlayerRunState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(normalInputX);


        // player.SetVelocityX(playerData.movementSpeed * input.x);

        // if (input.x == 0)
        // {
        //     stateMachine.ChangeState(player.playerIdleState);
        // }
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
            var velocityX = Mathf.MoveTowards(player.rigidbody2D.velocity.x, 0, playerData.GroundDeceleration * Time.fixedDeltaTime);
            player.SetVelocityX(velocityX);
        }

        if (normalInputX == 0 && player.rigidbody2D.velocity.x == 0)
        {
            stateMachine.ChangeState(player.playerIdleState);
        }
    }
}
