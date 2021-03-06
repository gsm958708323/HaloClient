//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.buff
{

public sealed class BuffCfg :  Bright.Config.BeanBase 
{
    public BuffCfg(JSONNode _json) 
    {
        { if(!_json["ID"].IsNumber) { throw new SerializationException(); }  ID = _json["ID"]; }
        { if(!_json["Name"].IsString) { throw new SerializationException(); }  Name = _json["Name"]; }
        { if(!_json["Type"].IsNumber) { throw new SerializationException(); }  Type = (buff.BuffType)_json["Type"].AsInt; }
        { if(!_json["Attach"].IsNumber) { throw new SerializationException(); }  Attach = (buff.BuffAttach)_json["Attach"].AsInt; }
        { if(!_json["Delay"].IsNumber) { throw new SerializationException(); }  Delay = _json["Delay"]; }
        { if(!_json["Interval"].IsNumber) { throw new SerializationException(); }  Interval = _json["Interval"]; }
        { if(!_json["Duration"].IsNumber) { throw new SerializationException(); }  Duration = _json["Duration"]; }
        { var _json1 = _json["Param"]; if(!_json1.IsArray) { throw new SerializationException(); } Param = new System.Collections.Generic.List<float>(_json1.Count); foreach(JSONNode __e in _json1.Children) { float __v;  { if(!__e.IsNumber) { throw new SerializationException(); }  __v = __e; }  Param.Add(__v); }   }
        { if(!_json["EndEvent"].IsNumber) { throw new SerializationException(); }  EndEvent = (skill.BattleEvent)_json["EndEvent"].AsInt; }
    }

    public BuffCfg(int ID, string Name, buff.BuffType Type, buff.BuffAttach Attach, int Delay, int Interval, int Duration, System.Collections.Generic.List<float> Param, skill.BattleEvent EndEvent ) 
    {
        this.ID = ID;
        this.Name = Name;
        this.Type = Type;
        this.Attach = Attach;
        this.Delay = Delay;
        this.Interval = Interval;
        this.Duration = Duration;
        this.Param = Param;
        this.EndEvent = EndEvent;
    }

    public static BuffCfg DeserializeBuffCfg(JSONNode _json)
    {
        return new buff.BuffCfg(_json);
    }

    public int ID { get; private set; }
    public string Name { get; private set; }
    /// <summary>
    /// ??????
    /// </summary>
    public buff.BuffType Type { get; private set; }
    /// <summary>
    /// ????????????
    /// </summary>
    public buff.BuffAttach Attach { get; private set; }
    /// <summary>
    /// ??????
    /// </summary>
    public int Delay { get; private set; }
    /// <summary>
    /// ??????
    /// </summary>
    public int Interval { get; private set; }
    /// <summary>
    /// ????????????
    /// </summary>
    public int Duration { get; private set; }
    /// <summary>
    /// ??????
    /// </summary>
    public System.Collections.Generic.List<float> Param { get; private set; }
    public skill.BattleEvent EndEvent { get; private set; }

    public const int __ID__ = -2108463018;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "ID:" + ID + ","
        + "Name:" + Name + ","
        + "Type:" + Type + ","
        + "Attach:" + Attach + ","
        + "Delay:" + Delay + ","
        + "Interval:" + Interval + ","
        + "Duration:" + Duration + ","
        + "Param:" + Bright.Common.StringUtil.CollectionToString(Param) + ","
        + "EndEvent:" + EndEvent + ","
        + "}";
    }
    }
}
