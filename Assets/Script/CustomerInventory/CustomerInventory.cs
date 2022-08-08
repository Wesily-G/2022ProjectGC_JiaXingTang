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
    
    //�����
    public int cnt = 0; //Ϊ�������
    public int cust = 0; //Ϊcustomer����

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
        //��������ʱ����̣�ʱ��0��7����ʵ����,1-6�������2-3����
        if(count == 7)
        {
            //������
            if (flowchat_Girl.HasBlock("End"))
            {
                flowchat_Girl.ExecuteBlock("End");
            }
        }


        cnt = Random.Range(1, 5);
        //Debug.Log(count+"  "+isComing+" "+index);
        if (1<=cnt && cnt <=3 && count > 0 && count <7 && !isComing)
        {
            
            //ʵ�������˿�
            customerPrefabList[index].gameObject.SetActive(true);
            Debug.Log("count:" + count + "index:" + index);
            isComing = true;
            generateCount = count;

            //���ÿ�����
        }

    }



 


   
}
