using UnityEngine;
using System.Collections;

public class BoxSpawner : MonoBehaviour
{
	public bool usePoints = false;
	bool finishedSpawning = false;
	public float startingXPosition = 0f;
	public float startingYPosition = 0f;
	public float endingXPosition = 0f;
	public float endingYPosition = 0f;
	public Transform bottomLeftPoint;
	public Transform topRightPoint;
	public float radius = .5f;
	public Vector2[] exclusionList;
	public GameObject box;
	Collider2D[] overlapPositions;
	GameObject tempBox;
	BoxController tempBoxControllerScript;
	PoolingSystem pS;

	void Start(){
		pS = PoolingSystem.Instance;

	}

	void Update(){
		if (pS != null && !finishedSpawning) {
			if (usePoints) {
				for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
					for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {					
						pS.InstantiateAPS ("Box", new Vector3 (x, y, 0), Quaternion.identity);
					}
				}
			} else {
				for (float x = startingXPosition; x <= endingXPosition; x++) {
					for (float y = startingYPosition; y <= endingYPosition; y++) {
						pS.InstantiateAPS ("Box", new Vector3 (x, y, 0), Quaternion.identity);												
					}
				}
			}

			if (exclusionList.Length > 0) { // If there is something to exclude	
				for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
					for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {				
						for (int i = 0; i < exclusionList.Length; i++) {
							if (exclusionList [i].x == x && exclusionList [i].y == y) {

								overlapPositions = Physics2D.OverlapCircleAll(new Vector3 (x, y, 0), .25f);//tempBox = boxObj at this Position
								for(int j = 0; j < overlapPositions.Length; j++){
									if(overlapPositions[j].tag == "ActiveBox" || overlapPositions[j].tag == "InActiveBox"){
										tempBox = overlapPositions[j].gameObject;
										if (tempBox != null) {
											tempBoxControllerScript = tempBox.GetComponent<BoxController> ();
											if (tempBoxControllerScript != null) {
												tempBoxControllerScript.setIsActiveTrue();
											} else {
												Debug.Log ("BoxSpawner: tempBoxControllerScript is null. (1)");
											}
										} else {
											Debug.Log ("BoxSpawner: tempBox is null. (1)");
										}
									}
								}


								/*tempBox = Physics2D.OverlapCircle(new Vector3 (x, y, 0), .25f).gameObject;//tempBox = boxObj at this Position
								if (tempBox != null) {
									tempBoxControllerScript = tempBox.GetComponent<BoxController> ();
									if (tempBoxControllerScript != null) {
										tempBoxControllerScript.setIsActiveTrue();
									} else {
										Debug.Log ("BoxSpawner: tempBoxControllerScript is null. (1)");
									}
								} else {
									Debug.Log ("BoxSpawner: tempBox is null. (1)");
								}*/
							}
						}
					}						
				}
			}
			finishedSpawning = true;
		}

		/*if (Input.GetKeyDown (KeyCode.F5)) {

		}*/
	}

	public void reset(){
		deactivateBoxes ();//Deactive All Boxes

		//Active All Necessary Boxes
		if (exclusionList.Length > 0) { // If there is something to exclude	
			for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
				for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {				
					for (int i = 0; i < exclusionList.Length; i++) {
						if (exclusionList [i].x == x && exclusionList [i].y == y) {
							overlapPositions = Physics2D.OverlapCircleAll(new Vector3 (x, y, 0), .25f);//tempBox = boxObj at this Position

							for(int j = 0; j < overlapPositions.Length; j++){
								if(overlapPositions[j].tag == "ActiveBox" || overlapPositions[j].tag == "InActiveBox"){
									tempBox = overlapPositions[j].gameObject;
								}
							}

							if (tempBox != null) {
								tempBoxControllerScript = tempBox.GetComponent<BoxController> ();
								if (tempBoxControllerScript != null) {
									tempBoxControllerScript.setIsActiveTrue();
								} else {
									Debug.Log ("BoxSpawner: tempBoxControllerScript is null. (3)");
								}
							} else {
								Debug.Log ("BoxSpawner: tempBox is null. (3)");
							}
						}
					}
				}						
			}
		}
	}

	public void deactivateBoxes(){
		for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
			for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {
				overlapPositions = Physics2D.OverlapCircleAll(new Vector3 (x, y, 0), .25f);//tempBox = boxObj at this Position
				for(int i = 0; i < overlapPositions.Length; i++){
					if(overlapPositions[i].tag == "ActiveBox" || overlapPositions[i].tag == "InActiveBox"){
						tempBox = overlapPositions[i].gameObject;
					}
				}
				if (tempBox != null) {
					tempBoxControllerScript = tempBox.GetComponent<BoxController> ();
					if (tempBoxControllerScript != null) {
						tempBoxControllerScript.setIsActiveFalse();
					} else {
						Debug.Log ("BoxSpawner: tempBoxControllerScript is null. (2) ");
					}
				} else {
					Debug.Log ("BoxSpawner: tempBox is null. (2)");
				}
			}
		}
	}

	public void destroyBoxes(){
		for (float x = bottomLeftPoint.position.x; x <= topRightPoint.position.x; x++) {
			for (float y = bottomLeftPoint.position.y; y <= topRightPoint.position.y; y++) {
				overlapPositions = Physics2D.OverlapCircleAll(new Vector3 (x, y, 0), .25f);//tempBox = boxObj at this Position
				for(int i = 0; i < overlapPositions.Length; i++){
					if(overlapPositions[i].tag == "ActiveBox" || overlapPositions[i].tag == "InActiveBox"){
						tempBox = overlapPositions[i].gameObject;
					}
				}
				if (tempBox != null) {
					tempBox.DestroyAPS();
				} else {
					Debug.Log ("BoxSpawner: tempBox is null. (2)");
				}
			}
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (bottomLeftPoint.transform.position, radius);
		Gizmos.DrawWireSphere (topRightPoint.transform.position, radius);
	}

}
