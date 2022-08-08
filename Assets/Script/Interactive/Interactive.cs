using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    public Button clickPart;


    protected virtual void Start()
    {
        clickPart = this.GetComponentInChildren<Button>();
        clickPart.onClick.AddListener(onClickBtn);
    }

    public void onClickBtn()
    {
        EventHandler.CallInteractWithCharac(this.gameObject);
    }



}
