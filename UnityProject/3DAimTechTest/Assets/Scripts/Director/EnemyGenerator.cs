using Enemy;
using UnityEngine;

namespace Director
{
    public class EnemyGenerator : MonoBehaviour
    {
        public GameObject enemyPrefab;
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
            Instantiate(enemyPrefab);
        }
    }
}
