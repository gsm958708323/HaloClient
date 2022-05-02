using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hero界面表现
/// 1.处理同步信息
/// 2.处理旋转信息
/// </summary>
public class HeroView : UnitView
{
    protected Hero hero;

    public override void LogicInit(Unit unit)
    {
        base.LogicInit(unit);
        hero = (Hero)unit;
    }

    private void Start()
    {
        //初始化位置和旋转
        gameObject.transform.position = hero.BornPos;
    }

    private void FixedUpdate()
    {
        var pos = hero.MoveComponent.Position;
        var dir = hero.MoveComponent.Direction;

        gameObject.transform.position = pos;
        //从当前朝向旋转到目标朝向
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, dir);
    }
}

