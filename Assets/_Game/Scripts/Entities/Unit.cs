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
    [SerializeField] protected Slider _healthSlider;
    [SerializeField] protected Animator _anim;
    [SerializeField] public GameObject UnitUI;

    protected Health _health;
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
        target.TakeDamage(_strength);
    }

    public virtual void Defend()
    {
        _defense = _defense * 1.5f;
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
}
