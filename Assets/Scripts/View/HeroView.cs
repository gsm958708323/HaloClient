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

    Animation anim;

    /// <summary>
    /// 主摄像机的位置
    /// </summary>
    public Transform cameraTrans;

    /// <summary>
    /// 记录初始速度
    /// </summary>
    float moveSpeedBase;

    /// <summary>
    /// 当前预测帧
    /// </summary>
    int predictCount = 0;

    int atkCount = 0;

    private void Awake()
    {
        EventDispatcher.instance.Regist<int, UIMoveState>((int)EventDef.UIMoveStateChange, OnMoveStateChange);
        EventDispatcher.instance.Regist<int>((int)EventDef.HeroDeath, OnHeroDeath);
    }

    private void OnHeroDeath(int index)
    {
        PlayAnim("death");
    }

    private void OnMoveStateChange(int netIndex, UIMoveState state)
    {
        if (hero.NetIndex != netIndex)
        {
            return;
        }

        if (state == UIMoveState.Press)
        {
            PlayAnim("walk");
        }
        else
        {
            PlayAnim("free");
        }
    }

    public override void LogicInit(Unit unit)
    {
        base.LogicInit(unit);
        hero = (Hero)unit;

        anim = GetComponentInChildren<Animation>();
        moveSpeedBase = hero.MoveComp.MoveSpeed;
    }

    private void Start()
    {
        //初始化位置和旋转
        gameObject.transform.position = hero.BornPos;
    }

    private void Update()
    {
        var pos = hero.MoveComp.Position;
        var dir = hero.MoveComp.Direction;

        // 这里为了让客户端平滑进行，需要用到update来更新Time.deltaTime不断刷新，不能只更新变化的数据
        if (pos != Vector3.zero)
        {
            UpdatePos(pos);
        }

        if (dir != Vector3.zero)
        {
            UpdateDir(dir);
        }
    }

    public void SetMainCamera(Transform trans)
    {
        cameraTrans = trans;
    }

    public override void PlayAnim(string name)
    {
        base.PlayAnim(name);

        if (name == "walk")
        {
            //速度越大，动画过渡时间越小
            float moveRate = hero.MoveComp.MoveSpeed / moveSpeedBase;
            anim[name].speed = moveRate;
            anim.CrossFade(name, GlobalDef.Instance.AnimFade / moveRate);
        }
        else if (name == "atk")
        {
            atkCount++;
            if (atkCount > 3)
            {
                atkCount = 1;
            }

            anim.CrossFade($"atk{atkCount}", GlobalDef.Instance.AnimFade);
        }
        else
        {
            anim.CrossFade(name, GlobalDef.Instance.AnimFade);
        }
    }

    public void UpdateDir(Vector3 dir)
    {
        //LogHelper.Log($"更新玩家朝向 {dir.ToString()}");

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

    void UpdatePos(Vector3 pos)
    {
        //LogHelper.Log($"更新玩家位置：{pos.ToString()}");
        if (!GlobalDef.Instance.IsOpenPosPredict)
        {
            SetViewPos(pos);
            return;
        }

        //逻辑位置发生变化，以逻辑位置为准
        if (hero.MoveComp.isPosChange)
        {
            SetViewPos(pos);
            //SetViewDir(dir);

            hero.MoveComp.isPosChange = false;
            predictCount = 0;

            //Debug.LogError($"逻辑位置变化：{pos.x} {pos.z}");
        }
        else
        {
            if (predictCount > GlobalDef.Instance.PredictMaxFrame)
                return;

            //预测位置 = 方向 * 速度 * 时间
            Vector3 predictPos = hero.MoveComp.Direction * hero.MoveComp.MoveSpeed * Time.deltaTime;
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
            transform.position = pos;
        }

        if (cameraTrans != null)
        {
            cameraTrans.position = Vector3.Lerp(cameraTrans.position, gameObject.transform.position, Time.deltaTime * GlobalDef.Instance.CameraRate);
        }
    }
}

