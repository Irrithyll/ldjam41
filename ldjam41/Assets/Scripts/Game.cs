using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    private float timer;

    public float timerDuration = 1000.0f;
    public float randomTimerDurationRange = 100.0f;

    public GameObject personSpawnPrefab;
    public Transform personSpawnLocaltion;

    // Use this for initialization
    void Start () {
        resetTimer();
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer <= 0.0f) {
            // timer finished
            resetTimer();
            doTheThing();
        } else {
            // countdown timer
            countDownTimer();
        }
	}

    void doTheThing() {
        Instantiate(personSpawnPrefab, personSpawnLocaltion);
    }

    void countDownTimer() {
        timer -= Time.deltaTime;
    }

    void resetTimer() {
        timer = Random.Range(timerDuration - randomTimerDurationRange, timerDuration + randomTimerDurationRange);
    }
}
