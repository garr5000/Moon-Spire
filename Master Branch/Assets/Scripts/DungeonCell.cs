using UnityEngine;
using System.Collections;

public class DungeonCell : MonoBehaviour {
	float xMove = 0, yMove = 0;
	private bool hasStopped = false;
	private Vector2 lastPos = new Vector2();
	// Use this for initialization
	
	void Start () {
	
	}

	public void Setup() {
		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
		foreach(Transform child in transform){
			child.gameObject.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		float moveAmt;

		GameObject[] cells = GameObject.FindGameObjectsWithTag ("Cell");
		for (int i = 0; i < cells.Length; i++) {
			if (cells [i] != this.gameObject) {
				if (isOverlapping (cells [i])) {
					Vector3 direction = transform.position - cells[i].transform.position;
					moveAmt = 1;

					direction.Normalize ();
					xMove += moveAmt * direction.x;
					yMove += moveAmt * direction.y;
				}
			}
		}

		transform.position = new Vector3 (Mathf.Round (transform.position.x + xMove), Mathf.Round(transform.position.y + yMove), transform.position.z);
		xMove = 0;
		yMove = 0;
		if (transform.position.x == lastPos.x && transform.position.y == lastPos.y)
			hasStopped = true;
		else
			hasStopped = false;

		lastPos = new Vector2 (transform.position.x, transform.position.y);
	}

	private bool isOverlapping(GameObject pObj) {
		Vector2 size = new Vector2 (GetComponent<Renderer> ().bounds.size.x, GetComponent<Renderer> ().bounds.size.y);

		if(pointInside(pObj, new Vector2(transform.position.x+1 - (size.x/2), transform.position.y+1 - (size.y/2))))
		   return true;
		if(pointInside(pObj, new Vector2(transform.position.x-1 + (size.x/2), transform.position.y+1 - (size.y/2))))
		   return true;
		if(pointInside(pObj, new Vector2(transform.position.x+1 - (size.x/2), transform.position.y-1 + (size.y/2))))
		   return true;
		if(pointInside(pObj, new Vector2(transform.position.x-1 + (size.x/2), transform.position.y-1 + (size.y/2))))
		   return true;

		return false;
	}

	private bool pointInside(GameObject pObj, Vector2 pPoint) {
		Vector2 pObjSize = new Vector2 (pObj.GetComponent<Renderer> ().bounds.size.x, pObj.GetComponent<Renderer> ().bounds.size.y);
		if(pPoint.x >= (pObj.transform.position.x - (pObjSize.x/2)) &&
		   pPoint.x <= (pObj.transform.position.x + (pObjSize.x/2)) &&
		   pPoint.y >= (pObj.transform.position.y - (pObjSize.y/2)) &&
		   pPoint.y <= (pObj.transform.position.y + (pObjSize.y/2)))
		   	return true;

		return false;
	}

	public bool getHasStopped() {
		return hasStopped;
	}
}
