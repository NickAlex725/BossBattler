using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Unit Spawn(Unit unitPrefab, Transform location)
    {
        //spawn and hold on to the component
        Unit newUnit = Instantiate(unitPrefab, location.position, location.rotation);
        //TODO do set up here if needed, spawn effects, ect.
        return newUnit;
    }
}
