/* ==============================================================================
* 功能描述：BuffHelper  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:54:04
* ==============================================================================*/
using System;
using System.Collections.Generic;

public static class BuffHelper
{
    public static BuffCfg GetBuffCfg(BuffType type)
    {
        BuffCfg buffCfg = null;
        if (type == BuffType.MoveSpeed)
        {
            buffCfg = new MoveSpeedBuffCfg
            {
                BuffEnum = type,
                BuffName = "加速",

                AttachType = BuffAttach.Caster,

                Delay = 1000,
                Interval = 1000,
                Duration = -1,

                //专有属性，提速30%
                AddPct = 30,
            };
        }
        else if (type == BuffType.HPCure)
        {
            buffCfg = new HPCureBuffCfg
            {
                BuffEnum = type,
                BuffName = "被动治疗",

                AttachType = BuffAttach.Caster,

                Delay = 0,
                Interval = 2000,
                Duration = -1,

                //每秒回血2%
                AddPct = 2,
            };
        }
        else
        {
            UnityEngine.Debug.LogError($"buff配置不存在：{type}");

        }
        return buffCfg;
    }

    public static Buff CreateBuff(Unit from, BuffType type, Unit to = null, object[] args = null)
    {
        Buff buff = null;
        if (type == BuffType.MoveSpeed)
        {
            buff = new MoveSpeedBuff(from, to, type, args);
        }
        else if (type == BuffType.HPCure)
        {
            buff = new HPCureBuff(from, to, type, args);
        }
        else
        {
            UnityEngine.Debug.LogError($"未定义buff类：{type}");
        }
        return buff;
    }
}
