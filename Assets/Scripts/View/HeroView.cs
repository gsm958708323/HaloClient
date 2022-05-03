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

    /// <summary>
    /// 当前预测帧
    /// </summary>
    int predictCount = 0;

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

    private void Update()
    {
        var pos = hero.MoveComponent.Position;
        var dir = hero.MoveComponent.Direction;

        if (pos == Vector3.zero)
            return;

        UpdatePos(pos);

        //gameObject.transform.position = pos;
        //从当前朝向旋转到目标朝向
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, dir);
    }

    void UpdatePos(Vector3 pos)
    {
        if (!GlobalDef.Instance.IsOpenPosPredict)
        {
            SetViewPos(pos);
            return;
        }

        //判断逻辑位置是否变化
        if (hero.MoveComponent.isPosChange)
        {
            SetViewPos(pos);

            hero.MoveComponent.isPosChange = false;
            predictCount = 0;

            //Debug.LogError($"逻辑位置变化：{pos.x} {pos.z}");
        }
        else
        {
            if (predictCount > GlobalDef.Instance.PredictMaxFrame)
                return;

            //预测位置 = 方向 * 速度 * 时间
            Vector3 predictPos = hero.MoveComponent.Direction * hero.MoveComponent.MoveSpeed * Time.deltaTime;
            AddViewPos(predictPos);
            //print($"预测位置变化：{predictPos.x} {predictPos.z}");

            predictCount++;
        }
    }

    /// <summary>
    /// 增加表现层的位置
    /// </summary>
    /// <param name="pos"></param>
    void AddViewPos(Vector3 pos)
    {
        SetViewPos(gameObject.transform.position + pos);
    }

    void SetViewPos(Vector3 pos)
    {
        if (GlobalDef.Instance.IsOpenPosPredict)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * GlobalDef.Instance.SmoothMoveRate);
        }
        else
        {
            gameObject.transform.position = pos;
        }
    }
}

