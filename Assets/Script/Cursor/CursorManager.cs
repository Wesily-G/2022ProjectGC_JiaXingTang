using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorManager : Singleton<CursorManager>
{
    private bool canClick;

    public GameObject clickObject;

    RaycastHit hitInfo;

    private Vector3 worldPos => Camera.main.WorldToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));


    //注册事件
    private void OnEnable()
    {
        EventHandler.InteractWithCharac += onInteractive;

        EventHandler.CountTime += onCountTime;
    }
    private void OnDisable()
    {
        EventHandler.InteractWithCharac -= onInteractive;

        EventHandler.CountTime -= onCountTime;
    }

    private void onInteractive(GameObject obj)
    {
        //获取点击的对象
        clickObject = obj;
    }




    private void Start()
    {
        Debug.Log("game start");
    }



    private void Update()
    {
        //实时监控鼠标点击的物体，并进行互动
        ClickAction(clickObject);
        clickObject = null; //设空，不然点击一次响应多次
        SetCursorState();
    }

    /// <summary>
    /// 点击事件发生
    /// </summary>
    /// <param name="clickObject"></param>
    public void ClickAction(GameObject clickObject)
    {
        if (clickObject == null) return;
        switch (clickObject.tag)
        {
            case "Customer":
                //顾客事件
                Debug.Log("点击顾客");

                EventHandler.CallCountTime();
                break;
            case "Cat":
                // 撸猫事件
                Debug.Log("cat petting");
                EventHandler.CallCountTime();
                break;
            case "CoffeeMachine":
                //煮咖啡
                Debug.Log("开始煮咖啡");
                
                break;
        }





    }



    /// <summary>
    /// 拓展,设置鼠标图标
    /// </summary>
    void SetCursorState()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log(startPos.x+' '+startPos.y);
            //切换鼠标贴图
            
        }
    }



    public Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(worldPos);
    }



    public void onclick()
    {
        Debug.Log("点击成功");

        var ray = Camera.main.ViewportPointToRay(new Vector3());
        if (Physics.Raycast(ray, out hitInfo))
        {
            

        }
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            { 
                Debug.Log(c.gameObject.tag);
            }
        }
       // Debug.Log(col.Length);
    }


    private void onCountTime()
    {
        CustomerInventory.Instance.count++;
    }


}


