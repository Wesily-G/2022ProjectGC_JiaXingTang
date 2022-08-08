using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneController : MonoBehaviour
{
    public GameObject phone;
    public Sprite imageSprite;

    public void switchPhoneImage(){
        phone.GetComponent<Image>().sprite = imageSprite;       
    }
}
