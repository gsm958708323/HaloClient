/* ==============================================================================
* 功能描述：InputComp  
* 创 建 者：Halo
* 创建日期：2021/12/19 18:19:42
* ==============================================================================*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputComp : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventDispatcher.instance.DispatchEvent(EventDef.ActionStart, gameObject.GetComponent<Entity>().Target);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            EventDispatcher.instance.DispatchEvent(EventDef.ActionEnd, gameObject.GetComponent<Entity>().Target);
        }
    }
}
