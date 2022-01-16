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
    Hero unit;

    void Awake()
    {
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
}
