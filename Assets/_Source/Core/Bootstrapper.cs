using AdditionalPanel;
using Audio;
using MainMenu;
using SaveSystem;
using ScoreSystem;
using UISwitchingSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string SCORE_SAVE_PATH = "ScoreData.json";
        
        [SerializeField] private AdditionalPanelView _additionalPanelView;
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private AudioSource _openUISoundSource;
        [SerializeField] private AudioSource _closeUISoundSource;
        
        private IUIState[] _uiStates;
        private UISwitcher _uiSwitcher;
        private IServiceLocator _serviceLocator;
        private Score _score;
        private SoundPlayer _soundPlayer;
        private FadeService _fadeService;
        private SaverJson _saverJson;
        private SaverPlayerPrefs _saverPlayerPrefs;
        
        private void Awake()
        {
            _score = new Score(_additionalPanelView);
            _soundPlayer = new SoundPlayer(_openUISoundSource, _closeUISoundSource);
            _fadeService = new FadeService();
            _saverJson = new SaverJson(_score);
            _saverPlayerPrefs = new SaverPlayerPrefs(_score);
            
            _score.SetScore(_saverJson.LoadScore(SCORE_SAVE_PATH));
            
            IService[] services =
            {
                _soundPlayer,
                _fadeService,
                _saverJson,
                _saverPlayerPrefs,
                _score
            };
            
            _serviceLocator = new ServiceLocator(services);
            
            _uiStates = new IUIState[]
            {
                new AdditionalPanelUIState(_serviceLocator, _additionalPanelView, 0.5f),
                new MainMenuUIState(_serviceLocator, _additionalPanelView, _mainMenuView, 0.5f)
            };

            _uiSwitcher = new UISwitcher(_uiStates);
            _uiSwitcher.SwitchState<MainMenuUIState>();
        }
    }
}