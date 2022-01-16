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
        { if(!_json["Param"].IsNumber) { throw new SerializationException(); }  Param = _json["Param"]; }
    }

    public BuffCfg(int ID, string Name, buff.BuffType Type, buff.BuffAttach Attach, int Delay, int Interval, int Duration, int Param ) 
    {
        this.ID = ID;
        this.Name = Name;
        this.Type = Type;
        this.Attach = Attach;
        this.Delay = Delay;
        this.Interval = Interval;
        this.Duration = Duration;
        this.Param = Param;
    }

    public static BuffCfg DeserializeBuffCfg(JSONNode _json)
    {
        return new buff.BuffCfg(_json);
    }

    public int ID { get; private set; }
    public string Name { get; private set; }
    /// <summary>
    /// 类别
    /// </summary>
    public buff.BuffType Type { get; private set; }
    /// <summary>
    /// 作用类型
    /// </summary>
    public buff.BuffAttach Attach { get; private set; }
    /// <summary>
    /// 延迟
    /// </summary>
    public int Delay { get; private set; }
    /// <summary>
    /// 间隔
    /// </summary>
    public int Interval { get; private set; }
    /// <summary>
    /// 持续时间
    /// </summary>
    public int Duration { get; private set; }
    /// <summary>
    /// 参数
    /// </summary>
    public int Param { get; private set; }

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
        + "Param:" + Param + ","
        + "}";
    }
    }
}