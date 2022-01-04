/* ==============================================================================
* 功能描述：BuffDef  
* 创 建 者：Halo
* 创建日期：2022/1/3 16:14:54
* ==============================================================================*/
using System;
using System.Collections.Generic;

public enum BuffState
{
    None,
    Init,
    Delay,
    Start,
    Tick,
    End
}

public enum BuffType
{
    MoveSpeed = 10110,
    HPCure = 10100,
}

public static class BuffDef
{
    /// <summary>
    /// 逻辑帧的间隔
    /// </summary>
    public static int LogicFrameIntervelMs
    {
        get
        {
            return (int)(UnityEngine.Time.deltaTime * 1000);
        }
        private set { }
    }

    public static readonly int ForeverBuff = -1;
}