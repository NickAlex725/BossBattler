using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    //[SerializeField] private Unit _playerUnitPrefab;
    //[SerializeField] private Transform _playerUnitSpawnLocation;
    //[SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private GameHUD _gameHUD;
    [SerializeField] private InputBroadcaster _input;
    [SerializeField] private AudioManager _SFXManager;
    [SerializeField] private AudioSource _battleMusic;
    [SerializeField] private Paladin _paldin;
    [SerializeField] private Wizard _wizard;
    [SerializeField] private Archer _archer;
    [SerializeField] private DemonBoss _demonBoss;

    public float TapLimitDuration => _tapLimitDuration;

    //public Unit PlayerUnitPrefab => _playerUnitPrefab;
    //public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    //public UnitSpawner UnitSpawner => _unitSpawner;
    public GameHUD GameHUD => _gameHUD;
    public InputBroadcaster Input => _input;
    public AudioManager SFXManager => _SFXManager;
    public AudioSource BattleMusic => _battleMusic;
    public Paladin Paladin => _paldin;
    public Wizard Wizard => _wizard;
    public Archer Archer => _archer;
    public DemonBoss DemonBoss => _demonBoss;

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CompleteTurn(Unit character)
    {
        character.EndTurn();
    }
}
