using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour {

    private UIManager uiManager;
    private AudioManager audioManager;
    private CameraManager cameraManager;
    private RequestManager requestManager;
    private PlayerManager playerManager;
    private ClientManager clientManager;

	void Start () {
        InitManager();
	}
	
	void Update () {
		
	}

    private void InitManager()
    {
        uiManager = new UIManager();
        audioManager = new AudioManager();
        cameraManager = new CameraManager();
        requestManager = new RequestManager();
        playerManager = new PlayerManager();
        clientManager = new ClientManager();

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


}
