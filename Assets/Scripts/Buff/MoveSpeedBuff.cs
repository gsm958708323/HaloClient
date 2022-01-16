/* ==============================================================================
* 功能描述：MoveSpeedBuff  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:58:15
* ==============================================================================*/
using System;
using System.Collections.Generic;
using cfg.buff;

[BuffType(BuffType.MoveSpeed)]
public class MoveSpeedBuff : Buff
{
    private int speedChange;
    private Hero target;

    public MoveSpeedBuff(int ID, Hero from, Hero to, object[] args)
        : base(ID, from, to, args)
    {

    }

    public override void Start()
    {
        base.Start();

        target = (Cfg.Attach == BuffAttach.Target) ? to : from;
        speedChange = target.GetSpeed() * Cfg.Param / 100;

        target.ModifySpeed(speedChange);
    }

    public override void End()
    {
        base.End();
        target.ModifySpeed(-speedChange);
    }
}
