using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    [SerializeField] protected int _strength;
    [SerializeField] protected int _magicAttack;
    [SerializeField] protected float _defense;
    [SerializeField] protected float _defenseMultiplier;
    [SerializeField] protected Slider _healthSlider;
    [SerializeField] protected Animator _anim;
    [SerializeField] public GameObject UnitUI;

    [Header("SFX")]
    protected AudioSource _SFXSource;
    [SerializeField] protected AudioClip _attackSFX;
    [SerializeField] protected AudioClip _defendSFX;
    [SerializeField] protected AudioClip _specialSFX;
    [SerializeField] protected AudioClip _deathSFX;

    protected Health _health;
    protected bool _isDefLowered;
    protected bool _isDefIncreased;
    public bool isAlive;
    public bool isTaunted;
    public bool isTurnComplete;

    private void Awake()
    {
        isAlive = true;
        _health = GetComponent<Health>();
        _anim = GetComponentInChildren<Animator>();
        _SFXSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _healthSlider.maxValue = _health.currentHealth;
        _healthSlider.value = _health.currentHealth;
    }

    public virtual void Attack(Unit target)
    {
        _SFXSource.PlayOneShot(_attackSFX);
        UnitUI.SetActive(false);
        target.TakeDamage(_strength);
        _anim.SetTrigger("Attacking");
    }

    public virtual void Defend()
    {
        _SFXSource.PlayOneShot(_defendSFX);
        UnitUI.SetActive(false);
        _defense = _defense * _defenseMultiplier;
        _anim.SetTrigger("Defending");
        _isDefIncreased = true;
    }

    public void TakeDamage(float damage)
    {
        damage -= _defense;
        _healthSlider.value = _health.TakeDamage(damage);
        if(_health.currentHealth <= 0)
        {
            _SFXSource.PlayOneShot(_deathSFX);
            isAlive = false;
            _anim.SetBool("isAlive", isAlive);
        }
    }

    public void EndTurn()
    {
        isTurnComplete = true;
    }

    public void ResetDefense()
    {
        if(_isDefIncreased)
        {
            _defense = _defense / _defenseMultiplier;
            _isDefIncreased = false;
        }
        else if(_isDefLowered)
        {
            _defense = _defense * 2;
            _isDefLowered = false;
        }
    }

    public void lowerDefense(float lowerMult)
    {
        _defense = _defense / lowerMult;
        _isDefLowered = true;
    }
}
