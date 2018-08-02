using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

//请求基类，所有的Request都要放到requestManager中的字典统一管理
public class BaseRequest : MonoBehaviour {

    protected RequestCode requestCode = RequestCode.None;
    protected ActionCode actionCode = ActionCode.None;

	public virtual void Awake () {
        GameFacade.instance.AddRequest(actionCode, this);
	}

    public virtual void SendRequest()
    {

    }

    public virtual void OnResponse(string data)
    {

    }

    public virtual void OnDestroy()
    {
        GameFacade.instance.RemoveRequest(actionCode);
    }
	
}
