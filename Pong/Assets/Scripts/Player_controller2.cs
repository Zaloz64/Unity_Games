using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller2 : MonoBehaviour {

    public int speed1 = 20;
    bool moveup1 = true;
    bool movedown1 = true;
    float time = 1;

    public bool activateAI = false;
    public Transform ball;



    // Update is called once per frame
    void Update()
    {
        time += 1 * (Time.deltaTime / 100);

        if (activateAI == false){

            if (Input.GetKey(KeyCode.I) == true && moveup1 == true)
            {
                //Move upp
                gameObject.transform.Translate(0, 1 * Time.deltaTime * speed1 * time, 0);
            }
            if (Input.GetKey(KeyCode.K) == true && movedown1 == true)
            {
                //Move down
                gameObject.transform.Translate(0, -1 * Time.deltaTime * speed1 * time, 0);
            }
        }

        else
        {
            gameObject.transform.position = new Vector3(7, ball.position.y, 0);
        }

        if (Input.GetKey(KeyCode.P) == true)
        {
            activateAI = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with walls");
        if (collision.gameObject.CompareTag("Top_wall") == true)
        {
            moveup1 = false;
        }
        if (collision.gameObject.CompareTag("Bottom_wall") == true)
        {
            movedown1 = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided no more with walls");
        if (collision.gameObject.CompareTag("Top_wall") == true)
        {
            moveup1 = true;
        }
        if (collision.gameObject.CompareTag("Bottom_wall") == true)
        {
            movedown1 = true;
        }
    }
}
