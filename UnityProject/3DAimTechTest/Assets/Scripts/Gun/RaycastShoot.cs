using System.Collections;
using Director;
using Enemy;
using GameParameters;
using UnityEngine;

namespace Gun
{
    public class RaycastShoot : MonoBehaviour
    {
        public static event System.Action<Vector2Int, Vector3> onTest;
        public static event System.Action onHit;
        public static event System.Action onMiss;
        private float _gunDamage;

        private float _fireRate;

        private float _weaponRange = 50f;

        public float hitForce = 100;
        public Transform gunEnd; // ray az inja shoroo mishe
        public Camera fpsCam;
        private WaitForSeconds shotDuration = new WaitForSeconds(0.07f); // how long we want the laser remain visible, to optimize memory performance

        private AudioSource _gunAudio;

        private LineRenderer _laserLine;

        private float _nextFire;

        private void Start()
        {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            _gunDamage = SettingsReader.Instance.GameSettings.GetDamage;
            _weaponRange = SettingsReader.Instance.GameSettings.GetWeaponRange;
            _fireRate = SettingsReader.Instance.GameSettings.GetRateOfFire / 1000;
        }

        private void Update()
        {
            
            if (Input.GetButtonDown("Fire1") && Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                StartCoroutine(ShotEffect());
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                _laserLine.SetPosition(0,gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, _weaponRange))
                {
                    onHit?.Invoke();
                    _laserLine.SetPosition(1,hit.point);
                    Health healthComponent = hit.collider.GetComponent<Health>();
                    if(healthComponent != null)
                        healthComponent.Damage(_gunDamage);

                }
                else
                {
                    onMiss?.Invoke();
                    _laserLine.SetPosition(1,rayOrigin + (fpsCam.transform.forward*_weaponRange));
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
