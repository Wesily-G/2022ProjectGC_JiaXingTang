using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CustomerInventory :Singleton<CustomerInventory>
{
    public Dictionary<customerDetails, bool> customerStoreDict = new Dictionary<customerDetails, bool>();
    public int days = 5;
    public int count = 1;
    public bool isComing;
    
    //随机数
    public int cnt = 0; //为本类服务
    public int cust = 0; //为customer服务

    public Flowchart flowchart, flowchat_Girl;

    public List<Flowchart> flowchartList = new List<Flowchart>();
 

    public GameObject flowcharPrefab;

    public List<GameObject> customerPrefabList = new List<GameObject>();

    public int index = 0;

    public int generateCount;



    private void Start()
    {
        
    }
    private void Update()
    {
        //控制整体时间进程，时刻0，7不能实例化,1-6随机生成2-3个人
        if(count == 7)
        {
            //打烊了
            if (flowchat_Girl.HasBlock("End"))
            {
                flowchat_Girl.ExecuteBlock("End");
            }
        }


        cnt = Random.Range(1, 5);
        //Debug.Log(count+"  "+isComing+" "+index);
        if (1<=cnt && cnt <=3 && count > 0 && count <7 && !isComing)
        {
            
            //实例化出顾客
            customerPrefabList[index].gameObject.SetActive(true);
            Debug.Log("count:" + count + "index:" + index);
            isComing = true;
            generateCount = count;

            //调用开场白
        }

    }



 


   
}
