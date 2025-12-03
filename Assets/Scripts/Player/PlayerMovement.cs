using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player_body;
    private Animator player_animator;
    private Vector2 move_direction;
    
    [SerializeField]
    private InputActionReference move_action;
    [SerializeField]
    private float move_speed = 5f;

    [SerializeField]
    private InputActionReference jump_action;
    [SerializeField]
    private float jump_force = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_body = GetComponent<Rigidbody2D>();
        player_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move_direction = move_action.action.ReadValue<Vector2>();

        player_animator.SetFloat("MoveX", move_direction.x);
        player_animator.SetBool("IsMoving", Mathf.Abs(move_direction.x) > 0.1f);

        if (jump_action.action.WasPressedThisFrame())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        player_body.linearVelocity = new Vector2(move_direction.x * move_speed, player_body.linearVelocity.y);
    }

    void Jump()
    {
        player_body.linearVelocity = new Vector2(player_body.linearVelocity.x, jump_force);
    }
}