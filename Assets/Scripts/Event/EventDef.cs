/* ==============================================================================
* 功能描述：EventDef  
* 创 建 者：Halo
* 创建日期：2021/12/19 17:25:51
* ==============================================================================*/
using System;
using System.Collections.Generic;

//public class EventDef
//{
//    public static readonly int ActionStart = 1;
//    public static readonly int ActionEnd = 2;
//}

public enum EventDef
{
    /// <summary>
    /// 玩家移动输入
    /// </summary>
    InputMoveEvent = 1,
    /// <summary>
    /// 玩家移动状态变化
    /// </summary>
    UIMoveStateChange = 2,

    HeroDeath = 3,
}
