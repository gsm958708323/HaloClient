/* ==============================================================================
* 功能描述：GameManager 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cfg.unit;
using System;

public class FightMgr : MonoBehaviour
{
    public static FightMgr Instance;

    Hero unit;
    // todo 添加
    // { camptype: { unitType: [unit1, unit2, ] } } 阵营 - 类型 - 对象
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
        foreach (var data in listHeroData)
        {
            var hero = new Hero(data);
            hero.Init();
            hero.Start();
            heroList.Add(hero);

            InitPrefab(hero);
            AddUnitDict(hero);
        }
    }

    /// <summary>
    /// 将unit对象添加到集合中
    /// </summary>
    /// <param name="hero"></param>
    void AddUnitDict(Hero hero)
    {
        var data = hero.HeroData;

        // { camptype: { unitType:[unit1, unit2,] } }
        if (!allUnitDict.TryGetValue(data.CampType, out Dictionary<UnitType, List<Unit>> campDict))
        {
            campDict = new Dictionary<UnitType, List<Unit>>();

            //List<Unit> unitList;
            if (!campDict.TryGetValue(hero.UnitType, out List<Unit> unitList))
            {
                unitList = new List<Unit>();
            }
        }
        
        allUnitDict[hero.CampType][hero.UnitType].Add(hero);
    }

    private void InitPrefab(Hero hero)
    {
        string path = hero.UnitCfg.ResPath;
        if (string.IsNullOrEmpty(path))
            return;

        //Hero预制体与Unit关联
        //hero移动:ViewUnit，遥感输入 -- 修改位置数据 -- 更新显示层
        var go = ResMgr.Instance.LoadPrefab(path);
        UnitView view = go.GetComponent<UnitView>();
        view.LogicInit(hero);
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
