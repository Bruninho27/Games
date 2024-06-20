using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text comboCounterText;
        [SerializeField] private float gameDuration = 60f;

        [SerializeField] private Spawner spawner;
        [SerializeField] private SoundManager soundManager;

        public int score;
        private float _timeRemaining;
        private bool _isGameOver;
        private int _comboCounter;

        private void Awake()
        {
            _comboCounter = 1;
            scoreText.text = "Score: " + score;
            comboCounterText.text = _comboCounter + "X";
            timerText.text = "Timer: 00:00";
        }

        private void Start()
        {
            soundManager.PlayMainTheme();
            _timeRemaining = gameDuration;
        }
        private void Update()
        {
            if (_isGameOver) return;
            
            _timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(_timeRemaining);

            if (_timeRemaining <= 0) EndGame();

            Debug.Log(_comboCounter);
        }
        
        private void UpdateTimerDisplay(float time)
        {
            var minutes = Mathf.FloorToInt(time / 60);
            var seconds = Mathf.FloorToInt(time % 60);
                
            timerText.text = $"{minutes:00}:{seconds:00}";
        }

        public void UpdateComboCounterText() => comboCounterText.text = _comboCounter + "X";

        public void UpdateScoreText() => scoreText.text = "Score: " + score;

        public void IncreaseCombo() => ++_comboCounter;

        public void ResetCombo() => _comboCounter = 1;

        public void IncreaseScore()
        {
            score += 10 * _comboCounter;
            UpdateScoreText();

            spawner.IncreaseSpeed();
        }
        
        public void IncreaseTime()
        {
            _timeRemaining += 3;
            UpdateTimerDisplay(_timeRemaining);
        }
        
        public void DecreaseTime()
        {
            _timeRemaining -= 5;
            UpdateTimerDisplay(_timeRemaining);
        }
        
        private void EndGame()
        {
            _isGameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
