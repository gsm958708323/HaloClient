using cfg.unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : UnitData
{
    public int HeroID;
    public int PosIndex;
    public string Name;
}

public class UnitData
{
    public CampType CampType;
    public Vector3 BornPos;
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
            PosIndex = 1,
            CampType = CampType.Red,
            BornPos = new Vector3(-4.9f, 0, 0),
            Name = "我是亚瑟王",
        });

        listHeroData.Add(new HeroData()
        {
            HeroID = 1002,
            PosIndex = 1,
            CampType = CampType.Blue,
            BornPos = new Vector3(6, 0, 0),
            Name = "大鸟满天飞",
        });
        return listHeroData;
    }
}
