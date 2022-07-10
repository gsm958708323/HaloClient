/* ==============================================================================
* 功能描述：BuffHelper  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:54:04
* ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Reflection;
using cfg.buff;

public static class BuffHelper
{
    private static Dictionary<BuffType, Type> dictBuff2Class = new Dictionary<BuffType, Type>();
    private static Dictionary<int, Buff> dictBuff2Inst = new Dictionary<int, Buff>();

    public static void InitBuffCfg()
    {
        //获取程序集中所有buffcfg类的集合
        Type[] types = Assembly.GetAssembly(typeof(Buff)).GetTypes();
        foreach (Type type in types)
        {
            //找到buffcfg的子类
            if (!type.IsSubclassOf(typeof(Buff)))
            {
                continue;
            }

            var buffTypeAttr = type.GetCustomAttribute<BuffTypeAttribute>();
            if (buffTypeAttr == null)
            {
                UnityEngine.Debug.LogError($"{type.Name} 未注册Buff类型");
                continue;
            }

            //将子类定义的bufftype和类关联起来
            dictBuff2Class.Add(buffTypeAttr.BuffType, type);
        }
    }

    public static Buff CreateBuff(int ID, Hero from, Hero to = null, object[] args = null)
    {
        Buff buff;
        dictBuff2Inst.TryGetValue(ID, out buff);
        if (buff != null)
        {
            return buff;
        }

        var cfg = ConfigMgr.Instance.GetBuffCfg(ID);
        Type buffCls;
        dictBuff2Class.TryGetValue(cfg.Type, out buffCls);
        if (buffCls != null)
        {
            //将类实例化
            buff = Activator.CreateInstance(buffCls, ID, from, to, args) as Buff;

            dictBuff2Inst.Add(ID, buff);
            return buff;
        }
        else
        {
            UnityEngine.Debug.LogError($"未定义buff类：{cfg.Type}");
            return null;
        }
    }
}
