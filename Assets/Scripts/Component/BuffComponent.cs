﻿/* ==============================================================================
* 功能描述：BuffComponent  
* 创 建 者：Halo
* 创建日期：2022/1/3 16:27:13
* ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Reflection;
using cfg.buff;

public class BuffComponent : Ilogic
{
    List<Buff> buffList = new List<Buff>();
    Hero owner;

    public BuffComponent(Hero hero)
    {
        this.owner = hero;
    }

    public Buff GetBuff(BuffType type)
    {
        foreach (Buff buff in buffList)
        {
            if (buff.Cfg.Type == type)
            {
                return buff;
            }
        }
        return null;
    }

    public Buff CreateBuff(int id, Hero to = null, object[] args = null)
    {
        Buff buff = BuffHelper.CreateBuff(id, owner, to, args);
        buff.LogicInit();
        buffList.Add(buff);
        return buff;
    }

    public void LogicStart()
    {
        //初始化被动buff
        foreach (int id in owner.HeroCfg.PassiveSkill)
        {
            CreateBuff(id);//被动是施加给自己的
        }
    }

    public void LogicTick()
    {
        for (int i = 0; i < buffList.Count; i++)
        {
            if (buffList[i].GetState() == BuffState.None)
            {
                buffList.RemoveAt(i);
            }
            else
            {
                buffList[i].LogicTick();
            }
        }
    }

    public void LogicEnd()
    {
    }
}
