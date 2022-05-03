using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 方便在unity中调试
/// </summary>
public class GlobalDef : MonoBehaviour
{
    public static GlobalDef Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 逻辑帧的间隔（秒）
    /// </summary>
    public float LogicFrameIntervelSec = 0.066667f;
    ///// <summary>
    ///// 每秒能跑多少帧
    ///// </summary>
    //public readonly int LogicFramePerSec = (int)Math.Ceiling(1 / Instance.LogicFrameIntervelSec);

    /// <summary>
    /// 是否开启位置预测
    /// </summary>
    public bool IsOpenPosPredict = true;

    /// <summary>
    /// 平滑移动速率
    /// </summary>
    public int SmoothMoveRate = 500;

    /// <summary>
    /// 平滑朝向速率
    /// </summary>
    public int SmoothDirRate = 100;

    /// <summary>
    /// 最大预测帧
    /// </summary>
    public int PredictMaxFrame = 20;
}
