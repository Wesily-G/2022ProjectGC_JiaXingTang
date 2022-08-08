using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextTimePeriod : MonoBehaviour
{
    //����ҽ����˼��ֻ�����ʱ���ƽ���1.�����絽�����л�ͼƬ 2.�����һ�죬�л���һ������ͼƬ
    public Sprite spriteMorning;
    public Sprite spriteEvening;
    public Sprite spriteEveningPlus;
    private Sprite tempSpriteM;
    private Sprite tempSpriteE;
    

    Button nextDayBtn;

    ScrollRect.ScrollRectEvent scrollRectEvent;

   

    //todo:��������Ŀ���������������ݹ���
    public int count;

    private void Start()
    {
        //nextDayBtn = GetComponent<Button>();
        //nextDayBtn.onClick.AddListener(onClickNextDay);
        tempSpriteM = spriteMorning;
        tempSpriteE = spriteEvening;
    }


    private void Update()
    {
        //��ʱ����ͼƬ
        if(CustomerInventory.Instance != null && (CustomerInventory.Instance.count == 4|| CustomerInventory.Instance.count == 5|| CustomerInventory.Instance.count == 6))
        {
            //Debug.Log(CustomerInventory.Instance.count);
            this.gameObject.GetComponent<Image>().sprite = spriteEvening;
        }
        else if(CustomerInventory.Instance != null && (CustomerInventory.Instance.count ==7))
        {
            Debug.Log("!!");
            this.gameObject.GetComponent<Image>().sprite = spriteEveningPlus;
            count = 0;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = spriteMorning;
        }


    }

    //todo:����count
    public void UpdateCount()
    {

    }


    /// <summary>
    /// �����һ�찴ť
    /// </summary>
    private void onClickNextDay()
    {
        spriteMorning = tempSpriteM;
        spriteEvening = null;
        count = 0;
    }

}
