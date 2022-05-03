using UnityEngine;

public class MoveComponent : Ilogic
{
    Hero owner;

    /// <summary>
    /// 校验之后的位置
    /// </summary>
    public Vector3 Position = Vector3.zero;

    /// <summary>
    /// 校验之后的方向
    /// </summary>
    public Vector3 Direction = Vector3.zero;
    public bool isPosChange = false;

    /// <summary>
    /// 逻辑速度
    /// </summary>
    public int MoveSpeed;

    /// <summary>
    /// ui输入的数据
    /// </summary>
    Vector3 uiInput = Vector3.zero;

    Vector3 lastInput = Vector3.zero;

    public MoveComponent(Hero hero)
    {
        owner = hero;
        MoveSpeed = hero.HeroCfg.MoveSpeed;
    }

    public void InputMove(float h, float v)
    {
        uiInput.x = h;
        uiInput.z = v;

        // 因为相机旋转45度，所以将方向也旋转
        uiInput = Quaternion.Euler(0, 45, 0) * uiInput;
    }

    public void LogicEnd()
    {
    }

    public void LogicStart()
    {
        Position = owner.BornPos;
    }

    public void LogicTick()
    {
        //todo 碰撞位置校正
        if (uiInput == Vector3.zero)
            return;

        Position += uiInput * MoveSpeed * GlobalDef.Instance.LogicFrameIntervelSec;
        Direction = uiInput;
        isPosChange = true;
    }
}