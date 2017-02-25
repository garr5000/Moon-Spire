using UnityEngine;
using System.Collections;



public class testAI : MonoBehaviour {

	public Animator anim;
	public Transform trans;
	public int pattern = 0;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		trans = GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () 
		{


		if(trans.position.x > -5 && trans.position.y <= 0)
		{
			trans.position = new Vector3(trans.position.x - 0.1f, trans.position.y, trans.position.z);
			anim.Play("Walk Left");
		}
		if(trans.position.x <= -5 && trans.position.y < 5)
		{
			trans.position = new Vector3(trans.position.x, trans.position.y + 0.1f, trans.position.z);
			anim.Play("Walk Up");
		}
		if(trans.position.x < 0 && trans.position.y >= 5)
		{
			trans.position = new Vector3(trans.position.x + 0.1f, trans.position.y, trans.position.z);
			anim.Play("Walk Right");
		}
		if(trans.position.x >= 0 && trans.position.y > 0)
		{
			trans.position = new Vector3(trans.position.x, trans.position.y - 0.1f, trans.position.z);
			anim.Play("Walk Down");
		}



		}

	}
		
	
	
	


