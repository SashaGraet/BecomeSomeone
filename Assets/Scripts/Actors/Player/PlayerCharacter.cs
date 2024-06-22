using Actors.Player.Stats;
using Game;
using InteractSystem;
using InventorySystem;
using ServiceLocatorSystem;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerCharacter : MonoBehaviour, IService, IDamageable
    {
        [field: SerializeField] public Inventory Inventory { get; private set; }

        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private PlayerStatView healthView;
        [SerializeField] private PlayerStatView coinsView;
        [SerializeField] private InteractManager interactManager;
        
        public float speed = 20f;
        public Animator animator;

        private Vector2 moveVector;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        public void Initialize()
        {
            if (!GameInfo.IsInitialized)
            {
                GameInfo.PlayerInfo = playerInfo;
            }

            if (GameInfo.NewPosition != null) 
            {
                transform.position = (Vector2)GameInfo.NewPosition;
            }
            
            healthView.Initialize();
            coinsView.Initialize();
            interactManager.Initialize();
            Inventory.Initialize();
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
                GameInfo.PlayerInfo.health -= damage;

                if (GameInfo.PlayerInfo.health <= 0)
                {
                    GameInfo.PlayerInfo.health = 0;
                    Die();
                }
                
                healthView.UpdateStat();
            }
        }

        public void Die()
        {
            Debug.Log("Умер");
        }

        public void ChangeCoins(int delta)
        {
            if (delta > 0)
            {
                GameInfo.PlayerInfo.coins += delta;
                coinsView.UpdateStat();
            } 
            else if (delta < 0)
            {
                GameInfo.PlayerInfo.coins += delta;
                if (GameInfo.PlayerInfo.coins < 0)
                {
                    GameInfo.PlayerInfo.coins = 0;
                }
                coinsView.UpdateStat();
            }
        }
    }
}
