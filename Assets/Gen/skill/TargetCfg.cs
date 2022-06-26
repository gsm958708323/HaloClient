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

public sealed class TargetCfg :  Bright.Config.BeanBase 
{
    public TargetCfg(JSONNode _json) 
    {
        { if(!_json["ID"].IsNumber) { throw new SerializationException(); }  ID = _json["ID"]; }
        { if(!_json["TargetType"].IsNumber) { throw new SerializationException(); }  TargetType = (skill.TargetType)_json["TargetType"].AsInt; }
        { var _json1 = _json["UnitType"]; if(!_json1.IsArray) { throw new SerializationException(); } UnitType = new System.Collections.Generic.List<unit.UnitType>(_json1.Count); foreach(JSONNode __e in _json1.Children) { unit.UnitType __v;  { if(!__e.IsNumber) { throw new SerializationException(); }  __v = (unit.UnitType)__e.AsInt; }  UnitType.Add(__v); }   }
        { if(!_json["RuleType"].IsNumber) { throw new SerializationException(); }  RuleType = (skill.TargetSelectRule)_json["RuleType"].AsInt; }
        { if(!_json["AttackDis"].IsNumber) { throw new SerializationException(); }  AttackDis = _json["AttackDis"]; }
        { if(!_json["SelectDis"].IsNumber) { throw new SerializationException(); }  SelectDis = _json["SelectDis"]; }
    }

    public TargetCfg(int ID, skill.TargetType TargetType, System.Collections.Generic.List<unit.UnitType> UnitType, skill.TargetSelectRule RuleType, int AttackDis, int SelectDis ) 
    {
        this.ID = ID;
        this.TargetType = TargetType;
        this.UnitType = UnitType;
        this.RuleType = RuleType;
        this.AttackDis = AttackDis;
        this.SelectDis = SelectDis;
    }

    public static TargetCfg DeserializeTargetCfg(JSONNode _json)
    {
        return new skill.TargetCfg(_json);
    }

    public int ID { get; private set; }
    /// <summary>
    /// 目标类型
    /// </summary>
    public skill.TargetType TargetType { get; private set; }
    /// <summary>
    /// 单位类型
    /// </summary>
    public System.Collections.Generic.List<unit.UnitType> UnitType { get; private set; }
    /// <summary>
    /// 选择规则
    /// </summary>
    public skill.TargetSelectRule RuleType { get; private set; }
    /// <summary>
    /// 攻击距离
    /// </summary>
    public int AttackDis { get; private set; }
    /// <summary>
    /// 选择距离，可以朝目标移动
    /// </summary>
    public int SelectDis { get; private set; }

    public const int __ID__ = -730452586;
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
        + "TargetType:" + TargetType + ","
        + "UnitType:" + Bright.Common.StringUtil.CollectionToString(UnitType) + ","
        + "RuleType:" + RuleType + ","
        + "AttackDis:" + AttackDis + ","
        + "SelectDis:" + SelectDis + ","
        + "}";
    }
    }
}
