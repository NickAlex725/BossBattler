using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public void PiercingShot(Unit enemy)
    {
        enemy.TakeDamage(_strength);
        _anim.SetTrigger("PS");
    }
}
