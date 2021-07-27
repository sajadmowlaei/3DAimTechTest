using UnityEngine;

namespace Enemy
{
    public class EnemyWeakPoint : MonoBehaviour
    {
        public static event System.Action onDieWeakPoint;
        public void Damage(float amount)
        {
            onDieWeakPoint?.Invoke();
            Destroy(transform.parent.gameObject);
        }
    }
}
