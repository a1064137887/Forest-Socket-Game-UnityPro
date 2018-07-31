using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel {

    public Button button;
    public override void OnEnter()
    {
        base.OnEnter();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(this.OnLoginBtnClick);//为按钮添加监听事件
    }


    private void OnLoginBtnClick()
    {
        uiManager.PushPanel(UIPanelType.Login);
    }


}
