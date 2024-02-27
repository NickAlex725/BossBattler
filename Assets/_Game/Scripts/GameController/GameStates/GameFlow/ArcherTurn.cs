using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTurn : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public ArcherTurn(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.Archer.isTurnComplete = false;
        _controller.Archer.UnitUI.SetActive(true);
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
        if (!_controller.DemonBoss.isAlive)
        {
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        else if (_controller.Archer.isTurnComplete)
        {
            _stateMachine.ChangeState(_stateMachine.EnemyTurnState);
            _controller.Archer.UnitUI.SetActive(false);
            _controller.Archer.isTurnComplete = false;
        }
    }
}
