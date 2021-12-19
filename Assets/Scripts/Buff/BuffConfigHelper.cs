/* ==============================================================================
* 功能描述：BuffConfigHelper  
* 创 建 者：Halo
* 创建日期：2021/12/19 16:30:43
* ==============================================================================*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffDef
{
    public static readonly int Xijia = 1;
}

public class BuffConfigHelper
{
    public static Buff GetBuff(int id)
    {
        Buff buff = null;
        if (id == BuffDef.Xijia)
        {
            buff = new Buff();
            buff.StartTiming = TimingEnum.ActionStart;
            buff.EndTiming = TimingEnum.ActionEnd;
            buff.AddEffect(new TestEffect());
        }
        else
        {
            Debug.LogError($"获取buff错误：{id}");
        }

        return buff;
    }
}
