using System;
using System.Collections.Generic;

public enum TimerState
{
    None,
    Start,
    End,
}

public class LogicTimer
{
    TimerState state = TimerState.None;
    int targetMs;
    Action cb;
    float count;

    public LogicTimer(int waitMs, Action cb)
    {
        this.targetMs = waitMs;
        this.cb = cb;
        SetState(TimerState.Start);
    }

    public void Tick()
    {
        if (state != TimerState.Start)
            return;

        count += GlobalDef.Instance.LogicFrameIntervelSec * 1000;
        if (count >= targetMs)
        {
            cb?.Invoke();
            cb = null;
            targetMs = 0;
            SetState(TimerState.End);
        }
    }

    public TimerState GetState()
    {
        return state;
    }

    public void SetState(TimerState state)
    {
        this.state = state;
    }
}

