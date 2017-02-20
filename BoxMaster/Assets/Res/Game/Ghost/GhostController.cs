using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	Vector3 startingPoint;
	public float movementSpeed = 0f;
	GameObject player;

	SpriteRenderer spriteRenderer;
	PlayerController playerControllerScript;
	BoxCollider2D boxCollider;

	public Sprite normal;
	public Sprite stunned;

	void Start () {
		player = GameObject.Find("Player");
		if (player != null) {
			playerControllerScript = player.GetComponent<PlayerController>();
		} else {
			Debug.Log("GhostController: Player is null (1)");
		}
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		boxCollider = this.gameObject.GetComponent<BoxCollider2D>();

		startingPoint = this.transform.position;
	}


	void Update () {
		if (player != null) {
			if (player.transform.localScale == new Vector3 (1f, 1f, 1f) && this.transform.position.x > player.transform.position.x) {
				spriteRenderer.sprite = stunned;
			} else if (player.transform.localScale == new Vector3 (-1f, 1f, 1f) && this.transform.position.x < player.transform.position.x) {
				spriteRenderer.sprite = stunned;
			} else {
				if (player.transform.localScale == new Vector3 (1f, 1f, 1f)) {
					transform.localScale = new Vector3 (-1f, 1f, 1f);
				} else {
					transform.localScale = new Vector3 (1f, 1f, 1f);
				}
				spriteRenderer.sprite = normal;
				this.transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);			}
		} else {
			Debug.Log("GhostController: Player is null (2)");
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player"){
			if(playerControllerScript != null){
				playerControllerScript.playerGetsHurt();
			}else{
				Debug.Log("GhostController: PlayerControllerScript is null.");
			}
		}else if(coll.gameObject.tag == "Fireball"){
			spriteRenderer.enabled = false;//Disable Sprite Render
			boxCollider.enabled = false;//Disable Collider
		}else if(coll.gameObject.tag == "Door"){
		}else if(coll.gameObject.tag == "Key"){
		}else {
			Debug.Log("GhostController: Trigger Collision UnAccounted For " + coll.gameObject.name+"--"+coll.gameObject.tag);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

	}

	public void reset(){
		this.transform.position = new Vector3(startingPoint.x, startingPoint.y, startingPoint.z);//Move back to starting position
		spriteRenderer.enabled = true;//Disable Sprite Render
		boxCollider.enabled = true;//Disable Collider
	}
}
