using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScript : MonoBehaviour {
	Transform Input;
	Transform Output;
	// Use this for initialization
	void Start () {
		Input=transform.GetChild(0);
		Output=transform.GetChild(1);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetComponent<InputScript>().value){
			Output.GetComponent<OutputScript>().value=true;
			Output.GetComponent<OutputScript>().myColorOn=Input.GetComponent<InputScript>().myColor;
			transform.GetChild(4).gameObject.SetActive(true);
		}
		else{
			Output.GetComponent<OutputScript>().value=false;
			transform.GetChild(4).gameObject.SetActive(false);
		}
	}
}
