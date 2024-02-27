using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Unit
{
    public void Taunt(Unit enemy)
    {
        enemy.isTaunted = true;
    }
}
