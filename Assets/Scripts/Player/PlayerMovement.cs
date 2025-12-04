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

    [SerializeField]
    private InputActionReference interact_action;
    [SerializeField]
    private float interact_range = 1.5f;
    private bool is_ground = false;

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

        if (interact_action.action.WasPressedThisFrame())
        {
            HandleInteraction();
        }
    }

    void FixedUpdate()
    {
        player_body.linearVelocity = new Vector2(move_direction.x * move_speed, player_body.linearVelocity.y);
    }

    void Jump()
    {
        if (is_ground)
        {
            player_body.linearVelocity = new Vector2(player_body.linearVelocity.x, jump_force);
            is_ground = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            is_ground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            is_ground = false;
        }
    }

    private void HandleInteraction()
    {
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (inventory == null)
            return;

        Collider2D[] hit_colliders = Physics2D.OverlapCircleAll(transform.position, interact_range);

        if (inventory.HasItem())
        {
            foreach (var collider in hit_colliders)
            {
                if (collider.CompareTag("Shrine"))
                {
                    Shrine shrine = collider.GetComponent<Shrine>();
                    if (shrine != null)
                    {
                        if (shrine.TryOfferItem(inventory.GetCurrentItem()))
                        {
                            inventory.DropItem();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            inventory.DropItem();
            return;
        }

        foreach (var collider in hit_colliders)
        {
            if (collider.CompareTag("Item"))
            {
                ItemPickUp item_pickup = collider.GetComponent<ItemPickUp>();
                if (item_pickup != null && item_pickup.TryPickUp(inventory))
                {
                   return;
                }
            }
        }
    }

    public bool IsGround()
    {
        return is_ground;
    }
}