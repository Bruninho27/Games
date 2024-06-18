using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        public Spawnable[] spawnableObjects;
        public float spawnInterval = 2f;
        private float _timer;
        
        [SerializeField] private float speed;

        private void Update()
        {
            _timer += Time.deltaTime;
            
            if (!(_timer >= spawnInterval)) return;
            
            SpawnObject();
            _timer = 0;
        }

        private void SpawnObject()
        {
            var objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Length)];

            objectToSpawn.speed = speed;

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
