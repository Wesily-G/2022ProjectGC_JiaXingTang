using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler
{
    //互动事件发生
    public static event Action<GameObject> InteractWithCharac;
    public static void CallInteractWithCharac(GameObject gameObject)
    {
        InteractWithCharac?.Invoke(gameObject);
    }

    //计算互动或事件的次数，来控制昼夜变换
    public static event Action<int> CountEvent;
    public static void CallCountEvent(int count)
    {
        CountEvent?.Invoke(count);
    }

    //检测互动次数，当互动次数到达一次或者两次，生成一个客人，当客人达到两个，进入黄昏
    public static event Action CountTime;
    public static void CallCountTime()
    {
        CountTime?.Invoke();
    }

    //销毁顾客
    public static event Action<bool> DestroyCustomer;
    public static void CallDestroyCustomer(bool canDestroy)
    {
        DestroyCustomer?.Invoke(canDestroy);
    }





}
