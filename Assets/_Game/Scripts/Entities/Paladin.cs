using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Unit
{

    public void Taunt(Unit enemy)
    {
        _SFXSource.PlayOneShot(_specialSFX);
        UnitUI.SetActive(false);
        enemy.isTaunted = true;
        _anim.SetTrigger("Taunting");
    }
}
