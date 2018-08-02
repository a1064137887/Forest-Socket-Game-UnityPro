using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel {

    private float showTime = 2.0f; 
    private Text text;
    private string message = null;

    private void Update()
    {
        if(message != null)
        {
            ShowMessage(message);
            message = null;
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        _uiManager.InjectMessagePanel(this);
    }

    //非主线程不能访问场景中的组件
    public void ShowMessageSync(string message)
    {
        this.message = message;
    }

    public void ShowMessage(string message)
    {
        text.CrossFadeAlpha(1,0.2f, false);
        text.text = message;
        text.enabled = true;
        Invoke("Hide", showTime);
    }

    private void Hide()
    {
        text.CrossFadeAlpha(0, 1.0f, false);
    }

}
