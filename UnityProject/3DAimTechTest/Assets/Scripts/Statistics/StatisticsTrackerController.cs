using System;
using System.Xml;
using Director;
using Enemy;
using Gun;
using UnityEngine;

namespace Statistics
{
    public class StatisticsTrackerController : MonoBehaviour
    {
        private StatisticsTrackerData _data;
        public static event System.Action<float> onScoreChanged;
        public static event System.Action<float,float,float> onGameEnd;
        private void Start()
        {
            _data = new StatisticsTrackerData(0,0,0,0,0,0,0,0);
            
            _data.targetsToKill = SettingsReader.Instance.GameSettings.GetTargetToKill;
        }
        private void OnEnable()
        {
            RaycastShoot.onHit += HitBullet;
            RaycastShoot.onMiss += MissBullet;
            Health.onDie += EnemyIsDead;
            EnemyWeakPoint.onDieWeakPoint  += EnemyIsDeadCriticalHit;

        }
        private void OnDisable()
        {
            RaycastShoot.onHit -= HitBullet;
            RaycastShoot.onMiss -= MissBullet;
            Health.onDie -= EnemyIsDead;
            EnemyWeakPoint.onDieWeakPoint  += EnemyIsDeadCriticalHit;
        }

        private void CheckEndGameCondition()
        {
            if (_data.currentKill >= _data.targetsToKill)
            {
                CalculateAndSaveStatuscics();
                onGameEnd?.Invoke(_data.score,_data.accuracy,_data.criticalAccuracy);
            }
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
            _data.currentKill += 1;
            onScoreChanged?.Invoke(_data.score);
            CheckEndGameCondition();
        }
        private void EnemyIsDeadCriticalHit()
        {
            _data.score += 30;
            _data.numOfCriticalHit++;
            _data.currentKill += 1;
            onScoreChanged?.Invoke(_data.score);
            CheckEndGameCondition();
        }
        

        void CalculateAndSaveStatuscics()
        {
            XmlDocument map = new XmlDocument();
                
            XmlNode rootNode = map.CreateElement("playerStatistics");
            map.AppendChild(rootNode);
                
            XmlNode score = map.CreateElement("score");
            rootNode.AppendChild(score);
            score.InnerText = _data.score.ToString();
                
            XmlNode accuracy = map.CreateElement("accuracy");
            rootNode.AppendChild(accuracy);
            _data.accuracy = ((float) _data.numOfHit /
                              ((float) _data.numOfHit + (float) _data.numOfMiss + (float) _data.numOfCriticalHit));
            accuracy.InnerText = _data.accuracy.ToString();
                
            XmlNode criticalAccuracy = map.CreateElement("criticalAccuracy");
            rootNode.AppendChild(criticalAccuracy);
            _data.criticalAccuracy = ((float) _data.numOfCriticalHit /
                                      ((float) _data.numOfHit + (float) _data.numOfMiss +
                                       (float) _data.numOfCriticalHit));
            criticalAccuracy.InnerText = _data.criticalAccuracy.ToString();
                
            map.Save("Statistics.xml");
        }
    }
}
