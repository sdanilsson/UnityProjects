using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

    private SceneLoader sceneLoader;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison?");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        sceneLoader.LoadScene("Lose Menu");
    }
}
