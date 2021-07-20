using UnityEngine;

namespace Gun
{
    // this class is just for debuging
    
    public class RayViewer : MonoBehaviour
    {
        public float weaponRange = 50;
        public Camera fpsCam;
        
        private void Update()
        {
            Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(lineOrigin,fpsCam.transform.forward*weaponRange,Color.green);
        }
    }
}
