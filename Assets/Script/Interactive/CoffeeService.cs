using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeService : MonoBehaviour
{

    public GameObject catPrefab;

    public void Service()
    {
        StartCoroutine(MoveToTable());
    }
    public IEnumerator MoveToTable()
    {
        //走到桌前，停下后发生对话
        while (Mathf.Abs(gameObject.transform.position.x - catPrefab.transform.position.x) > 0.1f)
        {
            int speed = 50;
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(catPrefab.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.position.z), step);
            yield return null;
        }
    }
}
