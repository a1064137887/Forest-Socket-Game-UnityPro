using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameFacade : MonoBehaviour {

    private static GameFacade _instance;
    public static GameFacade instance
    {
        get { return _instance; }
    }

    private UIManager uiManager;
    private AudioManager audioManager;
    private CameraManager cameraManager;
    private RequestManager requestManager;
    private PlayerManager playerManager;
    private ClientManager clientManager;

    void Awake()
    {
        if(_instance == null)
            _instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

	void Start () {
        InitManager();
	}
	
	void Update () {
		 
	}

    private void InitManager()
    {
        uiManager = new UIManager(this);
        audioManager = new AudioManager(this);
        cameraManager = new CameraManager(this);
        requestManager = new RequestManager(this);
        playerManager = new PlayerManager(this);
        clientManager = new ClientManager(this);

        uiManager.OnInit();
        audioManager.OnInit();
        cameraManager.OnInit();
        requestManager.OnInit();
        playerManager.OnInit();
        clientManager.OnInit();
    }

    private void DestroyManager()
    {
        uiManager.OnDestroy();
        audioManager.OnDestroy();
        cameraManager.OnDestroy();
        requestManager.OnDestroy();
        playerManager.OnDestroy();
        clientManager.OnDestroy();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    //使用中介的方法 ，调用RequestManager类中的方法，管理Request
    public void AddRequest(ActionCode actionCode, BaseRequest baseRequest)
    {
        requestManager.AddRequest(actionCode, baseRequest);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        requestManager.RemoveRequest(actionCode);
    }
    //========================================

    public void HandleResponse(ActionCode actionCode, string data)
    {
        requestManager.HandleResponse(actionCode, data);
    }

    public void ShowMessage(string message)
    {
        uiManager.ShowMessage(message);
    }

}
