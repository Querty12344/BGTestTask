using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Architecture.Bootstrap;
using Project.Scripts.StateMachine;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour, ICoroutineRunner
{
    private IStateMachine _stateMachine;

    [Inject]
    public void Construct(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        _stateMachine.EnterState<BootstrapState>();
    }
}