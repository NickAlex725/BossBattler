using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : Unit
{
    [SerializeField] private Unit[] heros;

    public override void Attack(Unit target)
    {
        _SFXSource.PlayOneShot(_attackSFX);
        if(!isTaunted)
        {
            target = heros[Random.Range(0, 3)];
            if(!target.isAlive)
            {
                Attack(target);
            }
            target.TakeDamage(_strength);
            _anim.SetTrigger("Attacking");
        }
        else
        {
            target.TakeDamage(_strength);
            _anim.SetTrigger("Attacking");
            isTaunted = false;
        }
    }
}
