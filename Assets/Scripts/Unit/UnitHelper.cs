/* ==============================================================================
* 功能描述：UnitHelper  
* 创 建 者：Halo
* 创建日期：2022/1/3 20:13:04
* ==============================================================================*/
using System;
using System.Collections.Generic;

public enum UnitType
{
    Yase,
    Houyi,
}

public static class UnitHelper
{
    public static UnitCfg GetUnitCfg(UnitType type)
    {
        UnitCfg unitCfg = null;
        if (type == UnitType.Yase)
        {
            unitCfg = new UnitCfg
            {
                UnitType = type,
                Name = "亚瑟",
                Speed = 10,
                Hp = 100,
                PassiveSkill = new BuffType[] { BuffType.HPCure },
            };
        }
        else
        {
            UnityEngine.Debug.LogError($"未定义Unit类：{type}");
        }
        return unitCfg;
    }
}
