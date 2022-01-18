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



namespace cfg.skill
{

public sealed class SkillCfg :  Bright.Config.BeanBase 
{
    public SkillCfg(JSONNode _json) 
    {
        { if(!_json["ID"].IsNumber) { throw new SerializationException(); }  ID = _json["ID"]; }
        { if(!_json["Name"].IsString) { throw new SerializationException(); }  Name = _json["Name"]; }
        { if(!_json["Cost"].IsNumber) { throw new SerializationException(); }  Cost = _json["Cost"]; }
        { if(!_json["Condition"].IsNumber) { throw new SerializationException(); }  Condition = _json["Condition"]; }
        { if(!_json["Buff"].IsNumber) { throw new SerializationException(); }  Buff = _json["Buff"]; }
        { var _json1 = _json["TimeLine"]; if(!_json1.IsArray) { throw new SerializationException(); } TimeLine = new System.Collections.Generic.List<skill.TimeNode>(_json1.Count); foreach(JSONNode __e in _json1.Children) { skill.TimeNode __v;  { if(!__e.IsObject) { throw new SerializationException(); }  __v = skill.TimeNode.DeserializeTimeNode(__e); }  TimeLine.Add(__v); }   }
    }

    public SkillCfg(int ID, string Name, int Cost, int Condition, int Buff, System.Collections.Generic.List<skill.TimeNode> TimeLine ) 
    {
        this.ID = ID;
        this.Name = Name;
        this.Cost = Cost;
        this.Condition = Condition;
        this.Buff = Buff;
        this.TimeLine = TimeLine;
    }

    public static SkillCfg DeserializeSkillCfg(JSONNode _json)
    {
        return new skill.SkillCfg(_json);
    }

    /// <summary>
    /// id
    /// </summary>
    public int ID { get; private set; }
    /// <summary>
    /// desc
    /// </summary>
    public string Name { get; private set; }
    public int Cost { get; private set; }
    public int Condition { get; private set; }
    public int Buff { get; private set; }
    /// <summary>
    /// TimeElapsed
    /// </summary>
    public System.Collections.Generic.List<skill.TimeNode> TimeLine { get; private set; }

    public const int __ID__ = 1452435312;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var _e in TimeLine) { _e?.Resolve(_tables); }
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var _e in TimeLine) { _e?.TranslateText(translator); }
    }

    public override string ToString()
    {
        return "{ "
        + "ID:" + ID + ","
        + "Name:" + Name + ","
        + "Cost:" + Cost + ","
        + "Condition:" + Condition + ","
        + "Buff:" + Buff + ","
        + "TimeLine:" + Bright.Common.StringUtil.CollectionToString(TimeLine) + ","
        + "}";
    }
    }
}