using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    static ScoreKeeper scoreKeeper = null;
    public static int score = 0;

    private void Awake()
    {
        Debug.Log("ScoreKeeper Awake " + GetInstanceID());
        if (scoreKeeper != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed duplicate ScoreKeeper");
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(scoreKeeper);
        }
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("ScoreKeeper Start " + GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

