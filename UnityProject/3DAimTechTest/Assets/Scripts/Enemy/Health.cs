using System;
using GameParameters;
using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        private float _health;
        public static event System.Action onDie;
        public Settings gameParameters;
        private void Awake()
        {
            _health = gameParameters.GetEnemyHealth;
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
