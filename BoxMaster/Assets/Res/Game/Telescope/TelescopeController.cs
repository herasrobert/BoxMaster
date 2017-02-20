using UnityEngine;
using System.Collections;

public class TelescopeController : MonoBehaviour {

	float xDistance = 0f;
	float yDistance = 0f;

	public Vector2 radiusX;
	public Vector2 radiusY;

	Vector3 currentPosition;
	Vector3 playerPosition;

	public GameObject dialogBox;
	GameObject player;
	SpriteRenderer dialogBoxSpriteRenderer;

	void Start () {
		player = GameObject.Find("Player");
		if(player == null){
			Debug.Log("TelescopeController: Player is null. (1)");
		}

		if (dialogBox != null) {
			dialogBoxSpriteRenderer = dialogBox.GetComponent<SpriteRenderer>();
			if(dialogBoxSpriteRenderer != null){
				dialogBoxSpriteRenderer.enabled = false;
			}else{
				Debug.Log ("TelescopController: DialogBoxSpriteRenderer is null. (1)");
			}
		} else {
			Debug.Log ("TelescopController: DialogBox is null.");
		}

		currentPosition = this.transform.position;
		if(radiusX.x == 0 && radiusX.y == 0){
			radiusX = new Vector2(-2.5f,2.5f);
		}
		if(radiusY.x == 0 && radiusY.y == 0){
			radiusY = new Vector2(-2.5f,2.5f);
		}
	}

	void Update () {
		playerPosition = player.transform.position;
		xDistance = playerPosition.x - currentPosition.x;
		yDistance = playerPosition.y - currentPosition.y;
		//Debug.Log (xDistance +"---"+radiusX+"||"+yDistance+"---"+radiusY);

		if ((xDistance > radiusX.x && xDistance < radiusX.y)
		    && (yDistance > radiusY.x && yDistance < radiusY.y)) {
			dialogBoxSpriteRenderer.enabled = true;
		} else {
			dialogBoxSpriteRenderer.enabled = false;			
		}


			
	}


	/*
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			if(dialogBoxSpriteRenderer != null){
				dialogBoxSpriteRenderer.enabled = true;
			}else{
				Debug.Log ("TelescopController: DialogBoxSpriteRenderer is null. (2)");
			}
		} else if(coll.gameObject.tag == "Wall"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "SlimeMonster"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "Key"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "Door"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "Spikes"){
			//Do Nothing
		} else if(coll.gameObject.tag == "ActiveBox"){
			//Do Nothing
		} else if(coll.gameObject.tag == "InActiveBox"){
			//Do Nothing
		} else {
			Debug.Log("TelescopeController: TriggerEnter-Collision unaccounted for " + coll.gameObject.tag);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			if(dialogBoxSpriteRenderer != null){
				dialogBoxSpriteRenderer.enabled = false;
			}else{
				Debug.Log ("TelescopController: DialogBoxSpriteRenderer is null. (3)");
			}
		} else if(coll.gameObject.tag == "Wall"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "SlimeMonster"){
			//Do Nothing						
		} else if(coll.gameObject.tag == "Key"){
			//Do Nothing						
		} else if(coll.gameObject.tag == "Door"){
			//Do Nothing			
		} else if(coll.gameObject.tag == "Spikes"){
			//Do Nothing
		} else if(coll.gameObject.tag == "ActiveBox"){
			//Do Nothing
		} else if(coll.gameObject.tag == "InActiveBox"){
			//Do Nothing
		} else {
			Debug.Log("TelescopeController: TriggerExit-Collision unaccounted for " + coll.gameObject.tag);
		}
	}*/

}
