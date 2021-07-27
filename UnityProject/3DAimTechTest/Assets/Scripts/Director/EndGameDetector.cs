using System;
using Enemy;
using GameParameters;
using Gun;
using UnityEngine;

namespace Director
{
    public class EndGameDetector : MonoBehaviour
    {
        private int _targetsToKill;
        private int _currentKill;
        public static event System.Action<int> onGameEnd;
        private void Start()
        {
            _targetsToKill = SettingsReader.Instance.GameSettings.GetTargetToKill;
            _currentKill = 0;
        }

        private void OnEnable()
        {
            Health.onDie += EnemyIsDead;
        }
        private void OnDisable()
        {
            Health.onDie -= EnemyIsDead;
        }
        private void EnemyIsDead()
        {
            _currentKill++;
            if (_currentKill >= _targetsToKill)
            {
                // send an event to the UI
                onGameEnd?.Invoke(_currentKill*10);
            }
        }

    }
}
