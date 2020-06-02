using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndScript : MonoBehaviour {
	Transform Input1;
	Transform Input2;
	Transform Output;
	public Sprite onSprite;
	public Sprite offSprite;
	// Use this for initialization
	void Start () {
		Input1=transform.GetChild(0);
		Input2=transform.GetChild(1);
		Output=transform.GetChild(2);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input1.GetComponent<InputScript>().value && Input2.GetComponent<InputScript>().value){
			Output.GetComponent<OutputScript>().value=true;
			Output.GetComponent<OutputScript>().myColorOn=Input1.GetComponent<InputScript>().myColor;


		}
		else{
			Output.GetComponent<OutputScript>().value=false;
		}
		if(Input1.GetComponent<InputScript>().value){

			transform.GetChild(4).GetComponent<SpriteRenderer>().sprite=onSprite;
		}
		else{
			transform.GetChild(4).GetComponent<SpriteRenderer>().sprite=offSprite;
		}

		if(Input1.GetComponent<InputScript>().value && !Input2.GetComponent<InputScript>().value){
			transform.GetChild(5).gameObject.SetActive(true);
			transform.GetChild(6).gameObject.SetActive(false);
			transform.GetChild(7).gameObject.SetActive(false);
		}
		else if(!Input1.GetComponent<InputScript>().value && Input2.GetComponent<InputScript>().value){
			transform.GetChild(5).gameObject.SetActive(false);
			transform.GetChild(6).gameObject.SetActive(true);
			transform.GetChild(7).gameObject.SetActive(false);
		}
		else if(Input1.GetComponent<InputScript>().value && Input2.GetComponent<InputScript>().value){
			transform.GetChild(5).gameObject.SetActive(false);
			transform.GetChild(6).gameObject.SetActive(false);
			transform.GetChild(7).gameObject.SetActive(true);
		}
		else{
			transform.GetChild(5).gameObject.SetActive(false);
			transform.GetChild(6).gameObject.SetActive(false);
			transform.GetChild(7).gameObject.SetActive(false);
		}
	}
}
