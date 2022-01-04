using System.Collections;
using UnityEngine;

public class UnitCfg
{
    public UnitType UnitType;
    public string Name;

    public int Speed;

    /// <summary>
    /// 主动技能
    /// </summary>
    public int[] ActiveSkill;
    /// <summary>
    /// 被动技能
    /// </summary>
    public BuffType[] PassiveSkill;
}

public class Unit
{
    public UnitType Type;
    public UnitCfg Cfg;
    //todo 改成组件挂载
    public BuffComponent BuffComponent;

    private int speed;

    public void ModifySpeed(int speed)
    {
        this.speed += speed;
        UnityEngine.Debug.Log($"速度改变：{this.speed}");
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void Init()
    {
        Cfg = UnitHelper.GetUnitCfg(Type);
        BuffComponent = new BuffComponent();
        BuffComponent.SetOwner(this);
    }

    public void Start()
    {
        speed = Cfg.Speed;

        BuffComponent.InitBuff();
    }

    public void End()
    {

    }

    public void Tick()
    {
        BuffComponent.TickBuff();
    }
}
