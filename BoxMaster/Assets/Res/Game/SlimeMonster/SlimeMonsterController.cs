using UnityEngine;
using System.Collections;

public class SlimeMonsterController : MonoBehaviour {

	public float movementSpeed = 1f;

	public float floorYValue = 0f;
	public float deathTimer = 1f;
	float startingY = 0;

	bool isFalling = false;
	bool rebound = false;


	public Vector3 startingPoint;
	public Vector3 endingPoint;

	GameObject player;
	PlayerController playerControllerScript;
	PolygonCollider2D polygonCollider;
	SpriteRenderer spriteRenderer;
	Rigidbody2D body;

	void Start(){
		player = GameObject.Find("Player");
		playerControllerScript = player.GetComponent<PlayerController>();
		polygonCollider = this.GetComponent<PolygonCollider2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();	
		body = this.GetComponent<Rigidbody2D>();
	
		startingY = this.transform.position.y;
		isFalling = false;

		startingPoint = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
	}


void Update(){
		if (!isFalling) {
			if (rebound) { // Move to Left
				this.transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, 0), new Vector3 (this.transform.position.x - 1f, transform.position.y, 0), movementSpeed * Time.deltaTime); //Head to Starting Position
			} else { // Move to Right
				this.transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, 0), new Vector3 (this.transform.position.x + 1f, transform.position.y, 0), movementSpeed * Time.deltaTime); //Head to Ending Position
			}

			/*if(rebound){ // Move to Starting Point
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), startingPoint, movementSpeed * Time.deltaTime); //Head to Starting Position
			if(transform.position.x == startingPoint.x && transform.position.y == startingPoint.y){
				checkRebound();
			}
		}else{ // Move to Ending Point
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), endingPoint, movementSpeed * Time.deltaTime); //Head to Ending Position
			if(transform.position.x == endingPoint.x && transform.position.y == endingPoint.y){
				checkRebound();
			}
		}*/
		}

		if (startingY - .3f > this.transform.position.y) {
			isFalling = true;
			//Play Death Animation
			polygonCollider.isTrigger = true;//Set Collision to Trigger
			if (this.transform.position.y < floorYValue) {
				this.transform.position = new Vector3 (this.transform.position.x, floorYValue, 0);
			}
			deathTimer -= Time.deltaTime;

			if (deathTimer < 0) {
				dead ();
			}
		}		
	}
	void checkRebound(){
		if (rebound) {
			rebound = false;
			transform.localScale = new Vector3 (1, 1, 1);
		} else {
			rebound = true;
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player") {

		}else if(coll.gameObject.tag == "Wall"){
			checkRebound();
		}else if(coll.gameObject.tag == "InActiveBox"){
			
		}else if(coll.gameObject.tag == "Fireball"){
			dead();
		}else if(coll.gameObject.tag == "Door"){
			
		}else if(coll.gameObject.tag == "Key"){
			
		}else {
			Debug.Log("SlimeMonsterController: Trigger UnAccounted For " + coll.gameObject.name+"--"+coll.gameObject.tag);		
		}
	
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Player") {
			if (isFalling) {
				//Nothing Happens
			} else {
				if(playerControllerScript != null){
					playerControllerScript.playerGetsHurt();
				}else{
					Debug.Log("SlimeController Script: PlayerControllerScript is null.");
				}
			}
		}else if (coll.gameObject.tag == "ActiveBox") {
			checkRebound();
		}else if(coll.gameObject.tag == "Wall"){
			checkRebound();
		}else if(coll.gameObject.tag == "StoneBlock"){
			checkRebound();
		}else if(coll.gameObject.tag == "SlimeMonster"){
			
		}else if(coll.gameObject.tag == "SpikeBall"){
			
		}else if(coll.gameObject.tag == "WingMan"){
			
		}else if(coll.gameObject.tag == "Door"){
			checkRebound();			
		}else {
			Debug.Log("SlimeMonsterController: Collision UnAccounted For " + coll.gameObject.name+"--"+coll.gameObject.tag);		
		}
	}

	void dead(){
		spriteRenderer.enabled = false;
		polygonCollider.enabled = false;
		body.isKinematic = true;
	}

	public void reset(){
		//Debug.Log("SlimeMonsterController: Reset");
		this.transform.position = new Vector3(startingPoint.x, startingPoint.y, startingPoint.z);//Move back to starting position
		//startingY = this.transform.position.y;
		isFalling = false;
		spriteRenderer.enabled = true;
		polygonCollider.enabled = true;
		body.isKinematic = false;
	}
}
