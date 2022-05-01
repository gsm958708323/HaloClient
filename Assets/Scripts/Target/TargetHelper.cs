using System;
using System.Collections.Generic;
using cfg.skill;
using cfg.unit;

public static class TargetHelper
{
    public static TargetCfg GetTargetCfg(int id)
    {
        var cfg = ConfigMgr.Instance.GetTables().TbTarget.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到TargetCfg：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
    }

    /// <summary>
    /// 查找目标集合
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="cfg"></param>
    /// <returns></returns>
    static List<Unit> TryGetTargetList(Unit unit, TargetCfg cfg)
    {
        CampType targetCamp = cfg.TargetType == TargetType.Friend ? unit.GetMyCamp() : unit.GetOtherCamp();

        List<Unit> listAllUnit = new List<Unit>();
        foreach (UnitType unitType in cfg.UnitType)
        {
            var unitList = FightMgr.Instance.TryGetTargetList(targetCamp, unitType);
            if (unitList != null)
            {
                listAllUnit.AddRange(unitList);
            }
        }

        if (listAllUnit.Count == 0)
        {
            return null;
        }
        else
        {
            return listAllUnit;
        }
    }

    /// <summary>
    /// 查找距离自己最近的单位
    /// </summary>
    /// <param name="from"></param>
    /// <param name="targetCfg"></param>
    /// <returns></returns>
    public static List<Unit> FindTargetByRule(Unit self, TargetCfg cfg)
    {
        var unitList = TryGetTargetList(self, cfg);
        if (unitList == null)
        {
            return null;
        }


        unitList = FliterByRule(self, unitList, cfg);
        if (unitList == null)
        {
            return null;
        }
        return unitList;
    }

    /// <summary>
    /// 根据规则过滤目标集合
    /// </summary>
    /// <param name="unitList"></param>
    /// <param name="cfg"></param>
    /// <returns></returns>

    static List<Unit> FliterByRule(Unit self, List<Unit> unitList, TargetCfg cfg)
    {
        //判断查找目标是单人还是多人
        if (cfg.RuleType == TargetSelectRule.TargetClosestSingle)
        {
            return FliterByClosest(self, unitList, cfg);
        }
        return null;
    }

    static List<Unit> FliterByClosest(Unit self, List<Unit> unitList, TargetCfg cfg)
    {
        float minDis = int.MaxValue;
        Unit target = null;
        foreach (var unit in unitList)
        {
            if (unit.IsDead())
            {
                continue;
            }

            int sumRadius = self.boxRadius + unit.boxRadius;
            //两点之间距离减去半径和
            float dis = (self.Pos - unit.Pos).magnitude - sumRadius;
            if (dis < minDis)
            {
                target = unit;
                minDis = dis;
            }
        }
        if (target == null)
            return null;
        else
            return new List<Unit>() { target };
    }
}
