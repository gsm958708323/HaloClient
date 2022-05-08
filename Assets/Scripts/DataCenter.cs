using cfg.unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : UnitData
{
    /// <summary>
    /// 英雄配置表ID
    /// </summary>
    public int HeroID;
    public string Name;
    /// <summary>
    /// 当前英雄的唯一标识
    /// </summary>
    public int NetIndex;
}

public class UnitData
{
    public CampType CampType;
    public Vector3 BornPos;
    /// <summary>
    /// 本地还是网络
    /// </summary>
    public bool IsLocal;
}

/// <summary>
/// 模拟网络数据
/// </summary>
public class DataCenter
{
    public static List<HeroData> GetHeroData()
    {
        List<HeroData> listHeroData = new List<HeroData>();
        listHeroData.Add(new HeroData()
        {
            HeroID = 1001,
            CampType = CampType.Red,
            BornPos = new Vector3(-4.9f, 0, 0),
            Name = "我是亚瑟王",
            NetIndex = 0,
        });

        listHeroData.Add(new HeroData()
        {
            HeroID = 1002,
            CampType = CampType.Blue,
            BornPos = new Vector3(6, 0, 0),
            Name = "大鸟满天飞",
            NetIndex = 1,
        });
        return listHeroData;
    }

    /// <summary>
    /// 获取自己的网络标识
    /// </summary>
    /// <returns></returns>
    public static int GetMyNetIndex()
    {
        return 0;
    }
}
