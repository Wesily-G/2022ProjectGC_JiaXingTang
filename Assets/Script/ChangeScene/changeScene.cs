using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour{
    public string toWhichScene;

    public void switchScene() {
        SceneManager.LoadSceneAsync(toWhichScene);
        Debug.Log(toWhichScene);
    }
}
