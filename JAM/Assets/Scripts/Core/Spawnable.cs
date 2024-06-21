using UnityEngine;

namespace Core
{
    public class Spawnable : MonoBehaviour
    {
        public bool isFood;
        public float speed;

        private void Update() => Move();
        
        private void Move() => transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
}
