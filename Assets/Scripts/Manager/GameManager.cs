/* ==============================================================================
* 功能描述：GameManager 
* 创 建 者：#CreateAuthor#
* 创建日期：#CREATETIME#
* ==============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<ConfigMgr>();
        gameObject.AddComponent<FightMgr>();
        gameObject.AddComponent<ResMgr>();
        gameObject.AddComponent<InputMgr>();
        gameObject.AddComponent<AudioMgr>();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
