﻿using System;
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
    public CampType CampType;
    public Vector3 BornPos;
    public bool IsLocal;

    public UnitType UnitType;
    public UnitState unitState;
    public int boxRadius;

    public Unit(UnitData data)
    {
        BornPos = data.BornPos;
        CampType = data.CampType;
        IsLocal = data.IsLocal;
    }

    public bool IsDead()
    {
        return unitState == UnitState.Dead;
    }

    public CampType GetMyCamp()
    {
        return CampType;
    }

    public CampType GetOtherCamp()
    {
        CampType otherCamp;
        otherCamp = CampType == CampType.Red ? CampType.Blue : CampType.Red;
        return otherCamp;
    }
}
