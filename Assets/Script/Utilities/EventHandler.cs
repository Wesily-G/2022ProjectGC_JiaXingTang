using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler
{
    //�����¼�����
    public static event Action<GameObject> InteractWithCharac;
    public static void CallInteractWithCharac(GameObject gameObject)
    {
        InteractWithCharac?.Invoke(gameObject);
    }

    //���㻥�����¼��Ĵ�������������ҹ�任
    public static event Action<int> CountEvent;
    public static void CallCountEvent(int count)
    {
        CountEvent?.Invoke(count);
    }

    //��⻥����������������������һ�λ������Σ�����һ�����ˣ������˴ﵽ����������ƻ�
    public static event Action CountTime;
    public static void CallCountTime()
    {
        CountTime?.Invoke();
    }

    //���ٹ˿�
    public static event Action<bool> DestroyCustomer;
    public static void CallDestroyCustomer(bool canDestroy)
    {
        DestroyCustomer?.Invoke(canDestroy);
    }





}
