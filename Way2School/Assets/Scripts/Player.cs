using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float JumpHegiht;
    public float HorizontalSpeed;
    public Text ScoreText;

    private int score = 0;
    private int Health;
    private Rigidbody2D rigidbody2D;
    private bool isGround;

	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();

	    ScoreText.text = "Score: " + score;

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow))
	    {
	        transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime);
	    }

	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
	    }

	    if (Input.GetKey(KeyCode.UpArrow) && isGround)
	    {
	        rigidbody2D.AddForce(new Vector2(0, JumpHegiht));
	        isGround = false;
	    }

	    ScoreText.text = "Score: " + score;
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Apple")
        {
            Debug.Log("Apple collected");
            score += 50;
            other.gameObject.SetActive(false);
        }

        //if (EnemyScript.)
        //{
            if (other.tag == "Dog")
        {
            Debug.Log("Dog hit");
            score -= 20;
        }

        //}
        if (other.tag == "Platform")
        {
            isGround = true;
        }
        
    }


}
