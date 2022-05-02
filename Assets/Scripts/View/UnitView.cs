using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unit界面表现
/// 1.处理同步信息
/// 2.处理旋转信息
/// </summary>
public abstract class UnitView : MonoBehaviour
{
    public bool isLocal;
    protected Unit unitData;
    public virtual void LogicInit(Unit unit)
    {
        unitData = unit;
        isLocal = unitData.IsLocal;
    }

    private void Start()
    {
        //初始化位置和旋转
        gameObject.transform.position = unitData.BornPos;
    }

    private void FixedUpdate()
    {
        if (isLocal)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (h == 0 && v == 0)
            {
                return;
            }

            Vector3 dir = new Vector3(h, 0, v);
            //因为相机旋转45度，所以将方向也旋转
            dir = Quaternion.Euler(0, 45, 0) * dir;

            gameObject.transform.position += dir;
            gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, dir);
        }
    }
}

