using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour {
    protected UIManager _uiManager;
    public UIManager uiManager
    {
        set { _uiManager = value; }
        get { return _uiManager; }
    }

    protected GameFacade _facade;
    public GameFacade facade
    {
        set { _facade = value; }
        get { return _facade; }
    }
    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public virtual void OnExit()
    {

    }
}
