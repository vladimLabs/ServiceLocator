using AdditionalPanel;
using Audio;
using Core;
using UISwitchingSystem;

namespace MainMenu
{
    public class MainMenuUIState : IUIState
    {
        private readonly AdditionalPanelView _additionalPanelView;
        private readonly MainMenuView _mainMenuView;
        private readonly SoundPlayer _soundPlayer;
        private readonly FadeService _fadeService;
        private readonly float _fadeDuration;
        private IUIStateMachine _owner;

        public MainMenuUIState(IServiceLocator serviceLocator,AdditionalPanelView additionalPanelView, 
            MainMenuView mainMenuView, float fadeDuration)
        {
            serviceLocator.TryGetService(out _soundPlayer);
            serviceLocator.TryGetService(out _fadeService);
            _additionalPanelView = additionalPanelView;
            _mainMenuView = mainMenuView;
            _fadeDuration = fadeDuration;
        }
        
        public void SetOwner(IUIStateMachine owner)
        {
            _owner = owner;
        }
        
        public void Enter()
        {
            _mainMenuView.OpenButtonSubscribe(OpenAdditionalPanel);
        }
        
        public void Exit()
        {
            _mainMenuView.OpenButtonUnsubscribe(OpenAdditionalPanel);
        }
        
        private void OpenAdditionalPanel()
        {
            _additionalPanelView.OpenPanel();
            _owner.SwitchState<AdditionalPanelUIState>();
            _soundPlayer?.PlayOpenSound();
            _fadeService?.FadeOut(_additionalPanelView.CanvasGroup,_fadeDuration);
        }
    }
}