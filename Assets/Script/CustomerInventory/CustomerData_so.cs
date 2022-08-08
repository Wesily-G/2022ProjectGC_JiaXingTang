using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new customer",menuName ="Customer/customerData_so")]
public class CustomerData_so : ScriptableObject
{
    public List<customerDetails> customerList = new List<customerDetails>();
}

[System.Serializable]
public class customerDetails
{
    // 1.��ͼ 2.�Ի� 3.���� 4.״̬
    public SpriteRenderer spriteRenderer;
    public List<string> dialogText = new List<string>();
    public string customerName;
    public CustomerStates customerStates;
}
