using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class littleGameController : MonoBehaviour{
	//0δѡ��1ʯͷ��2������3��
	private int playerChoice = 0;
	private int sysChoice = 0;

    private void Update() {
        int num = Random.Range(1, 3);
        sysChoice = num;
    }

    public void btnSelect(int selectNum){
        Debug.Log("btnSelect");
        playerChoice = selectNum;
        int result = Judgement();
        string resultText;
        GameObject resultTxt = gameObject.transform.Find("resultText").gameObject;
        if (result == -1)
            resultText = "lose";
        else if (result == 1)
            resultText = "win";
        else
            resultText = "draw";

        resultTxt.GetComponentInChildren<Text>(true).text = resultText;
        resultTxt.gameObject.SetActive(true);
    }

    //-1�䣬0ƽ�֣�1ʤ��
    private int Judgement(){
        if(playerChoice!=0){
            if (playerChoice == sysChoice)
                return 0;
            else if ((playerChoice == 1 & sysChoice == 2) || (playerChoice == 2 & sysChoice == 3) || (playerChoice == 3 & sysChoice == 1))
                return 1;
            else
                return -1;
        }
        return -2;
    }

}