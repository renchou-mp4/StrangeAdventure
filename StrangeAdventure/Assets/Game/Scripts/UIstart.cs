using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIstart : UIbase {
    //开始游戏
    public override void DoOnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        SoundManager.Instance.PlayBGM("Audio_bgm_1");
    }

    //暂停游戏
    public override void DoOnPausing()
    {
        gameObject.SetActive(false);
    }

    //恢复游戏
    public override void DoOnResuming()
    {
        gameObject.SetActive(true);
    }

    //退出游戏
    public override void DoOnExiting()
    {

    }

    public void GoToOption()
    {
        UImanager.Instance.PushUIpanel("UIOption");
    }

    public void GoToPlay()
    {
        UImanager.Instance.PushUIpanel("TMX_1_1");
    }
}
