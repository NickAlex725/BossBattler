using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
    public void Deathball(Unit enemy)
    {
        _SFXSource.PlayOneShot(_specialSFX);
        UnitUI.SetActive(false);
        enemy.TakeDamage(_strength);
        _anim.SetTrigger("Deathball");
    }
}
