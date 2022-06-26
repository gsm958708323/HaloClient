using System;
using System.Collections.Generic;
using cfg.skill;
using cfg.unit;

public static class TargetHelper
{
    /// <summary>
    /// 查找距离自己最近的单位
    /// </summary>
    /// <param name="from"></param>
    /// <param name="targetCfg"></param>
    /// <returns></returns>
    public static List<Hero> FindTargetByRule(Hero self, TargetCfg cfg)
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
    /// 查找目标集合
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="cfg"></param>
    /// <returns></returns>
    static List<Hero> TryGetTargetList(Hero unit, TargetCfg cfg)
    {
        CampType targetCamp = cfg.TargetType == TargetType.Friend ? unit.GetMyCamp() : unit.GetOtherCamp();

        List<Hero> listAllUnit = new List<Hero>();
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
    /// 根据规则过滤目标集合
    /// </summary>
    /// <param name="unitList"></param>
    /// <param name="cfg"></param>
    /// <returns></returns>

    static List<Hero> FliterByRule(Hero self, List<Hero> unitList, TargetCfg cfg)
    {
        //判断查找目标是单人还是多人
        if (cfg.RuleType == TargetSelectRule.TargetClosestSingle)
        {
            return FliterByClosest(self, unitList, cfg);
        }
        return null;
    }

    static List<Hero> FliterByClosest(Hero self, List<Hero> unitList, TargetCfg cfg)
    {
        float minDis = int.MaxValue;
        Hero target = null;
        foreach (var unit in unitList)
        {
            if (unit.IsDead())
            {
                continue;
            }

            float sumRadius = self.boxRadius + unit.boxRadius;
            //两点之间距离减去半径和
            float dis = (self.MoveComp.Position - unit.MoveComp.Position).magnitude - sumRadius;
            if (dis < minDis)
            {
                target = unit;
                minDis = dis;
            }
        }
        UnityEngine.Debug.Log($"单人目标最短距离：{minDis} {target.HeroCfg.Name}");

        if (minDis < cfg.AttackDis)
        {
            return new List<Hero>() { target };
        }
        else
        {
            return null;
        }
    }
}
