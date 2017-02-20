using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		
		/*if (FindObjectsOfType(GetType()).Length > 1){// Prevent Duplicated of this GameObject due to DontDestroyOnLoad
			Destroy(gameObject);
		}*/
		if (this.gameObject.name == "Advanced Pooling System") {
			if (GameObject.FindGameObjectsWithTag ("PoolingSystem").Length > 1) {
				Destroy (this.gameObject);
			}
		} else if (this.gameObject.name == "LivesController") {
			if (GameObject.FindGameObjectsWithTag ("LivesController").Length > 1) {
				Destroy (this.gameObject);
			}
		} else if (this.gameObject.name == "LevelController") {
			if (GameObject.FindGameObjectsWithTag ("LevelController").Length > 1) {
				Destroy (this.gameObject);
			}
		} else if (this.gameObject.name == "HUDController") {
			if (GameObject.FindGameObjectsWithTag ("HUDController").Length > 1) {
				Destroy(this.gameObject);
			}
		} else if (this.gameObject.name == "ObjectResetController") {
			if (GameObject.FindGameObjectsWithTag ("ObjectResetController").Length > 1) {
				Destroy(this.gameObject);
			}
		} else if (this.gameObject.name == "BackgroundSpawner") {
			if (GameObject.FindGameObjectsWithTag ("BackgroundSpawner").Length > 1) {
				Destroy(this.gameObject);
			}
		}else {
			Debug.Log("DontDestroyOnLoad Error: " + this.gameObject.name);
		}
	}

	void Start(){
	}
}
