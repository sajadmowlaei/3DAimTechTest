using System;
using Gun;
using UnityEngine;

namespace Statistics
{
    public class StatisticsTrackerController : MonoBehaviour
    {
        private StatisticsTrackerData _data;

        private void Awake()
        {
            _data = new StatisticsTrackerData(0,0);
        }
        private void OnEnable()
        {
            RaycastShoot.onHit += HitBullet;
            RaycastShoot.onMiss += MissBullet;
        }
        private void OnDisable()
        {
            RaycastShoot.onHit -= HitBullet;
            RaycastShoot.onMiss -= MissBullet;
        }

        private void HitBullet()
        {
            _data.numOfHit++;
        }
        private void MissBullet()
        {
            _data.numOfMiss++;
        }
    }
}
