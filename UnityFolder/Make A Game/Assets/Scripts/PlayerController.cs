using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float actualMoveSpeed = 5;
	public float lockedMoveSpeed = 0;

	bool canMove;
	public Rigidbody rb;
	public float jumpSpeed = 5f;
	public float jumpHeight = 5f;
	public bool canJump;

	public float gravityModifier = 2.5f;
	public float lowJumpMultiplier = 2f;

	public float cutsceneLength;

	void Awake (){
		rb = GetComponent<Rigidbody> ();
	}

	void Start (){
		moveSpeed = actualMoveSpeed;
	}

	void FixedUpdate (){
//--------------------------------------------------------------------------------------------------------------------------------
		// Jump Gravity Modifier
		// Normal Jump, tap button modify gravity for a short jump
		// Long jump, hold down button for a slightly longer jump
//--------------------------------------------------------------------------------------------------------------------------------
		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (gravityModifier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W)) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
//--------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------
		MovePlayer ();
	}

	public void MovePlayer (){
//--------------------------------------------------------------------------------------------------------------------------------
		// Inputs
		// Need to figure out how to just set a button. 
		// So just say "Jump" or "MoveRight" and have multiple buttons i.e (W) or (Up)
//--------------------------------------------------------------------------------------------------------------------------------
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			rb.velocity = Vector3.up * jumpSpeed;
		}
	}

}
//--------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------
//LOCKING MOVEMENT
//	void OnTriggerEnter (){
//		if (collider.tag == "Cutsene") {
//			canMove = false;
//			Invoke ("FixedUpdate", cutsceneLength);
//		}
//	}


//FIXED UPDATE
//		if (canMove = true) {
//			moveSpeed = actualMoveSpeed;
//		} else if (canMove = false) {
//			moveSpeed = lockedMoveSpeed;
//		}
//--------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------