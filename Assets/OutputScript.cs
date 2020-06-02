using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputScript : MonoBehaviour {
	public bool value=false;
	private bool prevValue=false;
	public Color myColorOn;
	public Color myColorOff;
	private Color prevColor;
	private int timer;
	// Use this for initialization
	void Start () {
		prevColor=myColorOn;
		timer=10;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(value!=prevValue || prevColor!=myColorOn){
			timer=0;
			//sendSignal();
		}

		if(timer==3)sendSignal();
		prevValue=value;
		prevColor=myColorOn;
		if(value){
			transform.GetComponent<MeshRenderer>().material.color=myColorOn;
		}
		else{
			transform.GetComponent<MeshRenderer>().material.color=myColorOff;
		}
	}

	void sendSignal(){
		
		RaycastHit hit;
		if(Physics.Raycast(transform.position,new Vector3(1,0,0),out hit,1)){
			if(hit.transform.GetComponent<InputScript>()){
				hit.transform.GetComponent<InputScript>().value=value;
				if(value)
					hit.transform.GetComponent<InputScript>().myColor=myColorOn;
				else
					hit.transform.GetComponent<InputScript>().myColor=new Color(0,0,0);
			}
		}
	}
}
