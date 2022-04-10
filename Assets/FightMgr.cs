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
    Dictionary<CampType, Dictionary<UnitType, List<Unit>>> dictAllUnit = new Dictionary<CampType, Dictionary<UnitType, List<Unit>>>();

    void Awake()
    {
        Instance = this;
        BuffHelper.InitBuffCfg();
    }

    void Start()
    {
        unit = new Hero(1001);
        unit.Init();

        unit.Start();
    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    unit.BuffComponent.CreateBuff(BuffType.MoveSpeed);
        //}

        unit.Tick();
    }

    public List<Unit> TryGetTargetList(CampType campType, UnitType unitType)
    {
        Dictionary<UnitType, List<Unit>> dictUnitList;
        if (!dictAllUnit.TryGetValue(campType, out dictUnitList))
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
