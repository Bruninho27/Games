using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        public Spawnable[] spawnableObjects;
        public float spawnInterval = 2f;
        private float _timer;

        private Transform _spawnPoint;
        [SerializeField] private Vector2 spawnAreaSize;
        
        [SerializeField] private float speed;
        [SerializeField] private float speedMultiplier;

        private void Awake() => _spawnPoint = GetComponent<Transform>();
        
        private void Update()
        {
            _timer += Time.deltaTime;
            
            if (!(_timer >= spawnInterval)) return;

            if (!IsSpawnAreaClear()) return;
            
            SpawnObject();
            _timer = 0;
        }

        private bool IsSpawnAreaClear()
        {
            var colliders = Physics2D.OverlapBoxAll(_spawnPoint.position, spawnAreaSize, 0f);

            return colliders.Length == 0;
        }

        private void SpawnObject()
        {
            var objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Length)];

            objectToSpawn.speed = speed;

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
        
        public void IncreaseSpeed()
        {
            speed += speed * speedMultiplier;
            spawnInterval -= spawnInterval * speedMultiplier;
        }
    }
}
