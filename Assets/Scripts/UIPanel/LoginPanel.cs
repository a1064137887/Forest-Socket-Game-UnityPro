using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Common;

public class LoginPanel : BasePanel {

    public InputField input_username;
    public InputField input_password;
    public Button btn_close;
    public Button btn_login;
    public Button btn_register;

    private float tweenTime = 0.3f;
    private LoginRequest loginRequest;

    private void Start()
    {
        btn_close.onClick.AddListener(OnBtnCloseClick);
        btn_login.onClick.AddListener(OnBtnLoginClick);
        btn_register.onClick.AddListener(OnBtnRegisterClick);
        loginRequest = GetComponent<LoginRequest>();
        
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, tweenTime);
    }

    public override void OnPause()
    {
        base.OnPause();
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { gameObject.SetActive(false); });
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }

    private void OnBtnCloseClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { uiManager.PopPanel(); });
    }

    private void OnBtnLoginClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
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

        loginRequest.SendRequest(input_username.text, input_password.text);
    }

    private void OnBtnRegisterClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
        uiManager.PushPanel(UIPanelType.Register);
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        if(returnCode == ReturnCode.Success)
        {
            uiManager.ShowMessageSync("登录成功");
            uiManager.PushPanelSync(UIPanelType.RoomList);
        }
        else if(returnCode == ReturnCode.Fail)
        {
            uiManager.ShowMessageSync("用户名或密码错误");
        }
    }

}
