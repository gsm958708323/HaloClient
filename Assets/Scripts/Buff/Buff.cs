/* ==============================================================================
* 功能描述：Buff  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:41:54
* ==============================================================================*/
using System;
using System.Collections.Generic;
using cfg.buff;

public abstract class Buff : Ilogic
{
    public BuffCfg Cfg;

    protected Hero from;
    protected Hero to;
    protected int ID;
    protected object[] args;

    BuffState state;
    int delayCount;
    int durationCount;
    int intervalCount;

    public Buff(int ID, Hero from, Hero to, object[] args)
    {
        this.from = from;
        this.to = to;
        this.ID = ID;
        this.args = args;
        this.Cfg = ConfigMgr.Instance.GetBuffCfg(ID);
    }

    public void LogicStart()
    {
        durationCount = Cfg.Duration;
        intervalCount = Cfg.Interval;
        delayCount = Cfg.Delay;

        if (Cfg.Delay > 0)
        {
            state = BuffState.Delay;
        }
        else
        {
            state = BuffState.Start;
        }
        LogHelper.LogGreen($"Buff {Cfg.Name} Duration: {Cfg.Duration}, Interval: {Cfg.Interval}, Delay: {Cfg.Delay}");
    }
    /// <summary>
    /// 状态在下一帧才会生效
    /// 防止在当前帧头时修改状态，帧尾还原时状态丢失
    /// </summary>
    public void LogicTick()
    {
        if (state == BuffState.Delay)
        {
            delayCount -= (int)GlobalDef.Instance.LogicFrameIntervelSec * 1000;
            //UnityEngine.Debug.Log($"delayCount: {delayCount}");

            if (delayCount <= 0)
            {
                delayCount = 0;
                state = BuffState.Start;
            }
        }
        else if (state == BuffState.Start)
        {
            Start();
            // -1为永久，0为瞬时，>0是计时
            if (Cfg.Duration == 0)
            {
                state = BuffState.End;
            }
            else
            {
                //这里没有调用子类的Tick函数，需要等待固定帧才执行
                state = BuffState.Tick;
            }
        }
        else if (state == BuffState.Tick)
        {
            //固定间隔执行Tick
            int deltaTime = (int)(GlobalDef.Instance.LogicFrameIntervelSec * 1000);

            intervalCount -= deltaTime;
            //UnityEngine.Debug.Log($"intervalCount: {intervalCount}");

            if (intervalCount <= 0)
            {
                intervalCount += Cfg.Interval; // 这里可能是负数，所以使用+=
                Tick();
            }

            if (Cfg.Duration != -1)
            {
                durationCount -= deltaTime;
                //UnityEngine.Debug.Log($"durationCount: {durationCount}");

                if (durationCount <= 0)
                {
                    durationCount = 0;
                    state = BuffState.End;
                }
            }
        }
        else if (state == BuffState.End)
        {
            End();
            //None状态用来标记回收状态
            state = BuffState.None;
        }
        else
        {
            UnityEngine.Debug.LogError($"Buff状态切换失败：{state}");
        }
    }

    public void LogicEnd()
    {
    }

    public void ChangeState(BuffState state)
    {
        this.state = state;
    }

    public BuffState GetState()
    {
        return state;
    }

    public virtual void Start()
    {
        //UnityEngine.Debug.Log("--Start--");
    }

    public virtual void End()
    {
        //UnityEngine.Debug.Log("--End--");
    }

    public virtual void Tick()
    {
        //UnityEngine.Debug.Log("--Tick--");
    }
}
