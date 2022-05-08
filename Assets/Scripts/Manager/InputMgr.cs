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

        if (h != lastH || v != lastV)
        {
            lastH = h; lastV = v;
            EventDispatcher.instance.DispatchEvent((int)EventDef.InputMoveEvent, DataCenter.GetMyNetIndex(), h, v);
        }
    }
}
