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
        AudioManager audioManager;

        private void Awake()
        {
            leftButton.onClick.AddListener(OnLeftButtonClick);
            rightButton.onClick.AddListener(OnRightButtonClick);
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        private void OnLeftButtonClick() => CheckIfIsCorrect(true);
        private void OnRightButtonClick() => CheckIfIsCorrect(false);
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_spawnableSelect)
            {
                Destroy(_spawnableSelect.gameObject);
                Destroy(collision.GetComponent<Spawnable>().gameObject);
                gameManager.DecreaseTime();
                gameManager.ResetCombo();
                gameManager.UpdateComboCounterText();

            }

            _spawnableSelect = collision.GetComponent<Spawnable>();
            _spawnableSelect.speed = 0f;
        }

        private void CheckIfIsCorrect(bool inputValue)
        {
            if (_spawnableSelect != null)
            {
                if (_spawnableSelect.isFood == inputValue)
                {
                    gameManager.IncreaseCombo();
                    gameManager.IncreaseScore();
                    gameManager.UpdateScoreText();
                    gameManager.UpdateComboCounterText();
                    gameManager.IncreaseTime();
                }
                else
                {
                    audioManager.PlaySFX(audioManager.errar);
                    gameManager.ResetCombo();
                    gameManager.DecreaseTime();
                    gameManager.UpdateComboCounterText();
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
