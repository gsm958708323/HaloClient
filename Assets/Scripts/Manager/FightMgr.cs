/* ==============================================================================
* 功能描述：GameManager 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cfg.unit;

public class FightMgr : MonoBehaviour
{
    public static FightMgr Instance;

    Hero unit;
    // todo 添加
    // { camptype: { unitType: [unit1, unit2, ] } }
    Dictionary<CampType, Dictionary<UnitType, List<Unit>>> allUnitDict = new Dictionary<CampType, Dictionary<UnitType, List<Unit>>>();

    public List<Hero> heroList = new List<Hero>();

    void Awake()
    {
        Instance = this;
        InitHelper();
    }


    void Start()
    {
        InitHero();
    }

    void FixUpdate()
    {

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    unit.BuffComponent.CreateBuff(BuffType.MoveSpeed);
        //}

        foreach (var hero in heroList)
        {
            hero.Tick();
        }
    }

    private void OnDestroy()
    {
       heroList.Clear();
       allUnitDict.Clear(); 
    }

    void InitHelper()
    {
        BuffHelper.InitBuffCfg();
    }

    void InitHero()
    {
        var listHeroData = DataCenter.GetHeroData();
        foreach (var item in listHeroData)
        {
            var hero = new Hero(item.HeroID);
            hero.Init();
            hero.Start();
            heroList.Add(hero);
        }

        //todo
        //Hero预制体与Unit关联
        //hero移动:ViewUnit，遥感输入 -- 修改位置数据 -- 更新显示层
    }

    public List<Unit> TryGetTargetList(CampType campType, UnitType unitType)
    {
        Dictionary<UnitType, List<Unit>> dictUnitList;
        if (!allUnitDict.TryGetValue(campType, out dictUnitList))
        {
            return null;
        }

        List<Unit> listUnit;
        if (!dictUnitList.TryGetValue(unitType, out listUnit))
        {
            return null;
        }
        return listUnit;
    }
}
