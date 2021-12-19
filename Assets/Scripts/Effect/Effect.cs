/* ==============================================================================
* 功能描述：Effect  
* 创 建 者：Halo
* 创建日期：2021/12/19 15:59:35
* ==============================================================================*/
using System;
using System.Collections.Generic;

public abstract class Effect
{
    public abstract void Start();
    public abstract void End();
}

public class TestEffect : Effect
{
    public override void End()
    {
        UnityEngine.Debug.Log("TestEffect End");
    }

    public override void Start()
    {
        UnityEngine.Debug.Log("TestEffect Start");
    }
}