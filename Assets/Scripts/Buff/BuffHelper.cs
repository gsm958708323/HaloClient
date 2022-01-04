/* ==============================================================================
* 功能描述：BuffHelper  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:54:04
* ==============================================================================*/
using System;
using System.Collections.Generic;

public static class BuffHelper
{
    public static BuffCfg GetBuffCfg(BuffType buffEnum)
    {
        BuffCfg buffCfg = null;
        if (buffEnum == BuffType.MoveSpeed)
        {
            buffCfg = new MoveSpeedBuffCfg
            {
                BuffEnum = buffEnum,
                BuffName = "加速",

                AttachType = BuffAttach.Caster,

                Delay = 1000,
                Interval = 1000,
                Duration = -1,

                //专有属性，提速30%
                AddPct = 30,
            };
        }
        else
        {
            UnityEngine.Debug.LogError($"buff配置不存在：{buffEnum}");

        }
        return buffCfg;
    }

    public static Buff CreateBuff(Unit from, BuffType buffEnum, Unit to=null, object[] args=null)
    {
        Buff buff = null;
        if (buffEnum == BuffType.MoveSpeed)
        {
            buff = new MoveSpeedBuff(from, to, buffEnum, args);
        }
        else
        {
            UnityEngine.Debug.LogError($"未定义buff类：{buffEnum}");
        }
        return buff;
    }
}
