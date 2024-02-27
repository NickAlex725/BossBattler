using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public LoseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        _controller.SFXManager.PlayLoseAudio();
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
    }
}
