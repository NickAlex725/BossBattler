using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    //state variables here
    public GameSetupState SetupState { get; private set; }
    public PaladinTurn PaladinTurn { get; private set; }
    public WizardTurn WizardTurn { get; private set; }
    public ArcherTurn ArcherTurn { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }
    public WinState WinState { get; private set; }
    public LoseState LoseState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        //state instantiation here
        SetupState = new GameSetupState(this, _controller);
        PaladinTurn = new PaladinTurn(this, _controller);
        WizardTurn = new WizardTurn(this, _controller);
        ArcherTurn = new ArcherTurn(this, _controller);
        EnemyTurnState = new EnemyTurnState(this, _controller);
        WinState = new WinState(this, _controller);
        LoseState = new LoseState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
