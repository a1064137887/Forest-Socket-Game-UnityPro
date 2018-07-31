using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Common;

public class ClientManager : BaseManager  {

    public ClientManager(GameFacade facade) : base(facade) { }

    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Message message = new Message();
    private Socket clientSocket;

    public override void OnInit()
    {
        base.OnInit();
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
            Start();
        }
        catch(Exception ex)
        {
            Debug.LogWarning("无法连接服务器" + ex);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            clientSocket.Close();
        }
        catch
        {
            Debug.Log("无法关闭客户端连接");
        }
    }

    private void Start()
    {
        clientSocket.BeginReceive(message.Data,message.StartIndex,message.RemainSize,SocketFlags.None,ReceiveCallBack,null);
    }

    private void ReceiveCallBack(IAsyncResult ar)
    {
        try
        {
            int count = clientSocket.EndReceive(ar);
            message.ReadMessage(count, OnProcessDataCallBack);
            Start();
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }
    }

    private void OnProcessDataCallBack(RequestCode requestCode,string data)
    {
        facade.HandleResponse(requestCode, data);
    }

    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }

}
