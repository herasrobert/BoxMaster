using UnityEngine;
using System.Collections;
using CnControls;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	int fireBallInventory = 0;
	Vector3 startingPoint;
	Vector3 spawnPoint;

	GameObject box;
	BoxController boxControllerScript;
	GameObject livesController;
	LivesController livesControllerScript;
	public GameObject fireballButton;
	public Sprite regularFireball;
	public Sprite greyFireball;
	Image fireballButtonImage;
	Animator animator;
	PoolingSystem pS;

	void OnAwake(){

	}
	
	void Start(){
		animator = this.GetComponent<Animator>();
		pS = PoolingSystem.Instance;
		livesController = GameObject.Find("LivesController");
		if(livesController != null){
			livesControllerScript = livesController.GetComponent<LivesController>();
		} else {
			Debug.Log("HUDController: Lives Controller is Null.");	
		}

		if(pS == null){
			Debug.Log("PlayedController: PoolingSystem is Null.");
		}

		if(fireballButton != null){
			fireballButtonImage = fireballButton.GetComponent<Image>(); 
		}else {
			if(Application.loadedLevelName == "TutorialOne"){
				//No FireBall Button in that Level
			}else if(Application.loadedLevelName == "TutorialTwo"){
				//No FireBall Button in that Level
			}else if(Application.loadedLevelName == "TutorialThree"){
				//No FireBall Button in that Level
			}else{
				Debug.Log("PlayerController: FireballButton is null.");
			}
		}

		fireBallInventory = 5;
		startingPoint = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
	}


	void Update(){
		/*#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftControl)){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y-1f, 0);
				checkPhysics2DPoint(spawnPoint);	
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y-1f, 0);//Check Spawn Point Bottom-Left
				checkPhysics2DPoint(spawnPoint);	
			}
		}else if(Input.GetKeyDown(KeyCode.LeftControl)){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y, 0);
				checkPhysics2DPoint(spawnPoint);
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y, 0);
				checkPhysics2DPoint(spawnPoint);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.LeftAlt)){
			//Instantiate(fireBall, new Vector3(this.transform.position.x+.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			if(fireBallInventory > 0){ //Fireballs in Inventory			
				if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
					pS.InstantiateAPS("Fireball", new Vector3(this.transform.position.x+.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
					//Instantiate(fireBall, new Vector3(this.transform.position.x+.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				}else{
					pS.InstantiateAPS("Fireball", new Vector3(this.transform.position.x-.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
					//Instantiate(fireBall, new Vector3(this.transform.position.x-.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				}
				//fireBallInventory--;
			}
		}
		#endif*/

		if(pS == null){
			pS = PoolingSystem.Instance;
		}

		//if((CnInputManager.GetAxis("Vertical") == -1) && CnInputManager.GetButtonDown("Fire2")){
		//if((CnInputManager.GetAxis("Vertical") == -1)){

		if(CnInputManager.GetButtonDown("DPadDown")){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y-1f, 0);
				checkPhysics2DPoint(spawnPoint);	
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y-1f, 0);//Check Spawn Point Bottom-Left
				checkPhysics2DPoint(spawnPoint);	
			}
			animator.Play("PlayerDuck");
		}

		if(CnInputManager.GetButtonDown("BoxButton")){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y, 0);
				checkPhysics2DPoint(spawnPoint);
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y, 0);
				checkPhysics2DPoint(spawnPoint);
			};
		}
		
		if(CnInputManager.GetButtonDown("FireballButton")){

			if(fireBallInventory > 0){ //Fireballs in Inventory			
				if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
					pS.InstantiateAPS("Fireball", new Vector3(this.transform.position.x+.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
					//Instantiate(fireBall, new Vector3(this.transform.position.x+.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				}else{
					pS.InstantiateAPS("Fireball", new Vector3(this.transform.position.x-.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
					//Instantiate(fireBall, new Vector3(this.transform.position.x-.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				}
				//fireBallInventory--;
				animator.Play("PlayerFire");
			}
		}

		if (fireBallInventory == 0) {
			if (fireballButtonImage != null) {
				if(fireballButtonImage.sprite != greyFireball){
					fireballButtonImage.sprite = greyFireball;
				}	
			} else {
				Debug.Log ("PlayerController: FireballButtonImage is null. 1st Check");
			}
		} else {
			if (fireballButtonImage != null) {
				if(fireballButtonImage.sprite != regularFireball){
					fireballButtonImage.sprite = regularFireball;
				}	
			} else {
				if(Application.loadedLevelName == "TutorialOne"){
					//No FireBall Button in that Level
				}else if(Application.loadedLevelName == "TutorialTwo"){
					//No FireBall Button in that Level
				}else if(Application.loadedLevelName == "TutorialThree"){
					//No FireBall Button in that Level
				}else{
					Debug.Log ("PlayerController: FireballButtonImage is null. 2nd Check");
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			fireBallInventory++;
		}



		if(Input.GetKeyDown(KeyCode.K)){
			playerGetsHurt();
			//Pause Game
			//Reset Player
			//Reset Each Monster (MonsterResetterScript - Searches Once at beginning of level and adds all monsters into array)
				//Find All Slimes, All SpikeBalls, All WingMan
			//Reset Each Box to How it is Supposed to be.
			//UnPause Game	
		}

	}

	public void playerGetsHurt(){
		Debug.Log("Player Gets Hurt");		
		animator.Play("PlayerHit");
		//Pause Game for 1 Second
		if(livesControllerScript != null){
			livesControllerScript.playerGetsHurt();
		}
		this.reset();
	}

	void OnTriggerEnter2D(Collider2D coll){
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Spikes") {
			playerGetsHurt();
		}else if (coll.gameObject.tag == "Rock") {
			//Nothing Happens
		}else if (coll.gameObject.tag == "Wall") {
			//Nothing Happens
		}else if (coll.gameObject.tag == "StoneBlock") {
			//Nothing Happens
		}else if (coll.gameObject.tag == "ActiveBox") {
			//Nothing Happens
		}else if (coll.gameObject.tag == "InActiveBox") {
			//Nothing Happens
		}else if (coll.gameObject.tag == "SlimeMonster") {
			//Nothing Happens - Collision is accounted for via SlimeMonsterController
		}else if (coll.gameObject.tag == "Spring") {
			//Nothing Happens - Collision is accounted for via SlimeMonsterController
		}else if (coll.gameObject.tag == "Pipe") {
			//Nothing Happens - Collision is accounted for via SlimeMonsterController
		}else if (coll.gameObject.tag == "PipeFlower") {
			playerGetsHurt();
		}else {
			Debug.Log("PlayerController: Collision UnAccounted For: " + coll.gameObject.name+"--"+coll.gameObject.tag);
		}
	}
	
	Collider2D overlapPosition;

	void checkPhysics2DPoint(Vector3 point){
		overlapPosition = Physics2D.OverlapPoint(point);

		if (overlapPosition == null){
			//There is Nothing at that Point				
		} else if (Physics2D.OverlapPoint(point).tag == "InActiveBox" || Physics2D.OverlapPoint (point).tag == "ActiveBox") {
			box = Physics2D.OverlapPoint (point).gameObject;
			boxControllerScript = box.GetComponent<BoxController> ();
			boxControllerScript.boxCheck ();
		} else if(Physics2D.OverlapPoint(point).tag == "Telescope"){
			//Do nothing, don't build ontop of Telescope
		} else if(Physics2D.OverlapPoint(point).tag == "Spring"){
			//Do nothing, don't build ontop of Spring
		} else if(Physics2D.OverlapPoint(point).tag == "Pipe"){
			//Do nothing, don't build ontop of Pipe
		} else if(Physics2D.OverlapPoint(point).tag == "PipeFlower"){
			//Do nothing, don't build ontop of PipeFlower
		} else if(Physics2D.OverlapPoint(point).tag == "Rock"){
			//Do nothing, don't build ontop of PipeFlower
		} else {
			Debug.Log("PlayerController: OverlapPoint Unaccounted For.");				
		}
	}

	public void reset(){
		this.transform.position = new Vector3(startingPoint.x, startingPoint.y, startingPoint.z);//Move back to starting position
		//Reset Variables
	}
}


/*
if(Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftControl)){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y-1f, 0); //Check Spawn Point Bottom-Right

				if(!Physics2D.OverlapCircle(spawnPoint,.45f)){
					Instantiate(box,new Vector3(this.transform.position.x+1f, this.transform.position.y-1f, 0), Quaternion.identity);//Spanw Box if no box there				
				}else{
					if(Physics2D.OverlapCircle(spawnPoint,.45f).tag == "Box"){
						Destroy(Physics2D.OverlapCircle(spawnPoint,.45f).gameObject);
					}
				}			
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y-1f, 0);//Check Spawn Point Bottom-Left

				if(!Physics2D.OverlapCircle(spawnPoint,.45f)){
					Instantiate(box,new Vector3(this.transform.position.x-1f, this.transform.position.y-1f, 0), Quaternion.identity);//Spanw Box if no box there				
				}else{
					if(Physics2D.OverlapCircle(spawnPoint,.45f).tag == "Box"){
						Destroy(Physics2D.OverlapCircle(spawnPoint,.45f).gameObject);
					}
				}
			}
		}else if(Input.GetKeyDown(KeyCode.LeftControl)){
			if(transform.localScale == new Vector3(1,1,1)){ // Facing Right
				spawnPoint = new Vector3(this.transform.position.x+1f, this.transform.position.y, 0);
				
				if(!Physics2D.OverlapCircle(spawnPoint,.45f)){
					Instantiate(box,new Vector3(this.transform.position.x+1f, this.transform.position.y, 0), Quaternion.identity);//Spanw Box if no box there				
				}else{
					if(Physics2D.OverlapCircle(spawnPoint,.45f).tag == "Box"){
						Destroy(Physics2D.OverlapCircle(spawnPoint,.45f).gameObject);
					}
				}
			}else{
				spawnPoint = new Vector3(this.transform.position.x-1f, this.transform.position.y, 0);
				
				if(!Physics2D.OverlapCircle(spawnPoint,.45f)){
					Instantiate(box,new Vector3(this.transform.position.x-1f, this.transform.position.y, 0), Quaternion.identity);//Spanw Box if no box there				
				}else{
					if(Physics2D.OverlapCircle(spawnPoint,.45f).tag == "Box"){
						Destroy(Physics2D.OverlapCircle(spawnPoint,.45f).gameObject);
					}
				}
			}
		}
 */

