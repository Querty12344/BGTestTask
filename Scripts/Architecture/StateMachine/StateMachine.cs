using System;
using System.Collections.Generic;
using Project.Scripts.StateMachine.States;

namespace Project.Scripts.StateMachine
{
    class StateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public StateMachine(BootstrapState bootstrapState, GameLoopState gameLoopState, LoadLevelState loadLevelState)
        {
            _states.Add(typeof(BootstrapState), bootstrapState);
            _states.Add(typeof(GameLoopState), gameLoopState);
            _states.Add(typeof(LoadLevelState), loadLevelState);
        }

        public void EnterState<TState>() where TState : IState
        {
            _states[typeof(TState)].Enter(this);
        }
    }
}