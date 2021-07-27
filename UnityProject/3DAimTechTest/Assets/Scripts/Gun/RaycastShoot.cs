using System.Collections;
using Director;
using Enemy;
using GameParameters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gun
{
    public class RaycastShoot : MonoBehaviour
    {
        public static event System.Action<int> onLoadedAmmoChanged;
        public static event System.Action onHit;
        public static event System.Action onMiss;
        private float _gunDamage;

        private float _fireRate;

        private float _weaponRange = 50f;

        public float hitForce = 100;
        public Transform gunEnd; // Ray starts here
        public Camera fpsCam;
        private WaitForSeconds shotDuration = new WaitForSeconds(0.07f); // how long we want the laser remain visible, to optimize memory performance

        private AudioSource _gunAudio;

        private LineRenderer _laserLine;

        private float _nextFire;
        private int _clipSize;
        private int _currentLoadedAmmo;
        private void Start()
        {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            _gunDamage = SettingsReader.Instance.GameSettings.GetDamage;
            _weaponRange = SettingsReader.Instance.GameSettings.GetWeaponRange;
            _fireRate = SettingsReader.Instance.GameSettings.GetRateOfFire / 1000;
            _clipSize = SettingsReader.Instance.GameSettings.GetClipSize;
            _currentLoadedAmmo = _clipSize;
        }

        private void ReloadGun()
        {
            _currentLoadedAmmo = _clipSize;
        }
        private void Update()
        {
            
            if (Input.GetButtonDown("Fire1") && Time.time > _nextFire && _currentLoadedAmmo > 0)
            {
                
                _currentLoadedAmmo -= 1;
                onLoadedAmmoChanged?.Invoke(_currentLoadedAmmo);
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
                    
                    EnemyWeakPoint weakPointComponent = hit.collider.GetComponent<EnemyWeakPoint>();
                    if(weakPointComponent != null)
                        weakPointComponent.Damage(_gunDamage);
                }
                else
                {
                    onMiss?.Invoke();
                    _laserLine.SetPosition(1,rayOrigin + (fpsCam.transform.forward*_weaponRange));
                }
            }

            if (Input.GetButtonDown("Reload"))
            {
                ReloadGun();
                onLoadedAmmoChanged?.Invoke(_currentLoadedAmmo);
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
