/* ==============================================================================
* 功能描述：BuffDef  
* 创 建 者：Halo
* 创建日期：2022/1/3 16:14:54
* ==============================================================================*/
using System;
using cfg.buff;
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

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class BuffTypeAttribute : Attribute
{
    public BuffType BuffType { get; set; }
    public BuffTypeAttribute(BuffType type)
    {
        this.BuffType = type;
    }
}