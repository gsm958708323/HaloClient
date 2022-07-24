using System.Collections;
using UnityEngine;
using cfg.unit;

public class Hero : Unit
{
    public HeroView HeroView;

    public HeroCfg HeroCfg;
    public UnitCfg UnitCfg;

    //todo 改成组件挂载
    public BuffComp BuffComp;
    public MoveComp MoveComp;
    public SkillComp SkillComp;
    public TimerComp TimerComp;

    public int NetIndex;
    public int HeroID;

    int hp;

    public void AddHp(int change)
    {
        if (change <= 0)
        {
            return;
        }
        if (this.hp >= HeroCfg.Hp)
        {
            return;
        }

        this.hp += change;

        if (this.hp > HeroCfg.Hp)
        {
            this.hp = HeroCfg.Hp;
        }

        LogHelper.Log($"增加血量：{hp}");
    }

    public void ReduceHp(int change)
    {
        if (change <= 0)
        {
            return;
        }

        hp -= change;
        if (hp < 0)
        {
            hp = 0;
            unitState = UnitState.Dead;
            EventDispatcher.instance.DispatchEvent((int)EventDef.HeroDeath, NetIndex);
        }
        LogHelper.Log($"减少血量：{this.hp}");
    }

    public int GetHp()
    {
        return hp;
    }

    public Hero(HeroData data) : base(data)
    {
        HeroID = data.HeroID;
        NetIndex = data.NetIndex;
    }

    public void SetHeroView(HeroView view)
    {
        HeroView = view;
    }

    public void Init()
    {
        HeroCfg = ConfigMgr.Instance.GetHeroCfg(HeroID);
        UnitCfg = ConfigMgr.Instance.GetUnitCfg(HeroCfg.UnitID);
        UnitType = UnitCfg.Type;

        TimerComp = new TimerComp(this);
        MoveComp = new MoveComp(this);
        SkillComp = new SkillComp(this);
        BuffComp = new BuffComp(this);
    }

    public void Start()
    {
        hp = HeroCfg.Hp;

        TimerComp.LogicStart();
        MoveComp.LogicStart();
        SkillComp.LogicStart();
        BuffComp.LogicStart();
    }

    public void Tick()
    {
        TimerComp.LogicTick();

        MoveComp.LogicTick();
        SkillComp.LogicTick();
        BuffComp.LogicTick();
    }

    public void End()
    {
        TimerComp.LogicEnd();

        MoveComp.LogicEnd();
        SkillComp.LogicEnd();
        BuffComp.LogicEnd();

        HeroView = null;
        HeroCfg = null;
        UnitCfg = null;
    }
}
