using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Customer : Interactive
{
    public Fungus.SayDialog sayDialog;
    //根据日期生成对应客人，每个客人有对应行为树
    // 分为8个时间段 0 1 2 3 大白天，4，5，6黄昏，7晚上,生成的同时无法销毁
    public CustomerData_so customerData;
    public GameObject catPrefab;
    Flowchart flowchart, flowchat_Girl;

    bool isComing;

    int cus = 0;


    protected override void Start()
    {
        //base.Start();
        //var test = FindObjectOfType<Fungus.SayDialog>();
        //sayDialog.StoryText = customerData.customerList[0].dialogText[0];
        cus = CustomerInventory.Instance.count; //记录下时间
        //Fungus.Flowchart
        Debug.Log(CustomerInventory.Instance.flowcharPrefab.transform.GetChild(CustomerInventory.Instance.index).gameObject.name+"!!!!");
        flowchart = GameObject.Find(CustomerInventory.Instance.flowcharPrefab.transform.GetChild(CustomerInventory.Instance.index).gameObject.name).GetComponent<Flowchart>();
        Debug.Log("hello");
        StartCoroutine(ExecutePlot());
      

    }


    private void Update()
    {
        //更新顾客状态，随机离场和固定对话，主要负责销毁已经出现的customer
        //销毁必须在对话完之后
        flowchart = CustomerInventory.Instance.flowchartList[CustomerInventory.Instance.index];

        
        //int a = (CustomerInventory.Instance.cust + cus) % 7;
        if (CustomerInventory.Instance.count == 4 ||
           CustomerInventory.Instance.count == 5 || CustomerInventory.Instance.count == 6)
        {

            //如果顾客生成时间与销毁时间一致，就会导致死循环
            if (CustomerInventory.Instance.count == CustomerInventory.Instance.generateCount) return;


            //允许新客人
            CustomerInventory.Instance.isComing = false;
            CustomerInventory.Instance.index++;
            if (CustomerInventory.Instance.index == CustomerInventory.Instance.customerPrefabList.Count)
                CustomerInventory.Instance.index--;

            //消失之前生成
            CustomerInventory.Instance.cust = Random.Range(1, 5);
            //角色消失
            this.gameObject.SetActive(false);
        }


        //if (CustomerInventory.Instance.count == 6)
        //{
        //    CustomerInventory.Instance.count = 0;
            
        //    //todo:店打烊了
            

        //    //获取新客人
        //    flowchart = GameObject.Find(CustomerInventory.Instance.flowchartList[CustomerInventory.Instance.index].transform.GetChild(CustomerInventory.Instance.index).gameObject.name).GetComponent<Flowchart>();
        //}
    }

    public IEnumerator StartScene()
    {
        if (flowchart.HasBlock("customerOccur"))
        {
            flowchart.ExecuteBlock("customerOccur");
        }
        yield return null;
    }


    public IEnumerator ExecutePlot()
    {
        yield return StartScene();
        yield return new WaitForSeconds(2.0f);
        while (gameObject.transform.position.x - catPrefab.transform.position.x > 0.1f)
        {
            int speed = 50;
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(catPrefab.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.position.z), step);
            yield return null;
        }

        Debug.Log("??");
        yield return new WaitForSeconds(2.0f);
        yield return Plot1();

        yield return new WaitForSeconds(2.0f); //停顿一下，点餐
        yield return Order();


        //女主说话

    }

    public IEnumerator Plot1()
    {
        if (flowchart.HasBlock("sayToSelf"))
        {
            flowchart.ExecuteBlock("sayToSelf");
        }
        yield return null;
    }

    public IEnumerator Order()
    {
        //点餐
        if (flowchart.HasBlock("OrderCoffee"))
        {
            flowchart.ExecuteBlock("OrderCoffee");
        }
        yield return null;
    }












}
