using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : BasePanel {

    public Button startBtn;
    public Button exitBtn;

    private float tweenTime = 0.3f;

    private void Start()
    {
        //为按钮添加监听事件
        startBtn.onClick.AddListener(OnLoginBtnClick);
        exitBtn.onClick.AddListener(OnExitBtnClick);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
    }

    public override void OnPause()
    {
        base.OnPause();
        startBtn.gameObject.transform.DOScale(Vector3.zero, tweenTime);
        exitBtn.gameObject.transform.DOScale(Vector3.zero, tweenTime).OnComplete(()=> { gameObject.SetActive(false); });
    }

    public override void OnResume()
    {
        base.OnResume();
        gameObject.SetActive(true);
        startBtn.gameObject.transform.DOScale(Vector3.one, tweenTime);
        exitBtn.gameObject.transform.DOScale(Vector3.one, tweenTime);
    }


    private void OnLoginBtnClick()
    {
        uiManager.PushPanel(UIPanelType.Login);
    }

    private void OnExitBtnClick()
    {
        Debug.Log("===== 退出游戏 =====");
    }


}
