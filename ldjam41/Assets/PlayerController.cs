using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
     public float walkSpeed = 15f;
     private float curSpeed;
	 public string dir = "RIGHT";

	void Start () {
 
	}

	void FixedUpdate() {
		curSpeed = walkSpeed;

		float xdir = Input.GetAxis("Horizontal");
		float ydir = Input.GetAxis("Vertical");

		float x = Mathf.Lerp(0, xdir* curSpeed, 0.8f);
		float y = Mathf.Lerp(0, ydir* curSpeed, 0.8f);

		if(xdir >= 0){
			dir = "RIGHT";
		}else if(xdir < 0){
			dir = "LEFT";
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			punchSomeone();
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(x,y);
	}
	
	void Update () {
		
	}

	private void punchSomeone() {
		Debug.Log("punch someone!");
	}
}
