using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Common;

public class RegisterPanel : BasePanel {

    public InputField input_username;
    public InputField input_password;
    public InputField input_password_re;
    public Button btn_register;
    public Button btn_close;

    private float tweenTime = 0.3f;
    private RegisterRequest registerRequest;

    private void Start()
    {
        btn_register.onClick.AddListener(OnBtnRegisterClick);
        btn_close.onClick.AddListener(OnBtnCloseClick);
        registerRequest = GetComponent<RegisterRequest>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, tweenTime);
    }

    public override void OnExit()
    {
        base.OnExit();
        input_username.text = "";
        input_password.text = "";
        input_password_re.text = "";
        gameObject.SetActive(false);
    }

    private void OnBtnCloseClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { uiManager.PopPanel(); });
    }

    private void OnBtnRegisterClick()
    {
        facade.PlaySound(AudioManager.sound_ButtonClick);
        string tip = "";
        if (string.IsNullOrEmpty(input_username.text))
            tip += "用户名不能为空";
        else if (string.IsNullOrEmpty(input_password.text))
            tip += "密码不能为空";
        if (input_password.text != input_password_re.text)
            tip += "密码不一致";
        if(tip != "")
        {
            uiManager.ShowMessage(tip);
            return;
        }
        //进行注册
        registerRequest.SendRequest(input_username.text, input_password.text);
        Debug.Log("===== 发送注册请求 =====");
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if(returnCode == ReturnCode.Success)
        {
            uiManager.ShowMessageSync("注册成功");
        }
        else if(returnCode == ReturnCode.Fail)
        {
            uiManager.ShowMessageSync("用户名已存在");
        }
    }



}
