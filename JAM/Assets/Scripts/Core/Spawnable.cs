using UnityEngine;

namespace Core
{
    public class Spawnable : MonoBehaviour
    {
        public bool isFood;
        public float speed;

        private void FixedUpdate() => Move();
        
        private void Move() => transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }
}
