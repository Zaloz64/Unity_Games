using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Ball_movment : MonoBehaviour {
    bool start = false;
    public int speedball_X = 7;
    int speedball_Y = 7;
    int score_right = 0;
    int score_left = 0;
    public Text rightscore;
    public Text leftscore;
    float time = 1;
    public Player_controller pc;
    public Player_controller2 pc2;

    // Use this for initialization
    void Start () {
		
	}

    private void OnMouseDown()
    {

    }

    // Update is called once per frame
    void Update () {

        time += 1 * (Time.deltaTime/100);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            //ball start movment
            start = true;
        }  
        if (start == true)
        {
            //movment side to side
            gameObject.transform.Translate(1 * Time.deltaTime * speedball_X * time, 1* Time.deltaTime * speedball_Y * time, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with player");

        if (collision.gameObject.CompareTag("Top_wall") == true || collision.gameObject.CompareTag("Bottom_wall") == true)
        {
            speedball_Y *= -1;
        }

        if (collision.gameObject.CompareTag("Player_left") == true || collision.gameObject.CompareTag("Player_right") == true)
        {
            speedball_X *= -1;
        }

        if (collision.gameObject.CompareTag("Left_wall") == true)
        {
            //Right player won
            score_right++;
            restart();
        }

        if (collision.gameObject.CompareTag("Right_wall") == true)
        {
            //left player won
            score_left++;
            restart();
        }

    }

    void restart()
    {
        Vector3 resetposition = new Vector3(0, 0, 0);
        gameObject.transform.position = resetposition;
        start = false;

        rightscore.text = Convert.ToString(score_right);
        leftscore.text = Convert.ToString(score_left);
        time = 1;
        pc.activateAI = false;
        pc2.activateAI = false;
    }
}
