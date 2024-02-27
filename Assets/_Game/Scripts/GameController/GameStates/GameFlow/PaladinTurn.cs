using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinTurn : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public PaladinTurn(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.Paladin.ResetDefense();
        _controller.Paladin.isTurnComplete = false;
        _controller.Paladin.UnitUI.SetActive(true);
        _controller.GameHUD.UpdateStateText(_stateMachine.CurrentState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if(!_controller.DemonBoss.isAlive)
        {
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        else if(_controller.Paladin.isTurnComplete)
        {
            _stateMachine.ChangeState(_stateMachine.WizardTurn);
            _controller.Paladin.UnitUI.SetActive(true);
            _controller.Paladin.isTurnComplete = false;
        }
    }
}