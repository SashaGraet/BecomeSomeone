using Actors.Player.Stats;
using ServiceLocatorSystem;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerCharacter : MonoBehaviour, IService, IDamageable
    {
        [field: SerializeField, Range(1, 3)] public int Health { get; private set; }
        [field: SerializeField, Range(1, 3)] public int Coins { get; private set; }
        
        [SerializeField] private PlayerStatView healthView;
        [SerializeField] private PlayerStatView coinsView;
        
        public float speed = 20f;
        public Animator animator;

        private Vector2 moveVector;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        public void Initialize()
        {
            healthView.Initialize();
            coinsView.Initialize();
        }
        
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
        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;

                if (Health <= 0)
                {
                    Health = 0;
                    Die();
                }
                
                healthView.UpdateStat();
            }
        }

        public void Die()
        {
            Debug.Log("Умер");
        }

        public void AddCoins(int count)
        {
            if (count > 0)
            {
                Coins += count;
                coinsView.UpdateStat();
            }
        }
    }
}
