using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public GameObject sprite;

    private Vector2 moveVector;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        moveVector = moveVector.normalized;

        if (moveVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        rb.velocity = moveVector * speed;
    }
}
