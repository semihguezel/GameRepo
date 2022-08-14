using UnityEngine;

namespace Game
{
    public class ObstacleGenerator : MonoBehaviour
    {
        public GameObject obstacle;

        public float minSpeed;

        public float maxSpeed;

        public float currentSpeed;

        public float speedMultiplier;
    
        // Start is called before the first frame update
        void Awake()
        {
            currentSpeed = minSpeed;
            GenerateObstacles();
        }

        public void GenerateObstacles()
        {
            var obstacleInspector= Instantiate(obstacle, transform.position, transform.rotation);
            obstacleInspector.GetComponent<ObstacleScript>().obstacleGenerator = this;
        }

        public void GenerateObstaclesRandomly()
        {
            var randomWait = Random.Range(0.1f, 1.2f);
            Invoke(nameof(GenerateObstacles), randomWait);
        }
        // Update is called once per frame
        void Update()
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += speedMultiplier;
            }
        }
    }
}