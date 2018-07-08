using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    private int timesHit;
    private SceneLoader loader;
    public Sprite[] hitSprites;
    private bool isBreakable;
    public AudioClip crack;
    public int value;
    public GameObject smoke;

	void Start () {
        timesHit = 0;
        loader = GameObject.FindObjectOfType<SceneLoader>();
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if(isBreakable) {
            breakableCount++;
            Debug.Log("Breakable count: " + breakableCount);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable) {
            HandleHits();    
        }

    }


    void HandleHits () {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (maxHits <= timesHit) {
            breakableCount--;
            ShowParticles();
            Destroy(gameObject);
            loader.BrickDestroyed(this.value);
        }
        else {
            LoadSprites();
        }
    }

    void ShowParticles(){
        GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity);
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startColor = this.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites(){
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];    
        }

    }

    void SimulateWin(){
        loader.LoadNextScene();
    }
}
