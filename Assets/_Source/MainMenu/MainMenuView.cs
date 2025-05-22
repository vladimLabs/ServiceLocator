using System;
using Core;
using UISwitchingSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _openButton;

        public void OpenButtonSubscribe(UnityAction action)
        {
            _openButton.onClick.AddListener(action);
        }
    
        public void OpenButtonUnsubscribe(UnityAction action)
        {
            _openButton.onClick.RemoveListener(action);
        }
    }
}
