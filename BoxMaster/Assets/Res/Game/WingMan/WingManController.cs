using UnityEngine;
using System.Collections;

public class WingManController : MonoBehaviour {

	public float movementSpeed = 1f;
	
	bool rebound = false;

	Vector3 startingPoint;
	
	GameObject boxCollided;
	BoxController boxCollidedScript;
	GameObject player;
	PlayerController playerControllerScript;

	void Start(){
		player = GameObject.Find("Player");
		playerControllerScript = player.GetComponent<PlayerController>();
		
		startingPoint = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
	}
	
	void Update(){
		if(rebound){ // Move to Left
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(this.transform.position.x, transform.position.y - 1f, 0), movementSpeed * Time.deltaTime); //Head to Starting Position
		}else{ // Move to Right
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(this.transform.position.x, transform.position.y + 1f, 0), movementSpeed * Time.deltaTime); //Head to Ending Position
		}
	}
	
	void checkRebound(){
		if (rebound) {
			rebound = false;
			//transform.localScale = new Vector3 (1, 1, 1);
		} else {
			rebound = true;
			//transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player"){
			if(playerControllerScript != null){
				playerControllerScript.playerGetsHurt();
			}else{
				Debug.Log("SlimeController Script: PlayerControllerScript is null.");
			}
		}else if(coll.gameObject.tag == "ActiveBox"){
			boxCollided = coll.gameObject;
			if(boxCollided != null){
				boxCollidedScript = boxCollided.GetComponent<BoxController>();
				boxCollidedScript.boxCheck();
			}else{
				Debug.Log("Error: Box Collided Null");
			}
			checkRebound();
		}else if(coll.gameObject.tag == "InActiveBox"){
			
		}else if(coll.gameObject.tag == "Wall"){
			checkRebound();
		}else if(coll.gameObject.tag == "StoneBlock"){
			checkRebound();
		}else if(coll.gameObject.tag == "SlimeMonster"){

		}else if(coll.gameObject.tag == "SpikeBall"){
			
		}else if(coll.gameObject.tag == "WingMan"){
			
		}else {
			Debug.Log("WingManController: Trigger Collision UnAccounted For" + coll.gameObject.name+"--"+coll.gameObject.tag);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Player") {
			
		}else {
			Debug.Log("WingManController: Collision UnAccounted For" + coll.gameObject.name+"--"+coll.gameObject.tag);
		}
	}

	public void reset(){
		//Debug.Log("WingManController: Reset");
		this.transform.position = new Vector3(startingPoint.x, startingPoint.y, startingPoint.z);//Move back to starting position
	}
}
