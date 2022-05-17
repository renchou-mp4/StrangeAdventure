using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMX_1_1 : UIbase {

    //开始游戏
    public override void DoOnEntering()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = true;
    }

    //暂停游戏
    public override void DoOnPausing()
    {

    }

    //恢复游戏
    public override void DoOnResuming()
    {

    }

    //退出游戏
    public override void DoOnExiting()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
    }
}
