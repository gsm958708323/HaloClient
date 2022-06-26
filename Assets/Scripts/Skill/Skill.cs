/* ==============================================================================
* 功能描述：Skill 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using cfg.skill;
using System.Collections;
using System.Collections.Generic;

public enum SkillState
{
    Start,
    Work,
    End,
}

public class Skill
{
    SkillState state = SkillState.End;
    SkillCfg cfg;
    TargetCfg targetCfg;
    int id;
    Hero owner;

    public Skill(int id, Hero hero)
    {
        this.id = id;
        this.owner = hero;
        cfg = ConfigMgr.Instance.GetSkillCfg(id);
    }

    public SkillState GetState()
    {
        return state;
    }
    public void SetState(SkillState state)
    {
        this.state = state;
    }

    /// <summary>
    /// 释放技能
    /// </summary>
    public void Release()
    {
        //查找目标
        var targetCfg = ConfigMgr.Instance.GetTargetCfg(cfg.TargetCfg);
        if (targetCfg != null) //目标技能
        {
            //查找技能范围内的最近目标
            this.targetCfg = targetCfg;
            var targetList = TargetHelper.FindTargetByRule(owner, targetCfg);
            if (targetList != null)
            {
                Start();
            }
            else
            {
                End();
            }
        }
        else //非目标技能
        {

        }
    }

    /// <summary>
    /// 技能开始
    /// </summary>
    void Start()
    {
        LogHelper.Log("技能开始");
        SetState(SkillState.Start);

        //动作
        //朝向

        owner.HeroView.PlayAnim(cfg.AnimName);

        if (cfg.SpellTime > 0)//存在技能前摇
        {
            owner.TimerComp.CreateTimer(cfg.SpellTime, Work);
        }
        else//直接生效
        {
            Work();
        }
    }

    void Work()
    {
        //技能前摇后，目标丢失
        var targetList = TargetHelper.FindTargetByRule(owner, targetCfg);
        if (targetList == null)
        {
            End();
            return;
        }

        LogHelper.Log("技能生效");
        SetState(SkillState.Work);

        ToTarget(); //todo 子弹打中才生效
        ToMySelf();

        if (cfg.SkillTime > cfg.SpellTime)
        {
            //存在后摇，等技能时间结束
            owner.TimerComp.CreateTimer(cfg.SkillTime - cfg.SpellTime, End);
        }
        else
        {
            //直接结束
            End();
        }
    }

    /// <summary>
    /// 作用敌人
    /// </summary>
    void ToTarget()
    {
        //伤害计算
        //伤害buff
    }

    /// <summary>
    /// 作用自己
    /// </summary>
    void ToMySelf()
    {

    }

    void End()
    {
        LogHelper.Log("技能结束");

        SetState(SkillState.End);
        //动作
    }
}
