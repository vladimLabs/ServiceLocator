using Audio;
using Core;
using MainMenu;
using SaveSystem;
using ScoreSystem;
using UISwitchingSystem;

namespace AdditionalPanel
{
    public class AdditionalPanelUIState : IUIState
    {
        private const string SCORE_SAVE_PATH = "ScoreData.json";
        
        private readonly AdditionalPanelView _additionalPanelView;
        private readonly SoundPlayer _soundPlayer;
        private readonly FadeService _fadeService;
        private readonly Score _score;
        private readonly SaverJson _saverJson;
        private readonly float _fadeDuration;
        private IUIStateMachine _owner;
        
        public AdditionalPanelUIState(IServiceLocator serviceLocator, 
            AdditionalPanelView additionalPanelView, float fadeDuration)
        {
            serviceLocator.TryGetService(out _soundPlayer);
            serviceLocator.TryGetService(out _fadeService);
            serviceLocator.TryGetService(out _score);
            serviceLocator.TryGetService(out _saverJson);
            _additionalPanelView = additionalPanelView;
            _additionalPanelView.SetScore(_score.CurrentScore);
            _fadeDuration = fadeDuration;
        }

        public void SetOwner(IUIStateMachine owner)
        {
            _owner = owner;
        }

        public void Enter()
        {
            _additionalPanelView.CloseButtonSubscribe(FadeInPanel);
            _additionalPanelView.CollectButtonSubscribe(AddScore);
        }

        public void Exit()
        {
            _additionalPanelView.CloseButtonUnsubscribe(FadeInPanel);
            _additionalPanelView.CollectButtonUnsubscribe(AddScore);
        }

        private void FadeInPanel()
        {
            _soundPlayer?.PlayCloseSound();
            _fadeService?.FadeIn(_additionalPanelView.CanvasGroup,_fadeDuration,CloseAdditionalPanel);
        }

        private void CloseAdditionalPanel()
        {
            _saverJson.SaveScore(SCORE_SAVE_PATH);
            _additionalPanelView.ClosePanel();
            _owner.SwitchState<MainMenuUIState>();
        }

        private void AddScore()
        {
            _score.AddScore();
        }
    }
}