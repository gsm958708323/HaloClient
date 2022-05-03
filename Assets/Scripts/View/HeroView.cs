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

        UpdatePos(pos, dir);
        UpdateDir(dir);
    }

    private void UpdateDir(Vector3 dir)
    {
        if (!GlobalDef.Instance.IsOpenPosPredict)
        {
            SetViewDir(dir);
            return;
        }

        //根据当前旋转角度的大小，获得一个调节值。角度越大，就需要越快平滑到目标dir
        float angle = Vector3.Angle(transform.forward, dir);
        float angleRate = (angle / 180) * GlobalDef.Instance.SmoothDirRate * Time.deltaTime;

        Vector3 smoothDir = Vector3.Lerp(transform.forward, dir, angleRate);
        SetViewDir(smoothDir);
    }

    void UpdatePos(Vector3 pos, Vector3 dir)
    {
        if (!GlobalDef.Instance.IsOpenPosPredict)
        {
            SetViewPos(pos);
            return;
        }

        //逻辑位置发生变化，以逻辑位置为准
        if (hero.MoveComponent.isPosChange)
        {
            SetViewPos(pos);
            //SetViewDir(dir);

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

            //var temp = predictPos + transform.position;
            //print($"预测位置变化：{temp.x} {temp.z}");

            predictCount++;
        }
    }

    /// <summary>
    /// 设置表现层的朝向
    /// </summary>
    /// <param name="dir"></param>
    void SetViewDir(Vector3 dir)
    {
        //从当前朝向旋转到目标朝向
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, dir);
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

