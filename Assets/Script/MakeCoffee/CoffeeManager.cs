using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeManager : Singleton<CoffeeManager>
{
    public List<CoffeeType> additionList = new List<CoffeeType> ();
}


[System.Serializable]
public class CoffeeType
{
    public int id;
    public string additionName;
}
