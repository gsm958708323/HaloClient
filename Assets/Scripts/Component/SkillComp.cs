using System;
using System.Collections.Generic;

public class SkillComp : Ilogic
{
    List<Skill> skillList;
    Hero owner;

    public SkillComp(Hero hero)
    {
        this.owner = hero;
    }

    public void UseSkill(int index)
    {
        if (index >= 0 && index < skillList.Count)
        {
            //技能结束时，才能释放下一个技能
            Skill skill = skillList[index];
            if (skill.GetState() == SkillState.End)
            {
                skill.Release();
            }
        }
        else
        {
            LogHelper.LogError($"使用技能不存在 {index}");
        }
    }

    Skill TryGetSkill(int id)
    {
        foreach (Skill skill in skillList)
        {
            if (skill.ID == id)
            {
                return skill;
            }
        }
        return null;
    }

    /// <summary>
    /// 替换技能数据
    /// </summary>
    /// <param name="fromId"></param>
    /// <param name="toId"></param>
    public void ModifySkill(int fromId, int toId)
    {
        var fromSkill = TryGetSkill(fromId);
        if (fromSkill == null)
        {
            LogHelper.LogError($"未找到此技能:{fromId}");
            return;
        }

        fromSkill.ModifyCfg(toId);
    }

    public void LogicStart()
    {
        skillList = new List<Skill>();
        //初始化主动技能
        foreach (int id in owner.HeroCfg.ActiveSkill)
        {
            var skill = new Skill(id, owner);
            skillList.Add(skill);
        }
    }

    public void LogicEnd()
    {
        skillList = null;
        owner = null;
    }

    public void LogicTick()
    {
    }

    /// <summary>
    /// 技能伤害计算
    /// </summary>
    public void GetDamage(cfg.skill.SkillCfg cfg)
    {
        int damage = cfg.Damage;
        if (damage > 0)
        {
            owner.ReduceHp(damage);
        }
    }
}

