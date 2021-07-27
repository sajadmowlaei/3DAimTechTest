using System;
using Director;
using GameParameters;
using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        private float _health;
        public static event System.Action onDie;
        //public Settings gameParameters;
        //[SerializeField] private Settings gameParameters2;
        private void Start()
        {
            _health = SettingsReader.Instance.GameSettings.GetEnemyHealth;
        }

        public void Damage(float amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                onDie?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
