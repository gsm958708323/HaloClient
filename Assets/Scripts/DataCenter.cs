using cfg.unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData
{
    public int HeroID;
    public int PosIndex;
    public CampType CampType;
    public string Name;
}

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
            Name = "我是亚瑟王",
        });

        listHeroData.Add(new HeroData()
        {
            HeroID = 1002,
            PosIndex = 1,
            CampType = CampType.Blue,
            Name = "大鸟满天飞",
        });
        return listHeroData;
    }
}
