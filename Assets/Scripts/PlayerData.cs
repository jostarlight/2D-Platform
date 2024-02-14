using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/new Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("MOVEMENT")]
    public LayerMask groundLayer;

    public float jumpForce = 5;


    [Tooltip("The top horizontal movement speed")]
    public float MaxSpeed = 14;

    [Tooltip("The player's capacity to gain horizontal speed")]
    public float Acceleration = 120;

    [Tooltip("The pace at which the player comes to a stop")]
    public float GroundDeceleration = 60;

    [Tooltip("Deceleration in air only after stopping input mid-air")]
    public float AirDeceleration = 30;
    public float GrounderDistance = 0.3f;
    public int MaxFallSpeed = 10;

    public int FallAcceleration = 10;
    public int JumpEndEarlyGravityModifier = 3;
    public float JumpBuffer = 0.2f;
    public float CoyoteTime = 0.15f;
}
