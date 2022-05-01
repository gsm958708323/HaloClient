using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unit界面表现
/// 1.处理同步信息
/// 2.处理旋转信息
/// </summary>
public abstract class UnitView : MonoBehaviour
{
    protected Unit unitData;
    public virtual void LogicInit(Unit unit)
    {
        unitData = unit;
    }

    private void Start()
    {
        //初始化位置和旋转
        gameObject.transform.position = unitData.BornPos;
    }
}

