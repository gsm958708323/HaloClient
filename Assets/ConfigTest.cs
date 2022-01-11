/* ==============================================================================
* 功能描述：ConfigTest 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigTest : MonoBehaviour
{
    void Start()
    {
        //let data = JsHelpers.ReadAllText(UnityEngine.Application.dataPath + "GameData/" + f + ".json");
        var tables = new cfg.Tables(file => SimpleJSON.JSON.Parse(
                File.ReadAllText($"{Application.dataPath}/../Gen/json/{file}.json")
            )
        );
        var item = tables.TbBuff.Get(10110);
        print($"{item.ID} {item.Name}");
    }

    void Update()
    {

    }
}
