using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BasePanel {

    public Button startBtn;
    public Button exitBtn;

    private float tweenTime = 0.3f;

    public override void OnEnter()
    {
        base.OnEnter();
        startBtn.onClick.AddListener(this.OnLoginBtnClick);//为按钮添加监听事件
    }

    public override void OnPause()
    {
        base.OnPause();
        startBtn.gameObject.transform.DOScale(Vector3.zero, tweenTime);
    }

    public override void OnResume()
    {
        base.OnResume();
        startBtn.gameObject.transform.DOScale(Vector3.one, tweenTime);
    }


    private void OnLoginBtnClick()
    {
        uiManager.PushPanel(UIPanelType.Login);
    }


}
