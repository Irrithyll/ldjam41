using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
     public float walkSpeed = 15f;
     private float curSpeed;

	void Start () {
 
	}

	void FixedUpdate() {
		curSpeed = walkSpeed;

		float x = Mathf.Lerp(0, Input.GetAxis("Horizontal")* curSpeed, 0.8f);
		float y = Mathf.Lerp(0, Input.GetAxis("Vertical")* curSpeed, 0.8f);

		GetComponent<Rigidbody2D>().velocity = new Vector2(x,y);
	}
	
	void Update () {
		
	}
}
