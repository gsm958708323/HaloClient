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

    int speed;
    int hp;

    public void ModifySpeed(int speed)
    {
        this.speed += speed;
        UnityEngine.Debug.Log($"速度改变：{this.speed}");
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void ModifyHp(int hp)
    {
        this.hp += hp;
        UnityEngine.Debug.Log($"血量改变：{this.hp}");
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
        hp = 50; // 模拟受伤回血
        speed = HeroCfg.MoveSpeed;

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
    }
}
