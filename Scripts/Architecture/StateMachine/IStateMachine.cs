namespace Project.Scripts.StateMachine
{
    public interface IStateMachine
    {
        public void EnterState<TState>() where TState : IState;
    }
}