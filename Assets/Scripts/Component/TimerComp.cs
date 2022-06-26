using System;
using System.Collections.Generic;

public class TimerComp : Ilogic
{
    List<LogicTimer> timerList = new List<LogicTimer>();
    private Hero hero;

    public TimerComp(Hero hero)
    {
        this.hero = hero;
    }

    public void CreateTimer(int ms, Action cb)
    {
        var timer = new LogicTimer(ms, cb);
        timerList.Add(timer);
    }

    public void LogicStart()
    {
    }
    public void LogicEnd()
    {
    }

    public void LogicTick()
    {
        // todo 应该改为先进先出
        for (int i = timerList.Count - 1; i >= 0; i--)
        {
            var timer = timerList[i];
            if (timer.GetState() == TimerState.Start)
            {
                timer.Tick();
            }
            else
            {
                timerList.RemoveAt(i);
            }
        }
    }
}

