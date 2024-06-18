using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Spawnable : MonoBehaviour
    {

        public bool isFood;
        public float speed;

        private void Awake()
        {
            

        }
        private void Update() => Move();
        
        private void Move() => transform.Translate(Vector3.down * (speed * Time.deltaTime));
      
    }
}
