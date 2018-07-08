using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer player = null;

    private void Awake()
    {
        Debug.Log("Music player Awake " + GetInstanceID());
        if (player != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed duplicate music player");
        }
        else
        {
            player = this;
            DontDestroyOnLoad(player);
        }
    }
    // Use this for initialization
    void Start () {
        Debug.Log("Music player Start " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
