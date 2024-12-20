using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public float movementSpeed = 3.0f;
	Vector2 movement = new Vector2();
	Rigidbody2D rg2D;
	
	Animator animator;
	
	string animationState = "AnimationState";
	
	enum CharStates 
	{
		walkEast = 1,
		walkSouth = 2,
		walkWest = 3,
		
		walkNorth = 4,
		idle = 0
	}
	void Start()
	{
		rg2D = GetComponent<Rigidbody2D>();
		
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateState();
	}
	
	private void FixedUpdate() 
	{
		MoveCharacter();
	}
	
	private void MoveCharacter() 
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		
		movement.Normalize();
		
		rg2D.velocity = movement * movementSpeed;
	}
	
	private void UpdateState() 
	{
		if(movement.x > 0) 
		{
			animator.SetInteger(animationState, (int)CharStates.walkEast);
		} else if(movement.x < 0) 
		{
			animator.SetInteger(animationState, (int)CharStates.walkWest);
		} else if(movement.y > 0) 
		{
			animator.SetInteger(animationState, (int)CharStates.walkSouth);
		} else if(movement.y < 0) 
		{
			animator.SetInteger(animationState, (int)CharStates.walkNorth);
		} else 
		{
			animator.SetInteger(animationState, (int)CharStates.idle);
		}
	}
}
