using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {
	int boxHealth = 0;

	GameObject player;
	//PlayerMovementController playerMovementControllerScript;
	bool isActive = false;
	bool cantActivateBox = false;

	Collider2D[] collidersInArea; 

	BoxCollider2D boxCollider;
	SpriteRenderer spriteRenderer;
	public Sprite box;
	public Sprite damagedBox;
	public Sprite invisiblebox;

	Animator animator;

	void OnEnable(){
		boxHealth = 0;
		isActive = false;
		cantActivateBox = false;

		boxCollider = this.GetComponent<BoxCollider2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player");
		animator = this.GetComponent<Animator>();
		
		this.gameObject.layer = 0;//Disable as "ground"
		
		if (isActive) {
			checkActivation();
		} else {			
			isActive = false;
		}

		boxHealth = 2;
		spriteRenderer.sprite = box;
	}

	void Start(){
		/*boxCollider = this.GetComponent<BoxCollider2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player");
		animator = this.GetComponent<Animator>();

		this.gameObject.layer = 0;//Disable as "ground"

		if (isActive) {
			checkActivation();
		} else {			
			isActive = false;
		}
		boxHealth = 2;
		spriteRenderer.sprite = box;*/
	}

	void Update(){}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player"){
			if(isActive){
				if(player.transform.position.y + .9f < this.transform.position.y){ //If Player Below
					boxHealth--;
					if(boxHealth == 1){
						animator.Play("DamagedBoxAnimation");
					}else if(boxHealth == 0){
						boxCheck();
					}
				}
			}
		}
	}

	public void	boxCheck(){
		if (isActive) {
			deactiveBox();
			isActive = false;
		} else {
			checkActivation();
			isActive = true;
		}
	}

	void activateBox(){
		animator.Play("BoxEffectActivate");
		this.gameObject.layer = 8;//Enable as "ground"
		boxCollider.isTrigger = false;
		this.gameObject.tag = "ActiveBox";
	}

	void deactiveBox(){
		animator.Play("BoxEffectDeActivate");
		this.gameObject.layer = 0;//Disable as "ground"
		boxCollider.isTrigger = true;
		this.gameObject.tag = "InActiveBox"; 
		boxHealth = 2;
	}

	void activateBoxWithoutAnim(){
		animator.Play("IdleActive");
		this.gameObject.layer = 8;//Enable as "ground"
		boxCollider.isTrigger = false;
		this.gameObject.tag = "ActiveBox";
	}

	void deactiveBoxWithoutAnim(){
		animator.Play("InActiveBoxAnimation");
		this.gameObject.layer = 0;//Disable as "ground"
		boxCollider.isTrigger = true;
		this.gameObject.tag = "InActiveBox"; 
		boxHealth = 2;
	}

	void checkActivation(){ // This method is supposed to check
		collidersInArea = Physics2D.OverlapCircleAll (this.transform.position, .4f);
		for(int i = 0; i < collidersInArea.Length; i++){
			if(cantActivateBox){
				//Do Nothing, Box Can't be Activated
			}else if(collidersInArea[i].tag == "InActiveBox"){
				cantActivateBox = false; // Set to false since the Player CAN Spawn a Box
			}else if(collidersInArea[i].tag == "Player"){
				cantActivateBox = false;
			}else if(collidersInArea[i].tag == "ActiveBox"){
				cantActivateBox = true;	// Set to true since the Player CAN'T Spawn a Box	
			}else if(collidersInArea[i].tag == "Wall"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "StoneBlock"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "SlimeMonster"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "SpikeBall"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "WingMan"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "Spikes"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "Door"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "Key"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "Telescope"){
				cantActivateBox = false;
			}else if(collidersInArea[i].tag == "Spring"){
				cantActivateBox = false;
			}else if(collidersInArea[i].tag == "Pipe"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "PipeFlower"){
				cantActivateBox = true;
			}else if(collidersInArea[i].tag == "Rock"){
				cantActivateBox = true;
			}else {
				Debug.Log("BoxController: Activate Box Collision UnAccounted For" + collidersInArea[i].name+"--"+collidersInArea[i].tag);
			}
		}

		if (cantActivateBox) {
			deactiveBox();
		} else {
			activateBox();
		}
		cantActivateBox = false;
	}


	public void setIsActiveTrue(){
		isActive = true;
		//activateBoxWithoutAnim();
		activateBox();
	}

	public void setIsActiveFalse(){
		isActive = false;
		deactiveBoxWithoutAnim();
		//deactiveBox();
	}

	public bool getIsActive(){
		return isActive;
	}



}
