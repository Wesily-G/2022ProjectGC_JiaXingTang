using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextTimePeriod : MonoBehaviour
{
    //当玩家进行了几种互动，时间推进，1.由上午到下午切换图片 2.点击下一天，切换下一天上午图片
    public Sprite spriteMorning;
    public Sprite spriteEvening;
    public Sprite spriteEveningPlus;
    private Sprite tempSpriteM;
    private Sprite tempSpriteE;
    

    Button nextDayBtn;

    ScrollRect.ScrollRectEvent scrollRectEvent;

   

    //todo:将互动数目或这其他计量传递过来
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
        //定时设置图片
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

    //todo:更新count
    public void UpdateCount()
    {

    }


    /// <summary>
    /// 点击下一天按钮
    /// </summary>
    private void onClickNextDay()
    {
        spriteMorning = tempSpriteM;
        spriteEvening = null;
        count = 0;
    }

}
