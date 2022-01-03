/* ==============================================================================
* 功能描述：BuffCfg  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:44:00
* ==============================================================================*/
using System;
using System.Collections.Generic;

/// <summary>
/// Buff的作用类型
/// </summary>
public enum BuffAttach
{
    None,
    Caster,
    Target,

    Indie,

    Bullet,
}

public class BuffCfg
{
    //public int BuffID;
    public BuffType BuffEnum;
    public string BuffName;
    public BuffAttach AttachType;
    /// <summary>
    /// 延时生效
    /// </summary>
    public int Delay;
    /// <summary>
    /// 生效时间
    /// </summary>
    public int Interval;
    /// <summary>
    /// 持续时间
    /// </summary>
    public int Duration;
}
