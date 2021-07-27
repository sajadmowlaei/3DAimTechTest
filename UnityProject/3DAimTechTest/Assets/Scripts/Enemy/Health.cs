using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        public float health;

        public void Damage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Destroy(gameObject);
                //
            }
        }
    }
}
