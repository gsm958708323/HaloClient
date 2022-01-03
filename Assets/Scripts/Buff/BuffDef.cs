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
}

public class BuffDef
{
    public const int LogicFrameIntervelMs = 1;
}