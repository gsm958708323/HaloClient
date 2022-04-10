using System;
using System.Collections.Generic;
using cfg.unit;
using UnityEngine;

public enum UnitState
{
    Alive,
    Dead,
}

public class Unit
{
    public CampType campType;
    public UnitType unitType;
    public UnitState unitState;
    public int boxRadius;
    public Vector3 Pos;

    public bool IsDead()
    {
        return unitState == UnitState.Dead;
    }

    public CampType GetMyCamp()
    {
        return campType;
    }

    public CampType GetOtherCamp()
    {
        CampType otherCamp;
        otherCamp = campType == CampType.Red ? CampType.Blue : CampType.Red;
        return otherCamp;
    }
}
