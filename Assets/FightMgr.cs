/* ==============================================================================
* 功能描述：GameManager 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMgr : MonoBehaviour
{
    Unit unit;

    void Awake()
    {
        unit = new Unit() { Type = UnitType.Yase };
        unit.Init();
    }

    void Start()
    {
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
}
