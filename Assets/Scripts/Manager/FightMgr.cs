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
    // { camptype: { unitType: [unit1, unit2, ] } } 阵营 - 类型 - 对象
    Dictionary<CampType, Dictionary<UnitType, List<Hero>>> allUnitDict = new Dictionary<CampType, Dictionary<UnitType, List<Hero>>>();

    public List<Hero> heroList = new List<Hero>();

    float timer = 0;

    Transform cameraTrans;
    Transform heroTrans;

    void Awake()
    {
        Instance = this;
        InitHelper();
        AddListener();
    }


    void Start()
    {
        InitHero();
        InitCamera();
    }

    private void InitCamera()
    {
        cameraTrans = GameObject.Find("CameraRoot").transform;
        Hero hero = GetHeroByIndex(DataCenter.GetMyNetIndex());
        hero.HeroView.SetMainCamera(cameraTrans);
    }

    void InitHelper()
    {
        BuffHelper.InitBuffCfg();
    }


    private void Update()
    {
        if (timer >= GlobalDef.Instance.LogicFrameIntervelSec)
        {
            //Debug.LogWarning($"调用一帧： {timer}");
            timer = 0;
            foreach (var hero in heroList)
            {
                hero.Tick();
            }
        }
        timer += Time.deltaTime;
        //print($"计时器： {timer}");
        TestUpdate();
    }

    // todo 删除
    void TestUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var hero = GetHeroByIndex(DataCenter.GetMyNetIndex());
            if (hero != null)
            {
                hero.SkillComp.UseSkill(0);
            }
        }
    }

    private void OnDestroy()
    {
        heroList.Clear();
        allUnitDict.Clear();
    }

    private void AddListener()
    {
        EventDispatcher.instance.Regist<int, float, float>((int)EventDef.InputMoveEvent, OnHeroMoveUpdate);
    }

    private void OnHeroMoveUpdate(int heroIndex, float h, float v)
    {
        Hero hero = GetHeroByIndex(heroIndex);
        if (hero != null)
        {
            hero.MoveComp.InputMove(h, v);
        }
    }

    #region 英雄相关
    Hero GetHeroByIndex(int index)
    {
        if (index >= 0 && index < heroList.Count)
        {
            return heroList[index];
        }
        else
        {
            Debug.LogError($"未找到hero {index}");
            return null;
        }
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

    private void InitPrefab(Hero hero)
    {
        string path = hero.UnitCfg.ResPath;
        if (string.IsNullOrEmpty(path))
            return;

        var go = ResMgr.Instance.LoadPrefab(path);
        if (go == null)
            return;

        HeroView view = go.GetComponent<HeroView>();
        view.LogicInit(hero);

        hero.SetHeroView(view);
    }
    #endregion


    #region unit对象集合
    /// <summary>
    /// 将unit对象添加到集合中
    /// </summary>
    /// <param name="hero"></param>
    void AddUnitDict(Hero hero)
    {
        //var data = hero.HeroData;

        if (!allUnitDict.TryGetValue(hero.CampType, out Dictionary<UnitType, List<Hero>> campDict))
        {
            campDict = new Dictionary<UnitType, List<Hero>>();
            allUnitDict[hero.CampType] = campDict;

            if (!campDict.TryGetValue(hero.UnitType, out List<Hero> unitList))
            {
                unitList = new List<Hero>();
                campDict[hero.UnitType] = unitList;
            }
        }

        allUnitDict[hero.CampType][hero.UnitType].Add(hero);
    }


    public List<Hero> TryGetTargetList(CampType campType, UnitType unitType)
    {
        Dictionary<UnitType, List<Hero>> dictUnitList;
        if (!allUnitDict.TryGetValue(campType, out dictUnitList))
        {
            return null;
        }

        List<Hero> listUnit;
        if (!dictUnitList.TryGetValue(unitType, out listUnit))
        {
            return null;
        }
        return listUnit;
    }

    #endregion
}
