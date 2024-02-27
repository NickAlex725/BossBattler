using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public EnemyTurnState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.DemonBoss.isTurnComplete = false;
        _controller.GameHUD.UpdateStateText(_stateMachine.CurrentState);
        _controller.DemonBoss.Attack(_controller.Paladin);
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
        if(_controller.DemonBoss.isTurnComplete)
        {
            if (_controller.Paladin.isAlive)
            {
                _stateMachine.ChangeState(_stateMachine.PaladinTurn);
            }
            else if (_controller.Wizard.isAlive)
            {
                _stateMachine.ChangeState(_stateMachine.WizardTurn);
            }
            else if (_controller.Archer.isAlive)
            {
                _stateMachine.ChangeState(_stateMachine.ArcherTurn);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.LoseState);
            }
        }
    }
}
