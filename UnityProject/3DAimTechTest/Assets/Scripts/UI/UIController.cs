using Director;
using Statistics;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        public GameObject textScore;

        public GameObject textClipSize;
        public GameObject panelEndGame;
        private Text _textScore;

        private void Awake()
        {
            _textScore = textScore.GetComponent<Text>();
        }

        private void OnEnable()
        {
            EndGameDetector.onGameEnd += ShowEngGameMenu;
            StatisticsTrackerController.onScoreChanged += ScoreChanged;
        }
        private void OnDisable()
        {
            EndGameDetector.onGameEnd -= ShowEngGameMenu;
            StatisticsTrackerController.onScoreChanged -= ScoreChanged;
        }
        void ShowEngGameMenu(int score)
        {
            panelEndGame.SetActive(true);
        }
        private void ScoreChanged(float newScore)
        {
            _textScore.text = newScore.ToString();
        }

    }
    
}
