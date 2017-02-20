using UnityEngine;
using System.Collections;
using CnControls;

public class PlayerMovementController : MonoBehaviour {
	public Vector2 jumpVector;
	public bool isGrounded;
	public Transform grounder;
	public float radius;
	public LayerMask ground;
	
	public float movementSpeed = 50f;

	Vector3 nextPoint;
	Rigidbody2D body;
	Animator animator;

	void Start(){
		body = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
	}
	
	void Update(){
		PlayerMovement();
	}
	
	//public float x = .5f;

	void PlayerMovement(){
		/*#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			body.velocity = new Vector2 (-movementSpeed, body.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			body.velocity = new Vector2 (movementSpeed, body.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
		} else {
			body.velocity = new Vector2(0,body.velocity.y);
		}
		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);
		
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded){
			body.AddForce (jumpVector,ForceMode2D.Force);
		}
		#endif*/


		if(CnInputManager.GetAxis("Horizontal") == -1){
			body.velocity = new Vector2 (-movementSpeed, body.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);			
			animator.Play("PlayerMoving");
		}else if (CnInputManager.GetAxis("Horizontal") == 1){
			body.velocity = new Vector2 (movementSpeed, body.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);		
			animator.Play("PlayerMoving");
		}else {
			body.velocity = new Vector2(0,body.velocity.y);
		}

		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);

		if (CnInputManager.GetButtonDown ("Jump") && isGrounded) {
			body.AddForce (jumpVector,ForceMode2D.Force);
			animator.Play("PlayerJump");
		}
		/*if((CnInputManager.GetAxis("Vertical") == 1) && isGrounded){
			body.AddForce (jumpVector,ForceMode2D.Force);
		}*/


	}

	
	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (grounder.transform.position, radius);
	}

	public bool getIsGrounded(){
		return isGrounded;
	}

}

/*
	void PlayerMovement(){
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			//body.velocity = new Vector2 (-movementSpeed, body.velocity.y);
			nextPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y, 0); //Check Spawn Point Bottom-Right			
			if(!Physics2D.OverlapCircle(nextPoint,.45f)){
				transform.localScale = new Vector3 (-1, 1, 1);
				transform.Translate(-1,0,0);
			}
		} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			//body.velocity = new Vector2 (movementSpeed, body.velocity.y);
			nextPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y, 0); //Check Spawn Point Bottom-Right			
			if(!Physics2D.OverlapCircle(nextPoint,.45f)){
				transform.Translate(1,0,0);
				transform.localScale = new Vector3 (1, 1, 1);
			}
		} else {
			body.velocity = new Vector2(0,body.velocity.y);
		}
		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);
		
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) && isGrounded){
			body.AddForce (jumpVector,ForceMode2D.Force);
		}		
	}
 */