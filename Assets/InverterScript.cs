using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterScript : MonoBehaviour {
	Transform Input;
	Transform Output;
	public Sprite onSprite;
	public Sprite offSprite;
	// Use this for initialization
	void Start () {
		Input=transform.GetChild(0);
		Output=transform.GetChild(1);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetComponent<InputScript>().value){
			Output.GetComponent<OutputScript>().value=false;
			Output.GetComponent<OutputScript>().myColorOn=Input.GetComponent<InputScript>().myColor;
			transform.GetChild(3).GetComponent<SpriteRenderer>().sprite=offSprite;
			transform.GetChild(4).gameObject.SetActive(false);
			transform.GetChild(5).gameObject.SetActive(true);
		}
		else{
			Output.GetComponent<OutputScript>().value=true;
			transform.GetChild(3).GetComponent<SpriteRenderer>().sprite=onSprite;
			transform.GetChild(4).gameObject.SetActive(true);
			transform.GetChild(5).gameObject.SetActive(false);

		}
	}
}
