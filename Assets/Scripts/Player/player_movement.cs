using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float playerSpeed = 10;
    private bool facingright = false;
    public int playerjump = 1250;
    public bool isgrounded;

	public float rampUpTime = 0;
	public float ChangeSpeed = 0;
	public float ChangeTime = 0;
	public float addToSpeed = 0;

	private Swipe Swipe_Controls;

	private void Awake()
	{
		Swipe_Controls = GetComponent<Swipe>();
	}
	
	// Update is called once per frame
	void Update()
    {
        playermove();
		rampUp();
        //playerRayCast();
    }

	void rampUp()
	{

		rampUpTime -= Time.deltaTime;

		if (rampUpTime < ChangeSpeed)
		{
			Debug.Log(playerSpeed);
			playerSpeed = playerSpeed + addToSpeed;
			rampUpTime = ChangeTime;
		}
	}

    void playermove()
    {
        //Control
        //moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") || Swipe_Controls.swipeUp == true)
        {
            jump();
        }

		//if (Swipe_Controls.tap == true)
			//Debug.Log("tap");

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		

    }


    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerjump);
        isgrounded = false;
    }

    void flipPlayer()
    {
        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D ground)
    {
        //Debug.Log("Player has hit the " + ground.collider.name); //collision detection for the player debug
                                                                 /*if (ground.gameObject.tag == "ground")
                                                                 {
                                                                     isgrounded = true;
                                                                 }*/
                                                                 //Code above is for cheking the tag is it is ground and returns true if it is.
    }

    /*
    void playerRayCast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < 0.9f && rayUp.collider.name == "QuestionBox")
        {
            Debug.Log("hit QuestionBox");
            Destroy(rayUp.collider.gameObject);
        }



        //shoots a ray down from the player and when it touches the enemy it should do something. Here the player will bounce off the enemy
        //Ray Down
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag == "enemy")
        { //spot where the player will then interact with the other box collider.
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            Debug.Log("Harassed enemy");
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false; //USING THIS FUNCTION, YOU CAN DISABLE OR ENABLE UNITY OPTIONS OR SCRIPTS
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<enemyMove>().enabled = false; //the statement to call the other scripts!

        }

        RaycastHit2D wallslide = Physics2D.Raycast(transform.position, Vector2.right);

        //TODO FIX the code for sliding down wall
        if(wallslide.distance < 0.6f)
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1000);
			Debug.Log("Slide down");
		}

        //jump off any object only if they aren't an enemy
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.8f && rayDown.collider.tag != "enemy")
        {
            isgrounded = true;
        }
    }*/
}


//Vector2 is the x and y coordinate