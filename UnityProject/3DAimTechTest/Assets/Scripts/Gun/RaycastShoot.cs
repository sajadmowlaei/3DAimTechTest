using System.Collections;
using Enemy;
using UnityEngine;

namespace Gun
{
    public class RaycastShoot : MonoBehaviour
    {
        public static event System.Action<Vector2Int, Vector3> onTest;
        public static event System.Action onHit;
        public static event System.Action onMiss;
        public int gunDamage = 1;

        public float fireRate = .25f;

        public float weaponRange = 50f;

        public float hitForce = 100;
        public Transform gunEnd; // ray az inja shoroo mishe
        public Camera fpsCam;
        private WaitForSeconds shotDuration = new WaitForSeconds(0.07f); // how long we want the laser remain visible, to optimize memory performance

        private AudioSource _gunAudio;

        private LineRenderer _laserLine;

        private float _nextFire;

        //public GameObject debutHitPoint;
        private void Awake()
        {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            
            if (Input.GetButtonDown("Fire1") && Time.time > _nextFire)
            {
                Debug.Log("injaa");
                _nextFire = Time.time + fireRate;
                StartCoroutine(ShotEffect());
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                _laserLine.SetPosition(0,gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    onHit?.Invoke();
                    _laserLine.SetPosition(1,hit.point);
                    Health healthComponent = hit.collider.GetComponent<Health>();
                    if(healthComponent != null)
                        healthComponent.Damage(1);

                }
                else
                {
                    onMiss?.Invoke();
                    _laserLine.SetPosition(1,rayOrigin + (fpsCam.transform.forward*weaponRange));
                }
            }
            
        }

        private IEnumerator ShotEffect()
        {
            _laserLine.enabled = true;
            yield return shotDuration;
            _laserLine.enabled = false;
        }
    }
}
