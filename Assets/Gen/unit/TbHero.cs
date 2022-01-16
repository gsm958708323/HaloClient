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



namespace cfg.unit
{

public sealed class TbHero
{
    private readonly Dictionary<int, unit.HeroCfg> _dataMap;
    private readonly List<unit.HeroCfg> _dataList;
    
    public TbHero(JSONNode _json)
    {
        _dataMap = new Dictionary<int, unit.HeroCfg>();
        _dataList = new List<unit.HeroCfg>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = unit.HeroCfg.DeserializeHeroCfg(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
    }

    public Dictionary<int, unit.HeroCfg> DataMap => _dataMap;
    public List<unit.HeroCfg> DataList => _dataList;

    public unit.HeroCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public unit.HeroCfg Get(int key) => _dataMap[key];
    public unit.HeroCfg this[int key] => _dataMap[key];

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