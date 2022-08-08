using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagerScript : MonoBehaviour{

    public void startGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame(){
        Application.Quit();
    }

    public void switchScene(string toWhichScene) {
        SceneManager.LoadSceneAsync(toWhichScene);
        Debug.Log(toWhichScene);
    }
}
