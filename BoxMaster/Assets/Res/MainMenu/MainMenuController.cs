using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	GameObject levelController;
	LevelController levelControllerScript;

	void Start(){
		levelController = GameObject.Find("LevelController");
		/*if(levelController != null){
			levelControllerScript = levelController.GetComponent<LevelController>();
			if(levelControllerScript != null){
				levelControllerScript.loadNextLevel();
			}
		}*/
	}

	void Update(){
	

	}


	void OnGUI(){
		if (GUI.Button(new Rect(200, 200, 200, 200), "Play")){
			if(levelController != null){
				levelControllerScript = levelController.GetComponent<LevelController>();
				if(levelControllerScript != null){
					levelControllerScript.loadNextLevelNoResetBoxes();
				}
			}else{
				Debug.Log("MainMenuController: LevelController is null. (1)");
			}	   
		}
	}
}
