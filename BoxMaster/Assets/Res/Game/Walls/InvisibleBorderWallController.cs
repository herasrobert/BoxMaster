using UnityEngine;
using System.Collections;

public class InvisibleBorderWallController : MonoBehaviour {



	SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = false;
	}

	void Update () {
		if(spriteRenderer.enabled == true){
			Debug.Log("InvisibleBorderWallController: Wall is Visible - " + this.gameObject.name);
		}
	}
}
