using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {
	public bool value=false;
	public Color myColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<MeshRenderer>().material.color=myColor;
	}
}
