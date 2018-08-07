using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RoomListPanel : BasePanel {

    public Button btn_close;
    public Text lb_username;
    public Text lb_totalcount;
    public Text lb_wincount;

    private float tweenTime = 0.3f;

    private void Start()
    {
        btn_close.onClick.AddListener(OnBtnCloseClick);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, tweenTime);
        SetUserPart();
    }

    private void OnBtnCloseClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { uiManager.PopPanel(); });
    }

    /// <summary>
    /// 设置用户信息面板
    /// </summary>
    private void SetUserPart()
    {
        UserData userData = facade.GetUserData();
        lb_username.text = userData.username;
        lb_totalcount.text = "总场数:" + userData.totalCount.ToString();
        lb_wincount.text = "胜场数:" + userData.winCount.ToString();
    }



}
