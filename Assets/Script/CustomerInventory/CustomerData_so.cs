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
    // 1.ÌùÍ¼ 2.¶Ô»° 3.Ãû×Ö 4.×´Ì¬
    public SpriteRenderer spriteRenderer;
    public List<string> dialogText = new List<string>();
    public string customerName;
    public CustomerStates customerStates;
}
