/* ==============================================================================
* 功能描述：Buff  
* 创 建 者：Halo
* 创建日期：2022/1/3 15:41:54
* ==============================================================================*/
using System;
using System.Collections.Generic;

public abstract class Buff
{

    public BuffCfg Cfg;
    public BuffState State = BuffState.None;

    protected Unit from;
    protected Unit to;
    protected BuffType buffEnum;
    protected object[] args;

    protected int delayCount;
    protected int durationCount;

    public Buff(Unit from, Unit to, BuffType buffEnum, object[] args)
    {
        this.from = from;
        this.to = to;
        this.buffEnum = buffEnum;
        this.args = args;
        this.Cfg = BuffHelper.GetBuffCfg(buffEnum);
    }

    public virtual void Init()
    {
        durationCount = Cfg.Duration;

        if (Cfg.Delay > 0)
        {
            State = BuffState.Delay;
            delayCount = Cfg.Delay;
        }
        else
        {
            // todo 当前帧还是下一帧？
            State = BuffState.Start;
            Start();
        }
    }

    public virtual void Start()
    {
    }

    public virtual void End()
    {
    }

    public virtual void Tick()
    {
        if (State == BuffState.Delay)
        {
            delayCount -= BuffDef.LogicFrameIntervelMs;
            if (delayCount <= 0)
            {
                delayCount = 0;

                State = BuffState.Start;
                Start();
            }
        }
        else if (State == BuffState.Start)
        {
            if (Cfg.Duration > 0)
            {
                State = BuffState.Tick;
            }
            else
            {
                State = BuffState.End;
                End();
            }
        }
        else if (State == BuffState.End)
        {
            State = BuffState.None;
        }
        else if (State == BuffState.Tick)
        {
            durationCount -= BuffDef.LogicFrameIntervelMs;
            if(durationCount <= 0)
            {
                durationCount = 0;

                State = BuffState.End;
                End();
            }
        }
        else
        {
            UnityEngine.Debug.LogError($"Buff状态切换失败：{State}");
        }
    }
}
