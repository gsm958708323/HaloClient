/* ==============================================================================
* 功能描述：Buff  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:41:54
* ==============================================================================*/
using System;
using System.Collections.Generic;
using cfg.buff;

public abstract class Buff
{
    public BuffCfg Cfg;

    protected Hero from;
    protected Hero to;
    protected int ID;
    protected object[] args;

    BuffState state = BuffState.None;
    int delayCount;
    int durationCount;
    int intervalCount;

    public Buff(int ID, Hero from, Hero to, object[] args)
    {
        this.from = from;
        this.to = to;
        this.ID = ID;
        this.args = args;
        this.Cfg = BuffHelper.GetBuffCfg(ID);
    }

    public void LogicInit()
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
            // todo 当前帧还是下一帧？
            ChangeState(BuffState.Start);
        }
        UnityEngine.Debug.Log($"Buff Duration: {Cfg.Duration}, Interval: {Cfg.Interval}, Delay: {Cfg.Delay}");
    }

    public void LogicTick()
    {
        if (state == BuffState.Delay)
        {
            delayCount -= (int)GlobalDef.Instance.LogicFrameIntervelSec * 1000;
            //UnityEngine.Debug.Log($"delayCount: {delayCount}");

            if (delayCount <= 0)
            {
                delayCount = 0;
                ChangeState(BuffState.Start);
            }
        }
        else if (state == BuffState.Start)
        {
            // -1为永久，0为瞬时，>0是计时
            if (Cfg.Duration == 0)
            {
                ChangeState(BuffState.End);
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
            int deltaTime = (int)GlobalDef.Instance.LogicFrameIntervelSec * 1000;

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
                    ChangeState(BuffState.End);
                }
            }
        }
        else if (state == BuffState.End)
        {
            state = BuffState.None;
        }
        else
        {
            UnityEngine.Debug.LogError($"Buff状态切换失败：{state}");
        }
    }

    public void ChangeState(BuffState state)
    {
        this.state = state;
        if (state == BuffState.Start)
        {
            Start();
        }
        else if (state == BuffState.End)
        {
            End();
        }
        else if (state == BuffState.Tick)
        {
            Tick();
        }
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
