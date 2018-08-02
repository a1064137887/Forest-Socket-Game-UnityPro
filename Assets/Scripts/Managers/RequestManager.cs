using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager {

    private Dictionary<ActionCode, BaseRequest> requestDic = new Dictionary<ActionCode, BaseRequest>();

    public RequestManager(GameFacade facade) : base(facade) { }

    public void AddRequest(ActionCode actionCode,BaseRequest baseRequest)
    {
        requestDic.Add(actionCode, baseRequest);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        if(requestDic.ContainsKey(actionCode))
        {
            requestDic.Remove(actionCode);
        }
    }

    public void HandleResponse(ActionCode actionCode, string data)
    {
        BaseRequest baseRequest = requestDic.TryGet<ActionCode, BaseRequest>(actionCode);
        if(baseRequest == null)
        {
            Debug.LogWarning("未找到相应的ActionCode[" + actionCode + "]对应的Request类");
        }
        baseRequest.OnResponse(data);
    }

}
