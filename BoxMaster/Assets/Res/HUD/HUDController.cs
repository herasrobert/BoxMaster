using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {


	bool displayHUD = false;

	int currentLife = 0;

	public Texture hearts;
	float heartTextureWidth;
	float heartTextureHeight;

	GameObject livesController;
	LivesController livesControllerScript;

	void Start () {
		livesController = GameObject.Find("LivesController");
		if (livesController != null) {
			livesControllerScript = livesController.GetComponent<LivesController> ();
		} else {
			Debug.Log("HUDController: Lives Controller is Null.");	
		}
		heartTextureWidth = hearts.width;
		heartTextureHeight = hearts.height;

	}

	void Update () {
	
	}

	public float j = 1f;
	public int x = 5;
	public int y = 5;
	public float i = 1f;
	void OnGUI() {

		if (Application.loadedLevelName == "LoadingScreen") {

		} else if (Application.loadedLevelName == "MainMenu") {

		} else {
			displayHUD = true;
		}

		if(displayHUD){
			currentLife = livesControllerScript.getLife();

			if (currentLife > 0) {
				Rect posRect = new Rect(5,5,heartTextureWidth / x * currentLife, heartTextureHeight);
				Rect texRect = new Rect(0f,0f, j / y * currentLife, i);
				GUI.DrawTextureWithTexCoords(posRect, hearts, texRect);
			}



			
		}				
	}
	
	
	
	
	
}
