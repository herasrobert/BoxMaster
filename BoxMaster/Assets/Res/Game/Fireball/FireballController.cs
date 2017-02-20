using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	public float movementSpeed = 3f;
	bool goRight = false;
	
	BoxController boxControllerScript;
	Rigidbody2D body;
	GameObject player;

	void OnEnable() {
		player = GameObject.Find("Player");

		if (player != null) {	
			if (Application.loadedLevelName.Equals ("LoadingScreen")) {
				//Do Nothing because this is the LoadingScreen
			} else if (Application.loadedLevelName.Equals ("MainMenu")) {
				//Do Nothing because this is the MainMenu
			}else{
				if (player.transform.position.x < this.transform.position.x) {
					goRight = true;
				} else {
					goRight = false;
				}
			}
		} else {
			//Debug.Log("FireballController: Player is Null. Scene likely does not contain Player Object.");
			if (Application.loadedLevelName.Equals ("LoadingScreen")) {
				//Debug.Log("FireballController: Scene is LoadingScreen");
			} else if (Application.loadedLevelName.Equals ("MainMenu")) {
				//Debug.Log("FireballController: Scene is MainMenu");
			} else {
				Debug.Log("FireballController: Scene is not accounted for.");
			}		
		}
	}
	void Awake(){}

	void Start () {
		/*player = GameObject.Find("Player");
		
		if (player.transform.position.x < this.transform.position.x) {
			goRight = true;
		} else {
			goRight = false;
		}*/
	}	



	void Update () {
		if(!goRight){ // Move to Left
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(this.transform.position.x - 1f, transform.position.y, 0), movementSpeed * Time.deltaTime); //Head to Starting Position
		}else{ // Move to Right
			this.transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(this.transform.position.x + 1f, transform.position.y, 0), movementSpeed * Time.deltaTime); //Head to Ending Position
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			//Do Nothing
		}else if (coll.gameObject.tag == "Spikes") {
			this.gameObject.DestroyAPS();//Break Self
		}else if (coll.gameObject.tag == "Fireball") {
			//Do Nothing
		}else if (coll.gameObject.tag == "Rock") {
			this.gameObject.DestroyAPS();//Break Self
		}else if (coll.gameObject.tag == "Wall") {
			this.gameObject.DestroyAPS();//Break Self
		}else if (coll.gameObject.tag == "StoneBlock") {
			this.gameObject.DestroyAPS();//Break Self
		}else if (coll.gameObject.tag == "ActiveBox") {
			boxControllerScript = coll.gameObject.GetComponent<BoxController>();
			boxControllerScript.boxCheck();
			this.gameObject.DestroyAPS();//Break Self
		}else if (coll.gameObject.tag == "InActiveBox") {
			//Do Nothing
		}else if(coll.gameObject.tag == "SlimeMonster"){
			//Break SpikeBall - This is done in SlimeBallController
			this.gameObject.DestroyAPS();//Break Self
		}else if(coll.gameObject.tag == "SpikeBall"){
			//Break SpikeBall - This is done in SpikeBallController
			this.gameObject.DestroyAPS();//Break Self
		}else if(coll.gameObject.tag == "WingMan"){
			//Break SpikeBall - This is done in WingManController
			this.gameObject.DestroyAPS();//Break Self
		}else if(coll.gameObject.tag == "Door"){
			//Do Nothing
		}else if(coll.gameObject.tag == "Key"){
			//Do Nothing
		}else if(coll.gameObject.tag == "Spring"){
			//Do Nothing
		}else {
			Debug.Log("FireballController: TriggerCollision UnAccounted For" + coll.gameObject.name+"--"+coll.gameObject.tag);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("FireballController: Collision UnAccounted For" + coll.gameObject.name+"--"+coll.gameObject.tag);
	}

}
