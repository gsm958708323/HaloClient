/* ==============================================================================
* 功能描述：BuffComponent  
* 创 建 者：Halo
* 创建日期：2022/1/3 16:27:13
* ==============================================================================*/
using System;
using System.Collections.Generic;

public class BuffComponent
{
    List<Buff> buffList = new List<Buff>();
    Unit unit;

    public void SetOwner(Unit unit)
    {
        this.unit = unit;
    }


    public Buff GetBuff(BuffType type)
    {
        foreach (Buff buff in buffList)
        {
            if (buff.Cfg.BuffEnum == type)
            {
                return buff;
            }
        }
        return null;
    }

    public Buff CreateBuff(BuffType type, Unit to = null, object[] args = null)
    {
        Buff buff = BuffHelper.CreateBuff(unit, type, to, args);
        buff.Init();
        buffList.Add(buff);
        return buff;
    }

    public void InitBuff()
    {
        //初始化被动buff
        foreach (BuffType type in unit.Cfg.PassiveSkill)
        {
            CreateBuff(type);//被动是施加给自己的
        }
    }

    public void TickBuff()
    {
        for (int i = 0; i < buffList.Count; i++)
        {
            if (buffList[i].State == BuffState.None)
            {
                buffList.RemoveAt(i);
            }
            else
            {
                buffList[i].Tick();
            }
        }
    }
}
