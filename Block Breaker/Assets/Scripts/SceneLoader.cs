using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
    
    public Text mytext;

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(string name){
        SceneManager.LoadScene(name);
    }

    public void PlayAgain(){
        Debug.Log("Trying to load the next scene");
        Brick.breakableCount = 0;
        ScoreKeeper.score = 0;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }


    public void BrickDestroyed(int brickValue){
        ScoreKeeper.score += brickValue;
        mytext = GameObject.Find("ScoreText").GetComponent<Text>();
        mytext.text = "Score: " + ScoreKeeper.score;
        Debug.Log("Number of bricks left" + Brick.breakableCount);
        if(Brick.breakableCount <= 0){
            Debug.Log("All bricks destroyed");
            LoadNextScene();
        }
    }
}
