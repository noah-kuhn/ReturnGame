﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    /*
     * Class for all playable characters- Ava, Clara, etc
     */

    //Movement speed
    public float moveSpeed = 0.01f;
	private bool canMove = true;

    //Gets the Rigidbody component for movement
    private Rigidbody2D rb2d;

    public string direction;
	
	
	[SerializeField] int health;
	[SerializeField] int damage;
	[SerializeField] int armor;

    // Start is called before the first frame update
    void Start()
    {
        //Gets this object's Rigidbody component
        //We don't want the object to rotate when it collides with smth
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(canMove){
			Move();
			//Checks to see which way the character is facing
			if (Input.GetKey(KeyCode.W))
			{
				direction = "up";
			}
			else if (Input.GetKey(KeyCode.A))
			{
				direction = "left";
			}
			else if (Input.GetKey(KeyCode.S))
			{
				direction = "down";
			}
			else if (Input.GetKey(KeyCode.D))
			{
				direction = "right";
			}
			else
			{
				
			}
		}
    }

    public void Move()
    {
        //Stores the horizontal and vertical input
        int horizontal;
        int vertical;

        //GetAxisRaw is better than GetAxis because movement doesn't slow which is what we want
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        //If horizontal is not zero, vertical will be zero so characters can't move diagonally
        if (horizontal != 0)
        {
            vertical = 0;
        }

        //Follows the magnitude of a new vector (I think??)
        Vector2 move = new Vector2(horizontal, vertical);
        rb2d.velocity = move * moveSpeed;

        //If horizontal and vertical inputs are zero, we don't want the object to move
        if (horizontal == 0 && vertical == 0)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
	
	public int getHealth(){
		return health;
	}
	
	public int getArmor(){
		return armor;
	}
	
	public int getDamage(){
		return damage;
	}
	
	public void changeHealth(int amount){
		health += amount;
	}
	
	public void ableToMove(bool able){
		canMove = able;
	}
}