using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

	public int backgroundType = 1;
	int currentLevel = 1;
	public float radius = .5f;
	bool finishedSpawning = false;
	public Transform bottomLeftPoint;
	public Transform topRightPoint;

	PoolingSystem pS;
	void Start () {
		pS = PoolingSystem.Instance;
	
	}

	void Update () {
		if (pS != null && !finishedSpawning) {
			determineLevelBackground();

			for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
				for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {		
					if(backgroundType == 1){
						pS.InstantiateAPS ("DirtCenterBackground", new Vector3 (x, y, 0), Quaternion.identity);
					}else if(backgroundType == 2){
						pS.InstantiateAPS ("GrassCenterBackground", new Vector3 (x, y, 0), Quaternion.identity);
					}else if(backgroundType == 3){
						pS.InstantiateAPS ("PlanetCenterBackground", new Vector3 (x, y, 0), Quaternion.identity);
					}else if(backgroundType == 4){
						pS.InstantiateAPS ("SandCenterBackground", new Vector3 (x, y, 0), Quaternion.identity);
					}else if(backgroundType == 5){
						pS.InstantiateAPS ("SnowCenterBackground", new Vector3 (x, y, 0), Quaternion.identity);
					}else {
						Debug.Log("BackgroundSpawner: BackgroundType UnHandled - BackgroundType = " + backgroundType);
					}
				}
			}
			
			finishedSpawning = true;
		}
	}

	void determineLevelBackground(){
		setCurrentLevel ();
		if(currentLevel == 1){
			backgroundType = 1;//Intro Level
		}else if(currentLevel == 2){
			//backgroundType = x;//Intro Level			
		}else{
			Debug.Log("BackgroundSpawner: CurrentLevel UnHandled.");
		}
	}

	public void setCurrentLevel(){
		currentLevel = Application.loadedLevel;
	}

	public void setCurrentLevel(int levelNumber){
		currentLevel = levelNumber;
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (bottomLeftPoint.transform.position, radius);
		Gizmos.DrawWireSphere (topRightPoint.transform.position, radius);
	}

	public void setBackgroundType(int type){
		backgroundType = type;
	}
}
