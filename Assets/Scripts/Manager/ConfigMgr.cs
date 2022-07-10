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
using cfg.skill;

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
    }

    public cfg.buff.BuffCfg GetBuffCfg(int ID)
    {
        var cfg = tables.TbBuff.GetOrDefault(ID);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"buff配置不存在：{ID}");
            return null;
        }
        else
        {
            return cfg;
        }
    }

    public cfg.skill.SkillCfg GetSkillCfg(int id)
    {
        var cfg = tables.TbSkill.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到Skill：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
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

    public TargetCfg GetTargetCfg(int id)
    {
        var cfg = tables.TbTarget.GetOrDefault(id);
        if (cfg == null)
        {
            UnityEngine.Debug.LogError($"未找到TargetCfg：{id}");
            return null;
        }
        else
        {
            return cfg;
        }
    }
}
