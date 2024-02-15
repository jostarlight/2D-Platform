using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public StateMachine stateMachine;

    public PlayerIdleState playerIdleState;
    public PlayerRunState playerRunState;
    public PlayerUpState playerUpState;
    public PlayerFallState playerFallState;

    public PlayerJumpState playerJumpState;

    public PlayerData playerData;

    public PlayerInputHandler playerInputHandler;

    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public CapsuleCollider2D capsuleCollider2D;
    // public Transform groundCheck;


    public int facingDirection;


    private void Awake()
    {

        stateMachine = new StateMachine();

        playerIdleState = new PlayerIdleState(this, stateMachine, playerData, "Idle");
        playerRunState = new PlayerRunState(this, stateMachine, playerData, "Run");
        playerJumpState = new PlayerJumpState(this, stateMachine, playerData, "Up");
        playerUpState = new PlayerUpState(this, stateMachine, playerData, "Up");
        playerFallState = new PlayerFallState(this, stateMachine, playerData, "Fall");

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerInputHandler = gameObject.GetComponent<PlayerInputHandler>();

    }
    // Start is called before the first frame update
    void Start()
    {
        stateMachine.Initialize(playerIdleState);

        facingDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {

        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicUpdate();
    }


    public void SetVelocityX(float velocity)
    {
        rigidbody2D.velocity = new Vector2(velocity, rigidbody2D.velocity.y);
    }

    public void SetVelocityY(float velocity)
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocity);
    }

    public void AddForce(float force)
    {
        rigidbody2D.AddForce(Vector2.up * force);
    }

    public void CheckIfShouldFlip(float xInput)
    {
        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }

    public bool CheckIfTouchGround()
    {
        return Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, capsuleCollider2D.size, capsuleCollider2D.direction, 0, Vector2.down, playerData.GrounderDistance, playerData.groundLayer);

    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }


}
