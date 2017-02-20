using UnityEngine;
using System.Collections;

public class ObjectResetController : MonoBehaviour{
	int currentLevel = 0;

	GameObject[] slimes;
	GameObject[] spikeballs;
	GameObject[] wingmen;
	GameObject[] doors;
	GameObject[] keys;
	GameObject[] ghosts;
	SlimeMonsterController slimeMonsterControllerScript;
	SpikeBallController spikeBallControllerScript;
	WingManController wingManControllerScript;
	DoorController doorControllerScript;
	KeyController keyControllerScript;
	GhostController ghostControllerScript;
	
	GameObject boxSpawner;
	BoxSpawner boxSpawnerScript;

	void Start ()	{
		if (boxSpawner == null) {
			boxSpawner = GameObject.Find ("BoxSpawner");
		} else if(boxSpawnerScript == null){
			boxSpawnerScript = boxSpawner.GetComponent<BoxSpawner>();
		}
	}

	void Update(){
		if (boxSpawner == null) {
			boxSpawner = GameObject.Find ("BoxSpawner");
		} else if(boxSpawnerScript == null){
			boxSpawnerScript = boxSpawner.GetComponent<BoxSpawner>();
		}

		/*if(Input.GetKeyDown(KeyCode.L)){
			//slimes
			if (spikeballs.Length > 0) {
				Debug.Log((spikeballs.Length) + " SpikeBalls found.");
			}else{
				Debug.Log("Spikeballs Length = 0.");
			}
			//wingmen
			//doors
			//keys
		}*/

		if(Application.loadedLevel != currentLevel){ //Find All GameObjects in this level but search only once per level
			findObjects();
			currentLevel = Application.loadedLevel;
		}
	}

	public void resetObjects ()	{
		if (slimes.Length > 0) {
			for (int x = 0; x < slimes.Length; x++) {
				slimeMonsterControllerScript = slimes [x].GetComponent<SlimeMonsterController> ();
				slimeMonsterControllerScript.reset ();
			}
		}
		if (spikeballs.Length > 0) {
			for (int x = 0; x < spikeballs.Length; x++) {
				spikeBallControllerScript = spikeballs[x].GetComponent<SpikeBallController> ();
				spikeBallControllerScript.reset ();
			}
		}

		if (wingmen.Length > 0) {
			for (int x = 0; x < wingmen.Length; x++) {
				wingManControllerScript = wingmen [x].GetComponent<WingManController> ();
				wingManControllerScript.reset ();
			}
		}
		if (doors.Length > 0) {
			for (int x = 0; x < doors.Length; x++) {
				doorControllerScript = doors [x].GetComponent<DoorController> ();
				doorControllerScript.reset ();
			}
		}
		if (keys.Length > 0) {
			for (int x = 0; x < keys.Length; x++) {
				keyControllerScript = keys [x].GetComponent<KeyController> ();
				keyControllerScript.reset ();
			}
		}
		if (ghosts.Length > 0) {
			for (int x = 0; x < ghosts.Length; x++) {
				ghostControllerScript = ghosts [x].GetComponent<GhostController> ();
				ghostControllerScript.reset ();
			}
		}

	}

	public void deactivateBoxes(){
		if (boxSpawnerScript != null) {
			boxSpawnerScript.deactivateBoxes();//Reset Boxes	
		} else {
			Debug.Log("ObjectResetController: BoxSpawnerScript is null. (1)");
		}
	}

	public void destroyBoxes(){
		if (boxSpawnerScript != null) {
			boxSpawnerScript.destroyBoxes();//Reset Boxes	
		} else {
			Debug.Log("ObjectResetController: BoxSpawnerScript is null. (2)");
		}
	}

	public void resetBoxes(){
		if (boxSpawnerScript != null) {
			boxSpawnerScript.reset();//Reset Boxes	
		} else {
			Debug.Log("ObjectResetController: BoxSpawnerScript is null. (3)");
		}
	}


	void findObjects ()	{
		slimes = GameObject.FindGameObjectsWithTag ("SlimeMonster");
		spikeballs = GameObject.FindGameObjectsWithTag ("SpikeBall");
		wingmen = GameObject.FindGameObjectsWithTag ("WingMan");
		doors = GameObject.FindGameObjectsWithTag ("Door");
		keys = GameObject.FindGameObjectsWithTag ("Key");
		ghosts = GameObject.FindGameObjectsWithTag ("Ghost");
	}

}
