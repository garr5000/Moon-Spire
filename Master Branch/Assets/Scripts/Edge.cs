using UnityEngine;
public class Edge {
	
	private VertexNode node0;
	private VertexNode node1;
	
	private Color theDrawColor = new Color(255,0,0,1);
	private LineRenderer theLine;
	
	public Edge(VertexNode _n0, VertexNode _n1){
		node0 = _n0;
		node1 = _n1;
		theLine = new GameObject().AddComponent<LineRenderer>();
		theLine.material = new Material (Shader.Find("Particles/Additive"));
		theLine.name = "EdgeLine";
		theLine.tag = "Lines";
	}
	
	public VertexNode getNode0(){
		return node0;
	}
	
	public VertexNode getNode1(){
		return node1;	
	}
	
	public bool checkSameEdge(Edge _aEdge){
		if 	( (node0 == _aEdge.getNode0() || node0 == _aEdge.getNode1()) &&
		     (node1 == _aEdge.getNode0() || node1 == _aEdge.getNode1())){
			return true;
		}
		
		return false;
	}
	
	public bool edgeContainsVertex(VertexNode _aNode){
		if (node0 == _aNode || node1 == _aNode){
			return true;	
		}
		
		return false;
	}
	
	public void drawEdge(){
		if(node0.getParentCell() != null && node1.getParentCell() != null){
			if (theLine == null){
				theLine = new GameObject().AddComponent<LineRenderer>();
				theLine.name = "EdgeLine";
				theLine.material = new Material (Shader.Find("Particles/Additive"));
				theLine.tag = "Lines";
			}
			
			theLine.SetWidth(0.7f, 0.7f);
			theLine.SetColors(theDrawColor,theDrawColor);
			theLine.SetVertexCount(2);
			theLine.SetPosition(0, new Vector3(node0.getVertex().x, node0.getVertex().y,-3));
			theLine.SetPosition(1,new Vector3(node1.getVertex().x, node1.getVertex().y,-3));
		}
	}

	public void setDrawColor(Color _theColor){
		theDrawColor = new Color(_theColor.r,_theColor.g,_theColor.b,1);
		if (theLine != null)
			theLine.material = new Material (Shader.Find("Particles/Additive"));
		
	}

	
	public void stopDraw(){
		if (theLine != null){
			GameObject.Destroy(theLine.gameObject);	
		}
	}
	
	
	
}
