using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    [SerializeField] float _defenseLowerMult = 2;
    public void PiercingShot(Unit enemy)
    {
        _SFXSource.PlayOneShot(_specialSFX);
        UnitUI.SetActive(false);
        enemy.TakeDamage(_strength);
        //enemy.lowerDefense(_defenseLowerMult);
        _anim.SetTrigger("PS");
    }
}
