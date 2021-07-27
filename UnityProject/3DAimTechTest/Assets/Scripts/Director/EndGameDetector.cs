using Enemy;
using Gun;
using UnityEngine;

namespace Director
{
    public class EndGameDetector : MonoBehaviour
    {
        
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
            //_data.numOfHit++;
        }

    }
}
