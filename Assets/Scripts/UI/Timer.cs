using Game;
using ServiceLocatorSystem;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Timer : MonoBehaviour, IService
    {
        [SerializeField] private SceneAsset playerHouseScene;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private TMP_Text minutesField;
        [SerializeField] private TMP_Text secondsField;
        [SerializeField, Range(1, 10)] private int startMinutes;
        [SerializeField, Range(0, 59)] private int startSeconds;
        
        private bool _isStart;
        private float _currentTime;

        public void Initialize()
        {
            StartTimer();
        }
        
        private void Update()
        {
            if (_isStart)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0)
                {
                    _currentTime = 0;
                    _isStart = false;
                    GameInfo.Reset();
                    SceneManager.LoadScene(playerHouseScene.name);
                }

                GameInfo.Time = _currentTime;
                UpdateFields();
            }
        }

        private void StartTimer()
        {
            if (!GameInfo.IsInitialized)
            {
                _currentTime = startMinutes * 60 + startSeconds;
            }
            else
            {
                _currentTime = GameInfo.Time;
            }
            
            _isStart = true;
        }

        private (int, int) TransformTime()
        {
            return ((int)(_currentTime / 60), (int)(_currentTime % 60));
        }

        private void UpdateFields()
        {
            (int minutes, int seconds) = TransformTime();

            minutesField.text = minutes.ToString();

            if (seconds < 10)
            {
                secondsField.text = "0" + seconds;   
            }
            else
            {
                secondsField.text = seconds.ToString();
            }
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        }
    }
}