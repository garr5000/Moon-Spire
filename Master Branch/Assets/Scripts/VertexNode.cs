using UnityEngine;
using System.Collections;

public class VertexNode {

	private ArrayList neighbors = new ArrayList();
	private Vector2 vertex;
	GameObject parentCell;

	public VertexNode(float x, float y, GameObject pParentCell) {
		vertex = new Vector2 (x, y);
		parentCell = pParentCell;
	}

	public void setNeighbors(VertexNode N1, VertexNode N2) {
		neighbors.Add (N1);
		neighbors.Add (N2);
	}

	public Vector2 getVertex() {
		return vertex;
	}

	public ArrayList getNeighbors() {
		return neighbors;
	}

	public GameObject getParentCell() {
		return parentCell;
	}
}
