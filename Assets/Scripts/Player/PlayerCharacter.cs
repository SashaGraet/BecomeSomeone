using ServiceLocatorSystem;
using UnityEngine;

namespace Player
{
    public class PlayerCharacter : MonoBehaviour, IService
    {
        public float speed = 20f;
        public Animator animator;

        private Vector2 moveVector;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
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
            animator.SetFloat("move", Mathf.Abs(rb.velocity.magnitude));
        }
    }
}
