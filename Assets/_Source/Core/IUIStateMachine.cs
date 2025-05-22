namespace Core
{
    public interface IUIStateMachine
    {
        void SwitchState<T>() where T : IUIState;
    }
}