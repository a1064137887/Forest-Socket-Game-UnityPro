using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

//请求基类，所有的Request都要放到requestManager中的字典统一管理
public class BaseRequest : MonoBehaviour {

    protected RequestCode requestCode = RequestCode.None;
    protected ActionCode actionCode = ActionCode.None;
    protected GameFacade facade;
    public void SetFacade(GameFacade facade)
    {
        this.facade = facade;
    }

	public virtual void Awake () {
        GameFacade.instance.AddRequest(actionCode, this);
        facade = GameFacade.instance;
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

    protected void SendRequest(string data)
    {
        //利用facade作为中介发送，requestCode和actionCode在每个继承类中已经赋值
        facade.SendRequest(requestCode, actionCode, data);
    }
	
}
