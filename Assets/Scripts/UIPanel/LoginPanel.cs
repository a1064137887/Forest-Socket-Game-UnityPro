using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoginPanel : BasePanel {

    private Button btn_close;
    private float tweenTime = 0.3f;

    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, tweenTime);
        btn_close = transform.Find("btn_close").GetComponent<Button>();
        btn_close.onClick.AddListener(OnBtnCloseClick);
    }

    private void OnBtnCloseClick()
    {
        transform.DOScale(Vector3.zero, tweenTime).OnComplete(() => { uiManager.PopPanel(); });
    }

}
