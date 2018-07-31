﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel {

    private float showTime = 2.0f; 
    private Text text;

    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        _uiManager.InjectMessagePanel(this);
    }

    public void ShowMessage(string message)
    {
        text.color = Color.white;
        //text.color = new Vector4(255, 255, 255, 1);
        text.text = message;
        text.enabled = true;
        Invoke("Hide", showTime);
    }

    private void Hide()
    {
        text.CrossFadeAlpha(0, 1.0f, false);
    }

}