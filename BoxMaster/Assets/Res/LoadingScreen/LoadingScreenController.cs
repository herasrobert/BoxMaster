using UnityEngine;
using System.Collections;

public class LoadingScreenController : MonoBehaviour {

	
	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	public float loadingTime = 0f;
	float currentTimer = 0f;

	public Texture loadingScreenBackground;

	GameObject levelController;
	LevelController levelControllerScript;

	void Start () {
		levelController = GameObject.Find("LevelController");
		if (levelController != null) {
			levelControllerScript = levelController.GetComponent<LevelController> ();
		} else {
			Debug.Log("LoadingScreenController: LevelController is Null.");
		}
		
		size = new Vector2(525,30);
		pos = new Vector2((Screen.width / 2) + 10 -(size.x/2), (Screen.height / 2) + 180 -(size.y/2));

	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), loadingScreenBackground);


		/*GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
				GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
			GUI.EndGroup();
		GUI.EndGroup();*/
	}
	
	void Update() {
		currentTimer += Time.deltaTime;
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		//barDisplay = Time.time*0.05f;
		//        barDisplay = MyControlScript.staticHealth;


		//barDisplay = currentTimer / maxTimer;

		if(currentTimer > loadingTime){
			levelControllerScript.loadMainMenuNoResetBoxes();
		}

	}
}
