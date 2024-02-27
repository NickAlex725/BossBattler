using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : Unit
{
    [SerializeField] private Unit[] heros;

    public override void Attack(Unit target)
    {
        if(!isTaunted)
        {
            target = heros[Random.Range(0, 3)];
            if(!target.isAlive)
            {
                Attack(target);
            }
            target.TakeDamage(_strength);
            _anim.SetTrigger("Attacking");
            isTurnComplete = true;
        }
        else
        {
            target.TakeDamage(_strength);
            _anim.SetTrigger("Attacking");
            isTurnComplete = true;
            isTaunted = false;
        }
    }
}
