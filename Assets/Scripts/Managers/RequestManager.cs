using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager {

    private Dictionary<RequestCode, BaseRequest> requestDic = new Dictionary<RequestCode, BaseRequest>();

    public RequestManager(GameFacade facade) : base(facade) { }

    public void AddRequest(RequestCode requestCode,BaseRequest baseRequest)
    {
        requestDic.Add(requestCode, baseRequest);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        if(requestDic.ContainsKey(requestCode))
        {
            requestDic.Remove(requestCode);
        }
    }

    public void HandleResponse(RequestCode requestCode,string data)
    {
        BaseRequest baseRequest = requestDic.TryGet<RequestCode, BaseRequest>(requestCode);
        if(baseRequest == null)
        {
            Debug.LogWarning("未找到相应的RequestCode["+requestCode+"]对应的Request类");
        }
        baseRequest.OnResponse(data);
    }

}
