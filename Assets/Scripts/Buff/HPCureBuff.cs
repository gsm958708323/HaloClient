/* ==============================================================================
* 功能描述：HPCureBuffCfg  
* 创 建 者：Halo
* 创建日期：2022/1/4 22:59:22
* ==============================================================================*/
using System;
using System.Collections.Generic;
using cfg.buff;

[BuffType(BuffType.HPCure)]
public class HPCureBuff : Buff
{
    private int change;

    public HPCureBuff(int ID, Hero from, Hero to, object[] args)
        : base(ID, from, to, args)
    {

    }

    public override void Start()
    {
        base.Start();
        change = from.HeroCfg.Hp * (int)Cfg.Param[0] / 100;
    }

    public override void Tick()
    {
        base.Tick();
        from.AddHp(change);
    }
}