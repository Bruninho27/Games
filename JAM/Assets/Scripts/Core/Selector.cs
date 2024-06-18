using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private GameManager gameManager;

        private Spawnable _spawnableSelect;

        private void Awake()
        {
            leftButton.onClick.AddListener(OnLeftButtonClick);
            rightButton.onClick.AddListener(OnRightButtonClick);

        }

        private void OnLeftButtonClick() => CheckIfIsCorrect(true); 
        private void OnRightButtonClick() => CheckIfIsCorrect(false);
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _spawnableSelect = collision.GetComponent<Spawnable>();
            _spawnableSelect.speed = 0f;
        }

        private void CheckIfIsCorrect(bool inputValue)
        {
            
            if (_spawnableSelect != null)
            {
                if (_spawnableSelect.isFood == inputValue)
                {
                    gameManager.IncreaseScore();
                    Debug.Log("Certo!");
                }
                else
                {
                    Debug.Log("Errado!");
                }
                
                Destroy(_spawnableSelect.gameObject);
                _spawnableSelect = null;
            }
            else
            {
                Debug.LogWarning("Nenhum objeto no colisor.");
            }
          
        }
      
    }
}
