using ScoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdditionalPanel
{
    public class AdditionalPanelView : MonoBehaviour,IScoreView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _collectButton;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private RectTransform _panel;
        
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }
        
        public void CloseButtonSubscribe(UnityAction action)
        {
            _closeButton.onClick.AddListener(action);
        }
    
        public void CloseButtonUnsubscribe(UnityAction action)
        {
            _closeButton.onClick.RemoveListener(action);
        }
        
        public void CollectButtonSubscribe(UnityAction action)
        {
            _collectButton.onClick.AddListener(action);
        }
        
        public void CollectButtonUnsubscribe(UnityAction action)
        {
            _collectButton.onClick.RemoveListener(action);
        }
        
        public void ClosePanel()
        {
            _panel.gameObject.SetActive(false);
        }
        
        public void OpenPanel()
        {
            _panel.gameObject.SetActive(true);
        }

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
