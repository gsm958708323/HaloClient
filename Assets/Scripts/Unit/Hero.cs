using System.Collections;
using UnityEngine;
using cfg.unit;

public class Hero : Unit
{
    public HeroCfg HeroCfg;
    public UnitCfg UnitCfg;

    //todo 改成组件挂载
    public BuffComponent BuffComponent;
    public MoveComponent MoveComponent;

    int speed;
    int hp;
    int id;

    public Hero(HeroData data) : base(data)
    {
        id = data.HeroID;
    }

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

    public void Init()
    {
        HeroCfg = ConfigMgr.Instance.GetHeroCfg(id);
        UnitCfg = ConfigMgr.Instance.GetUnitCfg(HeroCfg.UnitID);
        UnitType = UnitCfg.Type;

        MoveComponent = new MoveComponent();
        BuffComponent = new BuffComponent();
        BuffComponent.SetOwner(this);
    }

    public void Start()
    {
        hp = 50; // 模拟受伤回血
        speed = HeroCfg.MoveSpeed;

        MoveComponent.LogicStart();
        BuffComponent.LogicStart();
    }

    public void Tick()
    {
        MoveComponent.LogicTick();
        BuffComponent.LogicTick();
    }

    public void End()
    {
        MoveComponent.LogicEnd();
        BuffComponent.LogicEnd();
    }
}
