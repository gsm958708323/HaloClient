using System.Collections;
using UnityEngine;


public class InputMgr : MonoBehaviour
{
    float lastH, lastV = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        int netIndex = DataCenter.GetMyNetIndex();

        if (h != lastH || v != lastV)
        {
            lastH = h; lastV = v;
            EventDispatcher.instance.DispatchEvent((int)EventDef.InputMoveEvent, netIndex, h, v);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            EventDispatcher.instance.DispatchEvent((int)EventDef.InputSkillEvent, netIndex, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            EventDispatcher.instance.DispatchEvent((int)EventDef.InputSkillEvent, netIndex, 1);
        }
    }
}
