using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Customer : Interactive
{
    public Fungus.SayDialog sayDialog;
    //�����������ɶ�Ӧ���ˣ�ÿ�������ж�Ӧ��Ϊ��
    // ��Ϊ8��ʱ��� 0 1 2 3 ����죬4��5��6�ƻ裬7����,���ɵ�ͬʱ�޷�����
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
        cus = CustomerInventory.Instance.count; //��¼��ʱ��
        //Fungus.Flowchart
        Debug.Log(CustomerInventory.Instance.flowcharPrefab.transform.GetChild(CustomerInventory.Instance.index).gameObject.name+"!!!!");
        flowchart = GameObject.Find(CustomerInventory.Instance.flowcharPrefab.transform.GetChild(CustomerInventory.Instance.index).gameObject.name).GetComponent<Flowchart>();
        Debug.Log("hello");
        StartCoroutine(ExecutePlot());
      

    }


    private void Update()
    {
        //���¹˿�״̬������볡�͹̶��Ի�����Ҫ���������Ѿ����ֵ�customer
        //���ٱ����ڶԻ���֮��
        flowchart = CustomerInventory.Instance.flowchartList[CustomerInventory.Instance.index];

        
        //int a = (CustomerInventory.Instance.cust + cus) % 7;
        if (CustomerInventory.Instance.count == 4 ||
           CustomerInventory.Instance.count == 5 || CustomerInventory.Instance.count == 6)
        {

            //����˿�����ʱ��������ʱ��һ�£��ͻᵼ����ѭ��
            if (CustomerInventory.Instance.count == CustomerInventory.Instance.generateCount) return;


            //�����¿���
            CustomerInventory.Instance.isComing = false;
            CustomerInventory.Instance.index++;
            if (CustomerInventory.Instance.index == CustomerInventory.Instance.customerPrefabList.Count)
                CustomerInventory.Instance.index--;

            //��ʧ֮ǰ����
            CustomerInventory.Instance.cust = Random.Range(1, 5);
            //��ɫ��ʧ
            this.gameObject.SetActive(false);
        }


        //if (CustomerInventory.Instance.count == 6)
        //{
        //    CustomerInventory.Instance.count = 0;
            
        //    //todo:�������
            

        //    //��ȡ�¿���
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

        yield return new WaitForSeconds(2.0f); //ͣ��һ�£����
        yield return Order();


        //Ů��˵��

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
        //���
        if (flowchart.HasBlock("OrderCoffee"))
        {
            flowchart.ExecuteBlock("OrderCoffee");
        }
        yield return null;
    }












}
