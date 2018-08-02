using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Common;
using System.Linq;
using System.Text;

public class Message  {

    private const int DATA_MAX_LENGTH = 1024;

    private byte[] data = new byte[DATA_MAX_LENGTH];
    private int startIndex = 0;//存取了多少个字节的数据在数组里面
    public byte[] Data
    {
        get { return data; }
    }

    public int StartIndex
    {
        get { return startIndex; }
    }

    public int RemainSize
    {
        get { return data.Length - startIndex; }
    }

    /// <summary>
    /// 解析数据
    /// </summary>
    /// <param name="newDataAmount"></param>
    /// <param name="processDataCallBack"></param>
    public void ReadMessage(int newDataAmount, Action<ActionCode , string> processDataCallBack)
    {
        startIndex += newDataAmount;
        while (true)
        {
            //最小数据长度大于4，前4位为数据头
            if (startIndex <= 4)
                return;

            int count = BitConverter.ToInt32(data, 0);
            if ((startIndex - 4) >= count)//如果当前消息是完整的
            {
                ActionCode actionCode = (ActionCode)BitConverter.ToInt32(data, 4);//请求协议
                string s = Encoding.UTF8.GetString(data, 8, count - 4);
                Console.WriteLine("解析数据：" + s);
                processDataCallBack(actionCode, s);
                Array.Copy(data, count + 4, data, 0, startIndex - count - 4);
                startIndex -= (count + 4);
            }
            else
            {
                break;
            }
        }
    }


    //public static byte[] PackData(RequestCode requestCode, string data)
    //{
    //    byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
    //    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
    //    int dataAmount = requestCodeBytes.Length + dataBytes.Length;
    //    byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
    //    return dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>().Concat(dataBytes).ToArray<byte>();
    //}

    /// <summary>
    /// 打包从客户端往服务器发送的数据
    /// </summary>
    /// <param name="requestCode">请求</param>
    /// <param name="actionCode">处理</param>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public static byte[] PackData(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
        byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCode);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int dataAmount = requestCodeBytes.Length + actionCodeBytes.Length + dataBytes.Length;
        byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
        //         数据长度                                请求枚举                                                         方法枚举                                                      数据
        return dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>().Concat(actionCodeBytes).ToArray<byte>().Concat(dataBytes).ToArray<byte>();
    }

}
