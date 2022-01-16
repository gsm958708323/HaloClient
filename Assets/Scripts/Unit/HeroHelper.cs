/* ==============================================================================
* 功能描述：UnitHelper  
* 创 建 者：Halo
* 创建日期：2022/1/3 20:13:04
* ==============================================================================*/
using System;
using System.Collections.Generic;
using cfg.unit;

public enum UnitType
{
    Yase,
    Houyi,
}

public static class HeroHelper
{
    public static HeroCfg GetHeroCfg(int id)
    {
        var cfg = ConfigMgr.Instance.GetTables().TbHero.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到Hero：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
    }
}
