namespace Project.Scripts.StateMachine
{
    public interface IState
    {
        public void Enter(IStateMachine stateMachine);
    }
}