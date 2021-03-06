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

public sealed class TbSkill
{
    private readonly Dictionary<int, skill.SkillCfg> _dataMap;
    private readonly List<skill.SkillCfg> _dataList;
    
    public TbSkill(JSONNode _json)
    {
        _dataMap = new Dictionary<int, skill.SkillCfg>();
        _dataList = new List<skill.SkillCfg>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = skill.SkillCfg.DeserializeSkillCfg(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
    }

    public Dictionary<int, skill.SkillCfg> DataMap => _dataMap;
    public List<skill.SkillCfg> DataList => _dataList;

    public skill.SkillCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public skill.SkillCfg Get(int key) => _dataMap[key];
    public skill.SkillCfg this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
}

}