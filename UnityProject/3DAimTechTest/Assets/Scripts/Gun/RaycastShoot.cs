using System.Collections;
using UnityEngine;

namespace Gun
{
    public class RaycastShoot : MonoBehaviour
    {
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

        private void Awake()
        {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time > _nextFire)
            {
                _nextFire = Time.time + fireRate;
                StartCoroutine(ShotEffect());
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                _laserLine.SetPosition(0,gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    _laserLine.SetPosition(1,hit.point);

                }
                else
                {
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
