using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
    public void Deathball(Unit enemy)
    {
        enemy.TakeDamage(_strength);
        _anim.SetTrigger("Deathball");
    }
}
