using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	public GameObject door;
	DoorController doorControllerScript;
	SpriteRenderer spriteRenderer;
	PolygonCollider2D polygonCollider;

	void Start(){
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		polygonCollider = this.GetComponent<PolygonCollider2D>();
		door = GameObject.Find("Door");
		if (door != null) {
			doorControllerScript = door.GetComponent<DoorController> ();
		} else {
			Debug.Log("KeyController Error: Door is null.");
		}	
	}

	void Update(){}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player"){
			unlockDoor();
			spriteRenderer.enabled = false;
			polygonCollider.enabled = false;
		}
	}


	void unlockDoor(){
		if(doorControllerScript != null){
			doorControllerScript.subtractLock();
		}
	}

	public void reset(){
		spriteRenderer.enabled = true;
		polygonCollider.enabled = true;
	}
}
