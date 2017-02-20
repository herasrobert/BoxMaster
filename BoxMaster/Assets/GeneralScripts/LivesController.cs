using UnityEngine;
using System.Collections;

public class LivesController : MonoBehaviour {

	public int life = 0;
	int maxLife = 0;

	GameObject objectResetController;
	ObjectResetController objectResetControllerScript;

	GameObject levelController;
	LevelController levelControllerScript;

	void Start(){
		levelController = GameObject.Find("LevelController");
		if (levelController != null) {
			levelControllerScript = levelController.GetComponent<LevelController> ();
		} else {
			Debug.Log("LivesController: LevelController is Null.");
		}

		maxLife = 5;
		life = maxLife;
	}

	void Update(){
		if (objectResetController == null) {
			objectResetController = GameObject.Find("ObjectResetController");
		} else if(objectResetControllerScript == null){
			objectResetControllerScript = objectResetController.GetComponent<ObjectResetController>();
		}

	}

	public void subtractLife(){
		life--;
	}

	public void subtractLife(int life){
		this.life = life;
	}

	public void addLife(){
		life++;
		if(maxLife > 6){
			maxLife = 5;
		}
	}

	public void addLife(int life){
		this.life += life;
		if(maxLife > 6){
			maxLife = 5;
		}
	}

	public int getLife(){
		return life;
	}

	public int getMaxLife(){
		return maxLife;
	}

	public void checkLife(){
		if(life == 0){
			Debug.Log("LivesController: GameOver!");
			levelControllerScript.loadGameOver();
		}
	}

	public void playerGetsHurt(){
		subtractLife();
		checkLife ();
		if (objectResetControllerScript != null) {
			objectResetControllerScript.resetBoxes();
			objectResetControllerScript.resetObjects();
		} else {
			Debug.Log("LivesController: ObjectControllerScript is null.");
		}

		//Unpause if it was paused?
	}

}
