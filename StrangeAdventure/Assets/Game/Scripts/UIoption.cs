using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIoption : UIbase {

    //开始游戏
    public override void DoOnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        gameObject.SetActive(true);
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
        gameObject.SetActive(false);
    }
    //返回开始页面
    public void BackToStart()
    {
        UImanager.Instance.PopUIpanel();
    }
    //将音乐静音
    public void SetBGMMUte(bool mute)
    {
        SoundManager.Instance.Mute = mute; 
    }


}
