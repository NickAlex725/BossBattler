using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTurn : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public WizardTurn(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.Wizard.ResetDefense();
        _controller.Wizard.isTurnComplete = false;
        _controller.Wizard.UnitUI.SetActive(true);
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
        if (_controller.Wizard.isTurnComplete)
        {
            if (_controller.Archer.isAlive)
            {
                _stateMachine.ChangeState(_stateMachine.ArcherTurn);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.EnemyTurnState);
            }
            _controller.Wizard.UnitUI.SetActive(false);
            _controller.Wizard.isTurnComplete = false;
        }
    }
}
