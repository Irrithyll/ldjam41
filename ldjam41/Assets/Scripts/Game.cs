using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    private float timer;

    public float timerDuration = 5.0f;
    public float randomTimerDurationRange = 1.0f;

    public GameObject personSpawnPrefab;
    public Transform personSpawnLocaltion;

    public int maxPatrons;
    private LinkedList<GameObject> patrons;
    public GameObject player;

    public GameObject bar;

    // Use this for initialization
    void Start () {
        resetTimer();

        patrons = new LinkedList<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer <= 0.0f) {
            // timer finished
            resetTimer();
            spawnPatron();
        } else {
            // countdown timer
            countDownTimer();
        }
	}

    void spawnPatron() {
        if (patrons.Count < maxPatrons) {
            GameObject newPatron = Instantiate(personSpawnPrefab, personSpawnLocaltion);
            Patron patronScript = newPatron.GetComponent<Patron>();
            if (patronScript) {
                patronScript.world = this;
            }

            patrons.AddLast(newPatron);
        }
    }

    void countDownTimer() {
        timer -= Time.deltaTime;
    }

    void resetTimer() {
        timer = Random.Range(timerDuration - randomTimerDurationRange, timerDuration + randomTimerDurationRange);
    }
}
