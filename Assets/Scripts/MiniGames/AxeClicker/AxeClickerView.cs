using System;
using MiniGames.MiniGameBase;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniGames.AxeClicker
{
    public class AxeClickerView : MiniGameViewBase
    {
        [field: SerializeField] public Collider2D WoodCollider { get; private set; }
        [field: SerializeField] public GameObject HolePrefab { get; private set; }
        [field: SerializeField] public Collider2D SpawnZone { get; private set; }
        [field: SerializeField, Range(2, 10)] public int CountIterations { get; private set; }
        [field: SerializeField, Min(0.1f)] public float ScaleDelta { get; private set; }
        
        private AxeClickerPresenter _presenter;

        public override void Initialize()
        {
            base.Initialize();
            _presenter = CreatePresenter(new AxeClickerPresenter(new AxeClickerModel(data), this));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                
                if (hit.collider == WoodCollider)
                {
                    _presenter.OnWoodClick();
                }
                else if (_presenter.IsHoleCollider(hit.collider))
                {
                    _presenter.OnHoleClick();
                }
                else
                {
                    Debug.Log(hit.collider.name);
                }
                
            }
        }
    }
}