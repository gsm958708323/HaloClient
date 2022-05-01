/* ==============================================================================
* 功能描述：ConfigTest 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using cfg;

public class ConfigMgr : MonoBehaviour
{
    public static ConfigMgr Instance;
    Tables tables;

    void Awake()
    {
        Instance = this;

        //let data = JsHelpers.ReadAllText(UnityEngine.Application.dataPath + "GameData/" + f + ".json");
        tables = new Tables(file => SimpleJSON.JSON.Parse(
                File.ReadAllText($"{Application.dataPath}/../Gen/json/{file}.json")
            )
        );
        var item = tables.TbBuff.Get(100101);
        print($"{item.ID} {item.Name}");
    }

    public Tables GetTables()
    {
        return tables;
    }

    public cfg.unit.HeroCfg GetHeroCfg(int id)
    {
        var cfg = tables.TbHero.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到Hero：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
    }

    public cfg.unit.UnitCfg GetUnitCfg(int id)
    {
        var cfg = tables.TbUnit.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到Unit：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
    }
}
