using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainSetup : MonoBehaviour {
	//number of rooms to gen initially
	private int numRooms = 150;
	private ArrayList cellList = new ArrayList();
	private List<VertexNode> rooms = new List<VertexNode>();

	private DTAlgorithm dtAlg = new DTAlgorithm();
	private bool started = false;
	private bool isSetup = false;
	private bool DTComplete = false;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < numRooms; i++) {
			GameObject newCell = (GameObject)Instantiate(Resources.Load("Cell"));
			int xScale = Random.Range(5,15);
			int yScale = Random.Range(5,15);
//			if (xScale % 2 == 0){ xScale += 1;}
//			if (yScale % 2 == 0){ yScale += 1;}
			int xPos = Random.Range(0,30);
			int yPos = Random.Range(0,30);

			newCell.transform.localScale = new Vector3(xScale, yScale, newCell.transform.localScale.y);
			newCell.transform.position = new Vector3(-10 + xPos, -10 + yPos, 0);
			newCell.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f));
			newCell.GetComponent<DungeonCell>().Setup();

			cellList.Add(newCell);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (cellsStopped()) {
				started = true;
			}
		} else {
			if(!isSetup) {
				selectRooms();
				dtAlg.setupTriangulation(rooms);
				isSetup = true;
			}else {
				if(!DTComplete) {
					if(!dtAlg.getDTDone()) {
						dtAlg.Update();
					}else {
						DTComplete = true;
						//prims here
					}
				}
			}
		}
	}

	private bool cellsStopped() {
		bool stopped = true;
		foreach(GameObject cell in cellList) {
			//if cell is still moving then not all are in place, return true
			if(!cell.GetComponent<DungeonCell>().getHasStopped()){
				stopped = false;
			}
		}
		return stopped;
	}

	private void selectRooms() {
		foreach (GameObject cell in cellList) {
			cell.SetActive (false);
			if(cell.transform.localScale.x > 13 || cell.transform.localScale.y > 13) {
				cell.SetActive(true);
				VertexNode node = new VertexNode(cell.transform.position.x, cell.transform.position.y, cell.gameObject);
				rooms.Add(node);
			}
			Destroy (cell.GetComponent<DungeonCell>());
		}
	}
}
