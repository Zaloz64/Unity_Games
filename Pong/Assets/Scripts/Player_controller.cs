using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {
    public int speed = 10;
    bool moveup = true;
    bool movedown = true;
    float time = 1;

    public bool activateAI = false;
    public Transform ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        time += 1 * (Time.deltaTime / 100);

        if (activateAI == false)
        {
            if (Input.GetKey(KeyCode.W) == true && moveup == true)
            {
                //Move upp
                gameObject.transform.Translate(0, 1 * Time.deltaTime * speed * time, 0);
            }
            if (Input.GetKey(KeyCode.S) == true && movedown == true)
            {
                //Move down
                gameObject.transform.Translate(0, -1 * Time.deltaTime * speed * time, 0);
            }
        }

        else
        {
            gameObject.transform.position = new Vector3(-7, ball.position.y, 0);
        }

        if (Input.GetKey(KeyCode.T) == true)
        {
            activateAI = true;
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with walls");
        if(collision.gameObject.CompareTag("Top_wall") == true)
        {
            moveup = false;
        }
        if (collision.gameObject.CompareTag("Bottom_wall") == true)
        {
            movedown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided no more with walls");
        if (collision.gameObject.CompareTag("Top_wall") == true)
        {
            moveup = true;
        }
        if (collision.gameObject.CompareTag("Bottom_wall") == true)
        {
            movedown = true;
        }
    }
}
