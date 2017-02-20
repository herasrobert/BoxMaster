using UnityEngine;
using System.Collections;

public class TitleSceneController : MonoBehaviour {

	/*public MovieTexture myMovie;

	GameObject levelController;
	LevelController levelControllerScript;	*/
	
	void Start(){
		/*levelController = GameObject.Find("LevelController");
		myMovie.Play();*/
	}
	
	
	void OnGUI(){
		//Show Title
		//Play Movie
		////Allow Tap	


		/*GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myMovie);

		if (!myMovie.isPlaying) {
			Debug.Log("Finished Playing");


		}*/

		//if tap, load scene
		/*if(levelController != null){
			levelControllerScript = levelController.GetComponent<LevelController>();
			if(levelControllerScript != null){
				levelControllerScript.loadNextLevelNoResetBoxes();
			}
		}else{
			Debug.Log("MainMenuController: LevelController is null. (1)");
		}*/

	}

	void Update () {
		
	}


}
