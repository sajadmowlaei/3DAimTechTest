using System;
using Enemy;
using Gun;
using UnityEngine;

namespace Statistics
{
    public class StatisticsTrackerController : MonoBehaviour
    {
        private StatisticsTrackerData _data;
        public static event System.Action<float> onScoreChanged;
        private void Awake()
        {
            _data = new StatisticsTrackerData(0,0,0);
        }
        private void OnEnable()
        {
            RaycastShoot.onHit += HitBullet;
            RaycastShoot.onMiss += MissBullet;
            Health.onDie += EnemyIsDead;
        }
        private void OnDisable()
        {
            RaycastShoot.onHit -= HitBullet;
            RaycastShoot.onMiss -= MissBullet;
            Health.onDie -= EnemyIsDead;
        }
        
        private void HitBullet()
        {
            _data.numOfHit++;
        }
        private void MissBullet()
        {
            _data.numOfMiss++;
        }

        private void EnemyIsDead()
        {
            _data.score += 10;
            onScoreChanged?.Invoke(_data.score);
        }
    }
}
