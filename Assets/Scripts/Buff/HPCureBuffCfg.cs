/* ==============================================================================
* 功能描述：HPCureBuffCfg  
* 创 建 者：Halo
* 创建日期：2022/1/4 22:59:22
* ==============================================================================*/
using System;
using System.Collections.Generic;

public class HPCureBuffCfg : BuffCfg
{
    public int AddPct;
}

public class HPCureBuff : Buff
{
    private int change;

    public HPCureBuff(Unit from, Unit to, BuffType buffEnum, object[] args)
        : base(from, to, buffEnum, args)
    {

    }

    public override void Start()
    {
        base.Start();
        HPCureBuffCfg hpCfg = (HPCureBuffCfg)Cfg;
        change = from.Cfg.Hp * hpCfg.AddPct / 100;
    }

    public override void Tick()
    {
        base.Tick();
        from.ModifyHp(change);
    }
}