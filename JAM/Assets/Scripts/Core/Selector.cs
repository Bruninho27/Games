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
        private AudioManager _audioManager;

        private void Awake()
        {
            leftButton.onClick.AddListener(OnLeftButtonClick);
            rightButton.onClick.AddListener(OnRightButtonClick);
            _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                CheckIfIsCorrect(false);
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
                CheckIfIsCorrect(true);
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
                _audioManager.PlaySfx(_audioManager.passouItem);
            }

            _spawnableSelect = collision.GetComponent<Spawnable>();
            _spawnableSelect.speed = 0f;
        }

        private void CheckIfIsCorrect(bool inputValue)
        {
            if (_spawnableSelect == null) return;
            
            if (_spawnableSelect.isFood == inputValue)
            {
                _audioManager.PlaySfx(_audioManager.novoobjesteira);
                gameManager.IncreaseCombo();
                gameManager.IncreaseScore();
                gameManager.UpdateScoreText();
                gameManager.UpdateComboCounterText();
                gameManager.IncreaseTime();
            }
            else
            {   
                _audioManager.PlaySfx(_audioManager.errar);
                gameManager.ResetCombo();
                gameManager.DecreaseTime();
                gameManager.UpdateComboCounterText();
            }

            Destroy(_spawnableSelect.gameObject);
            _spawnableSelect = null;
        }
    }
}
