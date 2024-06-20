using System;
using ServiceLocatorSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour, IService
    {
        [SerializeField] private TMP_Text minutesField;
        [SerializeField] private TMP_Text secondsField;

        private bool _isStart;
        private float _currentTime;
        private Action _onEndTime;

        private void Update()
        {
            if (_isStart)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0)
                {
                    _currentTime = 0;
                    _isStart = false;
                    _onEndTime.Invoke();
                }
                
                UpdateFields();
                
            }
        }

        public void StartTimer(int minutes, int seconds, Action onEndTime)
        {
            if (minutes < 0 || seconds < 0)
            {
                Debug.LogError("Time values less than 0");
                return;
            }

            if (seconds > 60)
            {
                Debug.LogError("Seconds more than 60");
                return;
            }

            _currentTime = minutes * 60 + seconds;
            _onEndTime = onEndTime;
            _isStart = true;
        }

        private (int, int) TransformTime()
        {
            int minutes = (int)(_currentTime / 60);
            int seconds = (int)(_currentTime % 60);

            return (minutes, seconds);
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
        }
    }
}