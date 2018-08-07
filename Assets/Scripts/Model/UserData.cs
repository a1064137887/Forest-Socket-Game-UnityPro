using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class UserData
{
    public string username { get; set; }
    public int totalCount { get; set; }
    public int winCount { get; set; }

    public UserData() { }
    public UserData(string username,int totalCount,int winCount)
    {
        this.username = username;
        this.totalCount = totalCount;
        this.winCount = winCount;
    }


}
