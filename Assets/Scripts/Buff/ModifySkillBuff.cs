using System;
using System.Collections.Generic;
using cfg.buff;
using cfg.skill;

[BuffType(BuffType.ModifySkill)]
public class ModifySkillBuff : Buff
{
    public ModifySkillBuff(int ID, Hero from, Hero to, object[] args) : base(ID, from, to, args)
    {
    }

    int fromSkilId, toSkilId;

    private void OnNormalAttackHit()
    {
        this.ChangeState(BuffState.End);
    }

    public override void Start()
    {
        base.Start();

        EventDispatcher.instance.Regist((int)Cfg.EndEvent, OnNormalAttackHit);

        fromSkilId = (int)Cfg.Param[0];
        toSkilId = (int)Cfg.Param[1];
        from.SkillComp.ModifySkill(fromSkilId, toSkilId);
    }

    public override void End()
    {
        base.End();

        from.SkillComp.ModifySkill(toSkilId, fromSkilId);
    }
}
