using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInScript : MonoBehaviour {
	Transform Input;
	public Transform Output;
	// Use this for initialization
	void Start () {
		Input=transform.GetChild(0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetComponent<InputScript>().value && Output!=null){
			Output.GetComponent<OutputScript>().value=true;
			Output.GetComponent<OutputScript>().myColorOn=Input.GetComponent<InputScript>().myColor;
			transform.GetChild(3).gameObject.SetActive(true);
			Output.transform.parent.GetChild(3).gameObject.SetActive(true);
		}
		else{

			transform.GetChild(3).gameObject.SetActive(false);
			if(Output!=null){
				Output.GetComponent<OutputScript>().value=false;
				Output.transform.parent.GetChild(3).gameObject.SetActive(false);
			}
		}
	}
}