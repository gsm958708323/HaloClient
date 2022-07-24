/* ==============================================================================
* 功能描述：Skill 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using cfg.skill;
using cfg.buff;
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
    public int ID;
    Hero owner;
    Hero target;

    public Skill(int id, Hero hero)
    {
        this.ID = id;
        this.owner = hero;
        cfg = ConfigMgr.Instance.GetSkillCfg(id);
    }

    public void ModifyCfg(int id)
    {
        this.ID = id;
        cfg = ConfigMgr.Instance.GetSkillCfg(id);
        LogHelper.LogGreen($"替换技能：{id}");
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
                Start(targetList[0]);
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
    void Start(Hero target)
    {
        this.target = target;

        LogHelper.Log("技能开始");
        SetState(SkillState.Start);

        //动作
        if (!string.IsNullOrEmpty(cfg.AnimName))
        {
            owner.HeroView.PlayAnim(cfg.AnimName);
        }
        //朝向
        owner.MoveComp.LookAtTarget(target);
        //声音
        if (!string.IsNullOrEmpty(cfg.AudioStart))
        {
            AudioMgr.Instance.PlayAudio(cfg.AudioStart);
        }

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
        if (target == null)
            return;

        //击中音效
        if (!string.IsNullOrEmpty(cfg.AudioHit))
        {
            AudioMgr.Instance.PlayAudio(cfg.AudioHit);
        }

        //伤害计算
        if (cfg.Damage != 0)
        {
            target.SkillComp.GetDamage(cfg);
        }

        //伤害buff
        foreach (int id in cfg.BuffList)
        {
            var buffCfg = ConfigMgr.Instance.GetBuffCfg(id);
            if (buffCfg != null && buffCfg.Attach == BuffAttach.Target)
            {
                target.BuffComp.CreateBuff(id);
            }
        }

        if(cfg.IsNormalAttack)
            EventDispatcher.instance.DispatchEvent((int)BattleEvent.NormalAttackHit);
    }

    /// <summary>
    /// 作用自己
    /// </summary>
    void ToMySelf()
    {
        foreach (int id in cfg.BuffList)
        {
            var buffCfg = ConfigMgr.Instance.GetBuffCfg(id);
            if (buffCfg != null && buffCfg.Attach == BuffAttach.Caster)
            {
                owner.BuffComp.CreateBuff(id);
            }
        }
    }

    void End()
    {
        LogHelper.Log("技能结束");

        SetState(SkillState.End);
        this.target = null;
    }
}
