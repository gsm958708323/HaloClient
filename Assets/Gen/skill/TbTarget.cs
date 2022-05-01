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

public sealed class TbTarget
{
    private readonly Dictionary<int, skill.TargetCfg> _dataMap;
    private readonly List<skill.TargetCfg> _dataList;
    
    public TbTarget(JSONNode _json)
    {
        _dataMap = new Dictionary<int, skill.TargetCfg>();
        _dataList = new List<skill.TargetCfg>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = skill.TargetCfg.DeserializeTargetCfg(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
    }

    public Dictionary<int, skill.TargetCfg> DataMap => _dataMap;
    public List<skill.TargetCfg> DataList => _dataList;

    public skill.TargetCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public skill.TargetCfg Get(int key) => _dataMap[key];
    public skill.TargetCfg this[int key] => _dataMap[key];

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