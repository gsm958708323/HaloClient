using System.Collections;
using UnityEngine;
using cfg.unit;

public class Hero : Unit
{
    public UnitType Type;
    public HeroCfg Cfg;
    //todo 改成组件挂载
    public BuffComponent BuffComponent;
    public MoveComponent MoveComponent;

    int speed;
    int hp;
    int id;

    public Hero(int id)
    {
        this.id = id;
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
        Cfg = HeroHelper.GetHeroCfg(id);
        MoveComponent = new MoveComponent();

        BuffComponent = new BuffComponent();
        BuffComponent.SetOwner(this);
    }

    public void Start()
    {
        hp = 50; // 模拟受伤回血
        speed = Cfg.MoveSpeed;

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
