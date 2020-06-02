using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterScript : MonoBehaviour {
	Transform Input;
	Transform Output1;
	Transform Output2;
	// Use this for initialization
	void Start () {
		Input=transform.GetChild(0);
		Output1=transform.GetChild(1);
		Output2=transform.GetChild(2);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetComponent<InputScript>().value){
			Output1.GetComponent<OutputScript>().value=true;
			Output2.GetComponent<OutputScript>().value=true;
			transform.GetChild(5).gameObject.SetActive(true);
		}
		else{
			Output1.GetComponent<OutputScript>().value=false;
			Output2.GetComponent<OutputScript>().value=false;
			transform.GetChild(5).gameObject.SetActive(false);
		}
	}
}
