namespace Core
{
    public interface IUIState
    {
        void SetOwner(IUIStateMachine owner);
        void Enter();
        void Exit();
    }
}
