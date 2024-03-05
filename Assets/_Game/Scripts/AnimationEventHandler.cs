using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [SerializeField] GameController _controller;
    [SerializeField] GameFSM _stateMachine;
    [SerializeField] GameObject _winText;
    [SerializeField] Unit _character;

    public void EndUnitTurn()
    {
        _controller.CompleteTurn(_character);
    }

    public void SwitchToWinState()
    {
        _stateMachine.ChangeState(_stateMachine.WinState);
        _winText.SetActive(true);
    }
}
