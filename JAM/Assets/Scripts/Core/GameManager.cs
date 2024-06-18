using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        [SerializeField] private Text scoreText;
        [SerializeField] private float gameDuration = 60f;
        
        public int score = 0;
        private float _timeRemaining;
        private bool _isGameOver = false;

        private void Awake()
        {
            scoreText.text = "Score: " + score;
            timerText.text = "Timer: 00:00";
        }

        private void Start() => _timeRemaining = gameDuration;
        
        private void Update()
        {
            if (_isGameOver) return;
            
            _timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(_timeRemaining);

            if (_timeRemaining <= 0) EndGame();
        }
        
        private void UpdateTimerDisplay(float time)
        {
            var minutes = Mathf.FloorToInt(time / 60);
            var seconds = Mathf.FloorToInt(time % 60);
                
            timerText.text = $"{minutes:00}:{seconds:00}";
        }

        private void EndGame()
        {
            _isGameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void IncreaseScore()
        {
            score += 10;
            scoreText.text = "Score: " + score;
        }
    }
}
