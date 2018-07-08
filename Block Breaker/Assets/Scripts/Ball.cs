using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rBody;
    private AudioSource sound;
    private bool hasStarted = false;

    private void Awake()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print("Paddle to ball vector" + paddleToBallVector);

	}

    // Update is called once per frame
    void Update()
    {
        // Lock the ball to the paddle
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;
               
            // Start the game by clicking the mouse button
            if (Input.GetMouseButtonDown(0)) {
                hasStarted = true;
                rBody.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rBody.velocity += tweak;
        if(hasStarted){
            sound = GetComponent<AudioSource>();
            sound.Play();    
        }

    }
}
