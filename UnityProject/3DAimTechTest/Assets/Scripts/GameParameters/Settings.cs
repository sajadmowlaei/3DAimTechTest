using UnityEngine;
using UnityEngine.Serialization;

// This ScriptableObject is used to define the setting of the Game.
// parameters are stored here and can be edited by users.
namespace GameParameters
{
    [CreateAssetMenu(menuName = "3DAim/Settings", fileName = "GameParameters")]
    public class Settings : ScriptableObject
    {
        [SerializeField] private float enemyHealth = 150 ;
        [SerializeField] private float rateOfFire = 600;
        [SerializeField] private int clipSize = 30;
        [SerializeField] private float damage = 50;
        [SerializeField] private float weaponRange= 50;
        [SerializeField] private int targetsToKill = 30;
        public float GetEnemyHealth => enemyHealth;
        public float GetRateOfFire => rateOfFire;
        public int GetClipSize => clipSize;
        public float GetDamage => damage;
        public int GetTargetToKill => targetsToKill;
        public float GetWeaponRange => weaponRange;
    }
}

