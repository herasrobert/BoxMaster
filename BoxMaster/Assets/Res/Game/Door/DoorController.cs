using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool loadNextLevelNoResetBoxes = false;
	bool locked = true;
	int currentLocks = 0;
	public int maxLocks = 0;
	public int nextLevelNumber = 0;

	GameObject levelController;
	LevelController levelControllerScript;
	SpriteRenderer spriteRenderer;
	public Sprite lockedDoor;
	public Sprite openDoor;

	void Start(){
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		levelController = GameObject.Find("LevelController");
		if(levelController != null){
			levelControllerScript = levelController.GetComponent<LevelController>();
		}else {
			Debug.Log("DoorController: LevelController is Null.");
		}
		currentLocks = maxLocks;
		checkDoor();
	}

	void Update(){
		/*if(madeIt){
			delayTimer -= Time.deltaTime;
			if(delayTimer < 0){
				Time.timeScale = 1f;

				if(nextLevelNumber == 0){
					if(levelControllerScript != null){
						levelControllerScript.loadNextLevel();
						//Debug.Log("DoorController: Load Default Next Level");
					}else {
						Debug.Log("LevelController: LevelControllerScript is Null. (1)");
					}
				}else {
					if(levelControllerScript != null){
						levelControllerScript.loadCustomLevel(nextLevelNumber);
						//Debug.Log("DoorController: Load Custom Level");
					}else {
						Debug.Log("LevelController: LevelControllerScript is Null. (2)");
					}
				}

			}
		}*/
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "Player"){
			if(!locked){
				if(nextLevelNumber == 0){
					if(levelControllerScript != null){
						if(loadNextLevelNoResetBoxes){
							levelControllerScript.loadNextLevelNoResetBoxes();
						}else {
							levelControllerScript.loadNextLevel();
						}
					}else {
						Debug.Log("LevelController: LevelControllerScript is Null. (1)");
					}
				}else {
					if(levelControllerScript != null){
						if(loadNextLevelNoResetBoxes){
							levelControllerScript.loadNextLevelNoResetBoxes();
						}else {
							levelControllerScript.loadCustomLevel(nextLevelNumber);
						}
					}else {
						Debug.Log("LevelController: LevelControllerScript is Null. (2)");
					}
				}
			}
		}
	}

	public void subtractLock(){
		currentLocks--;
		checkDoor();
	}

	void checkDoor(){
		if (currentLocks == 0) {
			locked = false;
			spriteRenderer.sprite = openDoor;
		} else {
			locked = true;
			spriteRenderer.sprite = lockedDoor;
		}
	}

	public void reset(){
		currentLocks = maxLocks;
		locked = true;
		checkDoor();
	}


}
