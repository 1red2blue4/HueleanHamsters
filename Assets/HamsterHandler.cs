using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHandler : MonoBehaviour {
	public GameObject redDoor;
	public GameObject blueDoor;
	public GameObject yellowDoor;
	private int mode;
	private int objectIndex=1;
	private GameObject myObject;
	public Color yellow;
	public Color red;
	public Color blue;
	public Color drumpf;
	public Color purple;
	public Color green;
	public Camera myCam;
	private bool placingElevator;
	private float elevatorXPos;
	private GameObject elevator;
	public GameObject backdrop;
	private int timer;
	public GameObject[] myObjects;

	public int[] goal;//Color Order is Y B R G P O, 1=allowed, 0=restricted, 2=don't care
	public int[] result={0,0,0,0,0,0};
	public GameObject[] checks;
	public GameObject victoryScreen;
	public GameObject shaft;

	void Start () {
		result=new int[6];
	}
	
	// Update is called once per frame
	void Update () {
		if(placingElevator){
			Ray vRay = myCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(vRay,out hit,1000) && hit.transform.name=="BackDrop"){
				myObject.transform.position=hit.point;
				myObject.transform.position=new Vector3(elevatorXPos,(int)myObject.transform.position.y,0);
			}
			if(Input.GetMouseButtonDown(0) && checkPosition()){
				elevator.transform.GetComponent<ElevatorInScript>().Output=myObject.transform.GetChild(0);
				enableBlockers();
				Vector3 shaftPos = elevator.transform.position;
				if(elevator.transform.position.y>myObject.transform.position.y){
					shaftPos=new Vector3(shaftPos.x,shaftPos.y-1,shaftPos.z);
				}
				else{
					shaftPos=new Vector3(shaftPos.x,shaftPos.y+1,shaftPos.z);
				}
				while(shaftPos!=myObject.transform.position){
					Instantiate(shaft,shaftPos,Quaternion.identity);
					if(shaftPos.y>myObject.transform.position.y){
						shaftPos=new Vector3(shaftPos.x,shaftPos.y-1,shaftPos.z);
					}
					else{
						shaftPos=new Vector3(shaftPos.x,shaftPos.y+1,shaftPos.z);
					}

				}

				myObject=null;
				placingElevator=false;

			}
			return;
		}



		if(Input.GetKeyDown(KeyCode.R)){
			
		}


		if(Input.GetKeyDown("space")){
			if(mode==0){
				mode+=1;
				timer=0;
			}
		}
		if(timer==90){
			timer=0;

			if(transform.GetChild(3).GetComponent<InputScript>().value){
				result[mode-1]=1;
			}
			else{
				result[mode-1]=0;
			}
			if(goal[mode-1]!=2){
				if(goal[mode-1]!=result[mode-1]){
					checks[mode-1].transform.GetComponent<SpriteRenderer>().sprite=checks[mode-1].transform.GetComponent<Check>().wrong;

				}
				else{
					checks[mode-1].transform.GetComponent<SpriteRenderer>().sprite=checks[mode-1].transform.GetComponent<Check>().correct;

				}
			}
			mode++;
			if(mode==7){
				mode=0;
				bool victory=true;
				for(int i=0;i<6;i++){
					if(goal[i]!=2){
						if(goal[i]!=result[i]){
							victory=false;
								checks[i].transform.GetComponent<SpriteRenderer>().sprite=checks[i].transform.GetComponent<Check>().wrong;

						}
						else{
							checks[i].transform.GetComponent<SpriteRenderer>().sprite=checks[i].transform.GetComponent<Check>().correct;

						}

					}
				}
				if(victory)victoryScreen.SetActive(true);
			}

		}
		object[] obj = GameObject.FindObjectsOfType(typeof (GameObject));

		if(Input.GetKeyDown(KeyCode.R)){
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;

				if(g.transform.parent==null && g.transform.name!="Permanent"){
					Destroy(g);
				}
			}
		}

		switch(mode){
		case 0:
			redDoor.GetComponent<OutputScript>().value=false;
			blueDoor.GetComponent<OutputScript>().value=false;
			yellowDoor.GetComponent<OutputScript>().value=false;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;

				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0);
			}
			break;
		case 1:
			timer++;
			redDoor.GetComponent<OutputScript>().value=false;
			blueDoor.GetComponent<OutputScript>().value=false;
			yellowDoor.GetComponent<OutputScript>().value=true;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=yellow;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().yellowHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		case 2:
			timer++;
			redDoor.GetComponent<OutputScript>().value=false;
			blueDoor.GetComponent<OutputScript>().value=true;
			yellowDoor.GetComponent<OutputScript>().value=false;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=blue;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().blueHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		case 3:
			timer++;
			redDoor.GetComponent<OutputScript>().value=true;
			blueDoor.GetComponent<OutputScript>().value=false;
			yellowDoor.GetComponent<OutputScript>().value=false;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=red;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().redHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		case 4:
			timer++;
			redDoor.GetComponent<OutputScript>().value=false;
			blueDoor.GetComponent<OutputScript>().value=true;
			yellowDoor.GetComponent<OutputScript>().value=true;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=green;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().greenHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		case 5:
			timer++;
			redDoor.GetComponent<OutputScript>().value=true;
			blueDoor.GetComponent<OutputScript>().value=true;
			yellowDoor.GetComponent<OutputScript>().value=false;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=purple;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().purpleHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		case 6:
			timer++;
			redDoor.GetComponent<OutputScript>().value=true;
			blueDoor.GetComponent<OutputScript>().value=false;
			yellowDoor.GetComponent<OutputScript>().value=true;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;
				if(g.transform.GetComponent<OutputScript>())
					g.transform.GetComponent<OutputScript>().myColorOn=drumpf;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().sprite=g.transform.GetComponent<Hamster>().drumpfHamster;
				if(g.tag=="Hamster")g.transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
			}
			break;
		}
		if(mode==0){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				objectIndex=1;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				objectIndex=2;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				objectIndex=3;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha4)){
				objectIndex=4;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha5)){
				objectIndex=5;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha6)){
				objectIndex=6;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha7)){
				objectIndex=7;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha8)){
				objectIndex=8;
				if(myObject!=null){
					Destroy(myObject);
				}
			}
			if(Input.GetKeyDown(KeyCode.Alpha9)){
				objectIndex=9;
				if(myObject!=null){
					Destroy(myObject);
				}
			}

			if(objectIndex<myObjects.Length){
				if(myObject==null) myObject=(GameObject)Instantiate(myObjects[objectIndex]);
				Ray vRay = myCam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(vRay,out hit,1000) && hit.transform.name=="BackDrop"){
					myObject.transform.position=hit.point;
					float xPos=myObject.transform.position.x;
					if(xPos>0) xPos=(int)(xPos+.5f);
					else xPos=(int)(xPos-.5f);
					float yPos=myObject.transform.position.y;
					if(yPos>0) yPos=(int)(yPos+.5f);
					else yPos=(int)(yPos-.5f);
					myObject.transform.position=new Vector3(xPos,yPos,0);
				}
			}
			else{
				if(myObject!=null){
					Destroy(myObject);
				}
			}

			if(Input.GetMouseButtonDown(0) && checkPosition()){
				
				if(objectIndex==2){
					placingElevator=true;
					elevatorXPos=myObject.transform.position.x;
					elevator=myObject;
					enableBlockers();
					myObject=(GameObject)Instantiate(myObjects[0]);
				}
				else{
					enableBlockers();
					myObject=null;
				}
				
			}
		}
		else{
			if(myObject!=null){
				Destroy(myObject);
			}
		}

	}

	bool checkPosition(){
		return true;
	}

	void enableBlockers(){
		foreach(Transform child in myObject.transform){
			if(child.GetComponent<BoxCollider>()){
				child.GetComponent<BoxCollider>().enabled=true;
			}
		}
	}
}
