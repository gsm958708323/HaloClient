/* ==============================================================================
* 功能描述：MoveSpeedBuff  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:58:15
* ==============================================================================*/
using System;
using System.Collections.Generic;

public class MoveSpeedBuffCfg : BuffCfg
{
    /// <summary>
    /// 增加速度百分比
    /// </summary>
    public int AddPct;
}

public class MoveSpeedBuff : Buff
{
    private int speedChange;
    private Unit target;

    public MoveSpeedBuff(Unit from, Unit to, BuffType buffEnum, object[] args)
        : base(from, to, buffEnum, args)
    {

    }

    public override void Init()
    {
        MoveSpeedBuffCfg speedCfg = (MoveSpeedBuffCfg)Cfg;

        target = (speedCfg.AttachType == BuffAttach.Target) ? to : from;
        speedChange = target.GetSpeed() * speedCfg.AddPct / 100;
    
        // todo 生命周期控制
        base.Init();
    }


    public override void Start()
    {
        base.Start();
        target.ModifySpeed(speedChange);
    }

    public override void End()
    {
        base.End();
        target.ModifySpeed(-speedChange);
    }
}
