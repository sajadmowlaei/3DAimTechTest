using Director;
using Gun;
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
        public GameObject panelEndGameTextScore;
        public GameObject panelEndGameTextAccuracy;
        public GameObject panelEndGameTextCriticalAccuracy;
        private Text _textScore;
        private Text _textAmmo;
        private Text _textPanelEndGameTextScore;
        private Text _textPanelEndGameTextAccuracy;
        private Text _textPanelEndGameTextCriticalAccuracy;

        private void Awake()
        {
            _textScore = textScore.GetComponent<Text>();
            _textAmmo = textClipSize.GetComponent<Text>();
            _textPanelEndGameTextScore = panelEndGameTextScore.GetComponent<Text>();
            _textPanelEndGameTextAccuracy = panelEndGameTextAccuracy.GetComponent<Text>();
            _textPanelEndGameTextCriticalAccuracy = panelEndGameTextCriticalAccuracy.GetComponent<Text>();
        }

        private void OnEnable()
        {
            StatisticsTrackerController.onGameEnd += ShowEngGameMenu;
            StatisticsTrackerController.onScoreChanged += ScoreChanged;
            RaycastShoot.onLoadedAmmoChanged += UpdateLoadedAmmo;
        }
        private void OnDisable()
        {
            StatisticsTrackerController.onGameEnd -= ShowEngGameMenu;
            StatisticsTrackerController.onScoreChanged -= ScoreChanged;
            RaycastShoot.onLoadedAmmoChanged -= UpdateLoadedAmmo;
        }

        void UpdateLoadedAmmo(int newValue)
        {
            _textAmmo.text = "Ammo : "+newValue.ToString();
        }
        void ShowEngGameMenu(float score, float accuracy,float criticalAccuracy)
        {
            panelEndGame.SetActive(true);
            _textPanelEndGameTextScore.text = "score : "+score.ToString();
            _textPanelEndGameTextAccuracy.text = "accuracy : "+accuracy.ToString();
            _textPanelEndGameTextCriticalAccuracy.text = "criticalAccuracy : "+criticalAccuracy.ToString();
        }
        private void ScoreChanged(float newScore)
        {
            _textScore.text = "Score: "+newScore.ToString();
        }

    }
    
}
