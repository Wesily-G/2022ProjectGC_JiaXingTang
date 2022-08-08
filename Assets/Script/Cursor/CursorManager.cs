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


    //ע���¼�
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
        //��ȡ����Ķ���
        clickObject = obj;
    }




    private void Start()
    {
        Debug.Log("game start");
    }



    private void Update()
    {
        //ʵʱ�������������壬�����л���
        ClickAction(clickObject);
        clickObject = null; //��գ���Ȼ���һ����Ӧ���
        SetCursorState();
    }

    /// <summary>
    /// ����¼�����
    /// </summary>
    /// <param name="clickObject"></param>
    public void ClickAction(GameObject clickObject)
    {
        if (clickObject == null) return;
        switch (clickObject.tag)
        {
            case "Customer":
                //�˿��¼�
                Debug.Log("����˿�");

                EventHandler.CallCountTime();
                break;
            case "Cat":
                // ߣè�¼�
                Debug.Log("cat petting");
                EventHandler.CallCountTime();
                break;
            case "CoffeeMachine":
                //�󿧷�
                Debug.Log("��ʼ�󿧷�");
                
                break;
        }





    }



    /// <summary>
    /// ��չ,�������ͼ��
    /// </summary>
    void SetCursorState()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log(startPos.x+' '+startPos.y);
            //�л������ͼ
            
        }
    }



    public Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(worldPos);
    }



    public void onclick()
    {
        Debug.Log("����ɹ�");

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


