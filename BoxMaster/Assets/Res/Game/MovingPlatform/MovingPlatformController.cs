using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

	public int platformType = 0;
	public float movementSpeed = 3f;

	bool rebound = false;


	public Vector3 firstPoint;
	public Vector3 lastPoint;

	SpriteRenderer spriteRenderer;

	public Sprite dirtPlatform;
	public Sprite grassPlatform;
	public Sprite planetPlatform;
	public Sprite sandPlatform;
	public Sprite snowPlatform;
	public Sprite stonePlatform;

	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		if (platformType == 0) {
			spriteRenderer.sprite = dirtPlatform;//Dirt Platform
		} else if (platformType == 1) {
			spriteRenderer.sprite = grassPlatform;//Grass Platform
		} else if (platformType == 2) {
			spriteRenderer.sprite = planetPlatform;//Planet Platform
		} else if (platformType == 3) {
			spriteRenderer.sprite = sandPlatform;//Sand Platform
		} else if (platformType == 4) {
			spriteRenderer.sprite = snowPlatform;//Snow Platform
		} else if (platformType == 5) {
			spriteRenderer.sprite = stonePlatform;//Stone Platform
		} else {
			Debug.Log("MovingPlatformController: PlatformType UnAccounted For");
		}
	
	}

	void Update () {
		if (rebound) { // Move Right
			transform.position = Vector3.MoveTowards(transform.position, lastPoint, movementSpeed);
			if(this.transform.position == lastPoint){
				rebound = false;
			}
		} else { // Move Left
			transform.position = Vector3.MoveTowards(transform.position, firstPoint, movementSpeed);
			if(this.transform.position == firstPoint){
				rebound = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.parent = this.transform;
		} else {
			Debug.Log("MovingPlatformController: Collision UnAccounted For. Object: " + coll.gameObject.name);
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.parent = null;
		} else {
			Debug.Log("MovingPlatformController: Collision UnAccounted For. Object: " + coll.gameObject.name + " (1)");
		}
	}



}
