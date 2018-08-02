using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoginPanel : BasePanel {

    public InputField input_username;
    public InputField input_password;
    public Button btn_close;
    public Button btn_login;
    public Button btn_register;

    private float tweenTime = 0.3f;

    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, tweenTime);
        //btn_close = transform.Find("btn_close").GetComponent<Button>();
        btn_close.onClick.AddListener(OnBtnCloseClick);
        btn_login.onClick.AddListener(OnBtnLoginClick);
        btn_register.onClick.AddListener(OnBtnRegisterClick);
    }

    private void OnBtnCloseClick()
    {
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { uiManager.PopPanel(); });
    }

    private void OnBtnLoginClick()
    {
        string tip = "";
        if (string.IsNullOrEmpty(input_username.text))
            tip += " 用户名为空 ";
        if (string.IsNullOrEmpty(input_password.text))
            tip += " 密码为空 ";
        if(tip != "")
        {
            uiManager.ShowMessage(tip);
            return;
        }
    }

    private void OnBtnRegisterClick()
    {

    }

}
