using UnityEngine;

namespace Enemy
{
    public class RandomWalk : MonoBehaviour
    {
        private Vector3 _destination;
        private Vector3 _startingPosition;

        private float speed = 2;
            // Start is called before the first frame update
        void Start()
        {
            _startingPosition = transform.position;
            _destination = new Vector3(Random.Range(-8, 8), 2, Random.Range(-8, 8));
        }

        void Update()
        {
            transform.Rotate(0,1,0);
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _destination, step);

            if (Vector3.Distance(transform.position, _destination) < 0.001f)
            {
                SetNewDestination();
            }
        }

        private void SetNewDestination()
        {
            _startingPosition = transform.position;
            _destination = new Vector3(Random.Range(-8, 8), 2, Random.Range(-8, 8));
        }
    }
}
