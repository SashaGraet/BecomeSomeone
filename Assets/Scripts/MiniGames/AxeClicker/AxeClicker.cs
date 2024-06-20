using System;
using RolesSystem;
using RolesSystem.Roles;
using ServiceLocatorSystem;
using SpawnSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace MiniGames.AxeClicker
{
    public class AxeClicker : MiniGameBase
    {
        [SerializeField] private GameObject holePrefab;
        [SerializeField, Range(2, 10)] private int countIterations;
        [SerializeField, Min(1)] private int sizeDelta;
        [SerializeField] private int size;
        [SerializeField, Min(10)] private int minSize;
        [SerializeField] private AxeCutterRole role;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Texture2D cursor;
        [SerializeField, Range(0.1f, 2f)] private float clickTime;

        protected override Role Role => role;
        
        private float _currentClickTime;
        private Spawner _spawner;
        private int _currentIteration;
        private Hole _hole;

        private void OnValidate()
        {
            if (sizeDelta >= size)
            {
                sizeDelta = size - 1;
            }
            
            if (size < minSize)
            {
                size = minSize;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            InitializeRole();
            _spawner = ServiceLocator.Instance.Get<Spawner>();
        }

        private void Awake()
        {
            Hide();
        }

        private void Update()
        {
            if (IsActive)
            {
                _currentClickTime += Time.deltaTime;
                if (_currentClickTime >= clickTime)
                {
                    Hide();
                }
            }
        }

        public override void StartGame()
        {
            if (!IsRoleAlreadyActivated())
            {
                gameObject.SetActive(true);
                SpawnHole();
                if (cursor != null)
                {
                    Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);   
                }

                IsActive = true;
                _currentClickTime = 0;
                _currentIteration = 0;
            }
        }

        protected override void OnWin<T>(T newRole)
        {
            base.OnWin(newRole);
            Hide();
        }

        public void OnWoodClick()
        {
            Hide();
        }

        private void OnHoleClick()
        {
            _currentIteration += 1;
            _currentClickTime = 0;
            if (!CheckIsEndIteration())
            {
                SpawnHole();
            }
            else
            {
                OnWin(role);
            }
        }
        
        private bool CheckIsEndIteration()
        {
            if (_currentIteration >= countIterations)
            {
                gameObject.SetActive(false);
                return true;
            }

            return false;
        }

        private void SpawnHole()
        {
            if (_hole != null)
            {
                _spawner.DestroyHandle(_hole.gameObject);
            }

            size = size - sizeDelta < minSize ? minSize : size - sizeDelta;
            Vector2 randomPoint = Random.insideUnitCircle * (rectTransform.rect.width / 2 - Convert.ToInt32(size / 2));

            _hole = _spawner.SpawnUI(holePrefab, randomPoint, transform).GetComponent<Hole>();
           
            _hole.Initialize(OnHoleClick);
            
            _hole.RectTransform.sizeDelta = new Vector2(size, size);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}