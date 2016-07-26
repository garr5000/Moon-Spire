using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Triangle {


	private List<Edge> edges = new List<Edge>();
	private Color edgeColor = new Color(255,0,0,1);

	public Triangle(Edge edge1, Edge edge2, Edge edge3) {
		edges.Add (edge1);
		edges.Add (edge2);
		edges.Add (edge3);
	}

	public List<Edge> getEdges() {
		return edges;
	}

	public void drawTriangle() {
		foreach(Edge edge in edges)
			edge.drawEdge();
	}

	public void stopDraw() {
		foreach (Edge edge in edges)
			edge.stopDraw ();
	}

	public bool hasVertex(VertexNode vertex) {
		foreach (Edge edge in edges) {
			if(edge.getNode0() == vertex || edge.getNode1() == vertex)
				return true;
		}
		return false;
	}

	public bool checkSharedEdge(Triangle triangle) {
		foreach (Edge edge in triangle.getEdges()) {
			foreach(Edge myEdge in edges) {
				if(myEdge.checkSameEdge(edge))
				   return true;
			}
		}
		return false;
	}

	public bool checkContainsEdge(Edge edge) {
		foreach(Edge myEdge in edges) {
			if(myEdge.checkSameEdge(edge))
			   return true;
		}
		return false;
	}

	public void setDrawColor(Color color){
		edgeColor = color;	
		foreach(Edge edge in edges){
			edge.setDrawColor(color);	
		}
	}

	public void setEdges(Edge edge1, Edge edge2, Edge edge3) {
		foreach (Edge edge in edges)
			edge.stopDraw ();
		edges.Clear ();

		edges.Add (edge1);
		edges.Add (edge2);
		edges.Add (edge3);
	}
}
