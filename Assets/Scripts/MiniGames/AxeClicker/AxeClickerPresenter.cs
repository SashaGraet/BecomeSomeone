using MiniGames.MiniGameBase;
using ServiceLocatorSystem;
using SpawnSystem;
using UnityEngine;

namespace MiniGames.AxeClicker
{
    public class AxeClickerPresenter : MiniGamePresenterBase
    {
        private readonly AxeClickerModel _model;
        private readonly AxeClickerView _view;
        private readonly Spawner _spawner;
        private readonly RectTransform _viewRectTransform;
        
        public AxeClickerPresenter(AxeClickerModel model, AxeClickerView view) : base(model, view)
        {
            _model = model;
            _view = view;
            _spawner = ServiceLocator.Instance.Get<Spawner>();
            _viewRectTransform = _view.GetComponent<RectTransform>();
        }

        public override void StartGame()
        {
            SpawnHole();
        }

        public void OnWoodClick()
        {
            _model.CurrentIteration += 1;
            CheckIsEndIteration();
        }

        public void OnHoleClick()
        {
            _model.CurrentIteration += 1;
            if (!CheckIsEndIteration())
            {
                SpawnHole();
            }
        }

        public bool IsHoleCollider(Collider2D collision)
        {
            if (_model.Hole.GetComponent<Collider2D>() == collision)
            {
                return true;
            }

            return false;
        }

        private bool CheckIsEndIteration()
        {
            if (_model.CurrentIteration >= _view.CountIterations)
            {
                _view.gameObject.SetActive(false);
                return true;
            }

            return false;
        }

        private void SpawnHole()
        {
            _spawner.DestroyHandle(_model.Hole);
            Bounds bounds = _view.SpawnZone.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_viewRectTransform, new Vector2(randomX, randomY),
                null, out Vector2 localPosition);

           _model.Hole = _spawner.SpawnUI(_view.HolePrefab, localPosition, _view.WoodCollider.transform.parent);
        }
    }
}