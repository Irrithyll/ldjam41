using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer <= 0.0f) {
            // timer finished
            doTheThing();
        } else {
            // countdown timer
            countDownTimer();
        }
	}

    void doTheThing() {

    }

    void countDownTimer() {

    }
}
