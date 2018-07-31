using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoginPanel : BasePanel {

    public override void OnEnter()
    {
        base.OnEnter();
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f);
    }

}
