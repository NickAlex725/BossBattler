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

    protected Health _health;
    private bool _isDefending;
    public bool isAlive;
    public bool isTaunted;
    public bool isTurnComplete;

    private void Awake()
    {
        _health = GetComponent<Health>();
        isAlive = true;
        _anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _healthSlider.maxValue = _health.currentHealth;
        _healthSlider.value = _health.currentHealth;
    }

    public virtual void Attack(Unit target)
    {
        UnitUI.SetActive(false);
        target.TakeDamage(_strength);
        _anim.SetTrigger("Attacking");
    }

    public virtual void Defend()
    {
        UnitUI.SetActive(false);
        _defense = _defense * _defenseMultiplier;
        _isDefending = true;
        _anim.SetTrigger("Defending");
    }

    public void TakeDamage(int damage)
    {
        _healthSlider.value = _health.TakeDamage(damage);
        if(_health.currentHealth <= 0)
        {
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
        _defense = _defense / _defenseMultiplier;
    }
}
