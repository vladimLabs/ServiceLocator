using System;
using System.Collections.Generic;
using Core;

namespace UISwitchingSystem
{
    public class UISwitcher: IUIStateMachine
    {
        private readonly Dictionary<Type,IUIState> _uiStates;
        private IUIState _currentState;
        
        public UISwitcher(IEnumerable<IUIState> uiStates)
        {
            _uiStates = new Dictionary<Type, IUIState>();
            foreach (var state in uiStates)
            {
                _uiStates.Add(state.GetType(),state);
            }
        }
        
        public void SwitchState<T>() where T:IUIState
        {
            _currentState?.Exit();
            _currentState = _uiStates[typeof(T)];
            _currentState.SetOwner(this);
            _currentState.Enter();
        }
    }
}
