using cfg.unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : UnitData
{
    /// <summary>
    /// 英雄编号，传输网络数据时的标识信息
    /// </summary>
    public int HeroIndex;
    /// <summary>
    /// 英雄配置表ID
    /// </summary>
    public int HeroID;
    public string Name;
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
            HeroIndex = 1,
            CampType = CampType.Red,
            BornPos = new Vector3(-4.9f, 0, 0),
            Name = "我是亚瑟王",
            IsLocal = true
        });

        listHeroData.Add(new HeroData()
        {
            HeroID = 1002,
            HeroIndex = 2,
            CampType = CampType.Blue,
            BornPos = new Vector3(6, 0, 0),
            Name = "大鸟满天飞",
            IsLocal= false
        });
        return listHeroData;
    }
}
