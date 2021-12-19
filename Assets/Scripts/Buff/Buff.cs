/* ==============================================================================
* 功能描述：Buff  
* 创 建 者：Halo
* 创建日期：2021/12/19 16:05:36
* ==============================================================================*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public TimingEnum StartTiming;
    public TimingEnum EndTiming;
    public Condition Condition;
    private List<Effect> listEffect = new List<Effect>();

    public void AddEffect(Effect effect)
    {
        listEffect.Add(effect);
    }

    public void StartEffect()
    {
        for (int i = 0; i < listEffect.Count; i++)
        {
            listEffect[i].Start();
        }
    }

    public void EndEffect()
    {
        for (int i = 0; i < listEffect.Count; i++)
        {
            listEffect[i].End();
        }
    }
}
