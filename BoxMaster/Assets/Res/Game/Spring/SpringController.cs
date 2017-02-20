using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

	public float force = 100f;
	bool activated = false;
	public float maxTimer = 0f;
	float resetTimer = 0f;

	public Sprite springIn;
	public Sprite springOut;

	BoxCollider2D boxCollider;
	SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		boxCollider = this.GetComponent<BoxCollider2D>();
		resetTimer = maxTimer;
	}

	void Update () {
		if(activated){
			resetTimer -= Time.deltaTime;
			if(resetTimer < 0){
				resetTimer = maxTimer;
				activated = false;
				spriteRenderer.sprite = springIn;
				setBoxColliderDown();
			}
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			if (!activated) {
				coll.rigidbody.AddForce (new Vector2 (0, force));
				if (spriteRenderer != null) {
					spriteRenderer.sprite = springOut;
					activated = true;
					setBoxColliderUp ();
				}
			}
		} else {
			Debug.Log("SpringController: Collision UnAccounted For: " + coll.gameObject.name + "--" + coll.gameObject.tag);
		}
	}

	void setBoxColliderUp(){
		boxCollider.offset = new Vector2(0,.1f);
		//boxCollider.size = new Vector2(1f,.3f);
	}

	void setBoxColliderDown(){
		boxCollider.offset = new Vector2(0,-.26f);
		//boxCollider.size = new Vector2(1f,.3f);
	}


}
