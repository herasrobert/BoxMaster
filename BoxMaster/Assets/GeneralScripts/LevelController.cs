using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {


	GameObject objectResetController;
	ObjectResetController objectResetControllerScript;

	void Start(){
		if (objectResetController == null) {
			objectResetController = GameObject.Find ("ObjectResetController");
		} else {
			if(objectResetControllerScript == null){
				objectResetControllerScript = objectResetController.GetComponent<ObjectResetController>();
			}
		}
	}

	void Update(){
		if (objectResetController == null) {
			objectResetController = GameObject.Find("ObjectResetController");
		} else if(objectResetControllerScript == null){
			objectResetControllerScript = objectResetController.GetComponent<ObjectResetController>();
		}

		if(Input.GetKeyDown(KeyCode.KeypadPlus)){
			loadNextLevel();
		}

		if(Input.GetKeyDown(KeyCode.Pause)){
			Application.LoadLevel("LevelOne");
		}

		if(Input.GetKeyDown(KeyCode.KeypadMinus)){
			loadPreviousLevel();
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			loadMainMenu();
		}

	}

	public void loadNextLevel(){
		resetBoxes();
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void loadNextLevelNoResetBoxes(){
		Application.LoadLevel(Application.loadedLevel + 1);	
	}

	public void loadCustomLevel(int levelNumber){
		resetBoxes();
		Application.LoadLevel(levelNumber);	
	}

	public void loadCustomLevelNoResetBoxes(int levelNumber){
		Application.LoadLevel(levelNumber);	
	}

	public void loadPreviousLevel(){
		resetBoxes();
		Application.LoadLevel(Application.loadedLevel - 1);
	}

	public void loadMainMenu(){
		resetBoxes();
		Application.LoadLevel("MainMenu");
	}

	public void loadMainMenuNoResetBoxes(){
		Application.LoadLevel("MainMenu");
	}

	public void loadIntroLevel(){
		Application.LoadLevel("IntroLevel");
	}

	public void loadTestLevel(){
		resetBoxes();
		Application.LoadLevel("TestLevel");
	}

	public void loadGameOver(){
		resetBoxes();
		Application.LoadLevel("GameOver");

	}

	public string getCurrentLevelName(){
		return Application.loadedLevelName;
	}

	public int getCurrentLevel(){
		return Application.loadedLevel;
	}

	void resetBoxes(){
		if (objectResetControllerScript != null) {
			objectResetControllerScript.deactivateBoxes();
			objectResetControllerScript.destroyBoxes();
		} else {
			Debug.Log("LevelController: ObjectControllerScript is null.");
		}
	}

}
