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

public sealed class TbUnit
{
    private readonly Dictionary<int, unit.UnitCfg> _dataMap;
    private readonly List<unit.UnitCfg> _dataList;
    
    public TbUnit(JSONNode _json)
    {
        _dataMap = new Dictionary<int, unit.UnitCfg>();
        _dataList = new List<unit.UnitCfg>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = unit.UnitCfg.DeserializeUnitCfg(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
    }

    public Dictionary<int, unit.UnitCfg> DataMap => _dataMap;
    public List<unit.UnitCfg> DataList => _dataList;

    public unit.UnitCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public unit.UnitCfg Get(int key) => _dataMap[key];
    public unit.UnitCfg this[int key] => _dataMap[key];

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