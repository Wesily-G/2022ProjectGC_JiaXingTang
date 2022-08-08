using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }   //可读
    }



    protected virtual void Awake()
    {
        if (instance != null)
        {

            // Destroy(gameObject);
        }
        else instance = (T)this;
    }


    //判断是否初始化成功
    public static bool isInitialized
    {
        get { return instance != null; }
    }

    protected virtual void onDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }


}
