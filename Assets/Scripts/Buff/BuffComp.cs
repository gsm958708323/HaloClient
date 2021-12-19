/* ==============================================================================
* 功能描述：BuffComp  
* 创 建 者：Halo
* 创建日期：2021/12/19 16:09:39
* ==============================================================================*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffComp : MonoBehaviour
{
    public int[] BuffSolt = new int[4];
    Dictionary<int, Buff> dictBuff = new Dictionary<int, Buff>();
    //Dictionary<TimingEnum, List<Buff>> timing2BuffList = new Dictionary<TimingEnum, List<Buff>>();

    private void Start()
    {
        InitBuff();

        InitEvent();
    }

    void InitEvent()
    {
        EventDispatcher.instance.Regist<Entity>(EventDef.ActionStart, OnActionStart);
        EventDispatcher.instance.Regist<Entity>(EventDef.ActionEnd, OnActionEnd);
    }

    /// <summary>
    /// 根据id生成buff
    /// </summary>
    void InitBuff()
    {
        // 初始化buff
        for (int i = 0; i < BuffSolt.Length; i++)
        {
            int id = BuffSolt[i];
            Buff buff = BuffConfigHelper.GetBuff(id);
            if (buff != null)
            {
                dictBuff.Add(id, buff);
            }
        }

        //foreach (var item in dictBuff)
        //{
        //    List<Buff> listBuff;
        //    var timing = item.Value.StartTiming;
        //    var buff = item.Value;
        //    if (timing2BuffList.TryGetValue(item.Value.StartTiming, out listBuff))
        //    {
        //        listBuff.Add(buff);
        //    }
        //    else
        //    {
        //        timing2BuffList[timing] = new List<Buff>();
        //        timing2BuffList[timing].Add(buff);
        //    }
        //}
    }

    List<Buff> GetStartBuffList(TimingEnum timing)
    {
        List<Buff> buffList = new List<Buff>();
        foreach (var item in dictBuff)
        {
            if (item.Value.StartTiming == timing)
            {
                buffList.Add(item.Value);
            }
        }
        return buffList;
    }

    List<Buff> GetEndBuffList(TimingEnum timing)
    {
        List<Buff> buffList = new List<Buff>();
        foreach (var item in dictBuff)
        {
            if (item.Value.EndTiming == timing)
            {
                buffList.Add(item.Value);
            }
        }
        return buffList;
    }

    void OnActionStart(Entity target)
    {
        foreach (Buff buff in GetStartBuffList(TimingEnum.ActionStart))
        {
            buff.StartEffect();
        }
    }

    void OnActionEnd(Entity target)
    {
        foreach (Buff buff in GetEndBuffList(TimingEnum.ActionEnd))
        {
            buff.EndEffect();
        }
    }
}