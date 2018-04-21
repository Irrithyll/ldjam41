using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour {

    enum State {
        GO_BAR,
        ORDER_DRINK,
        DRINK,
        FIGHT
    }

    private State state;

    public Game world;

	// Use this for initialization
	void Start () {
        state = State.GO_BAR;
	}

    // Update is called once per frame
    void Update() {
        switch (state) {
            case State.GO_BAR:
                state_go_bar();
                break;
            case State.ORDER_DRINK:
                state_order_drink();
                break;
            case State.DRINK:
                state_drink();
                break;
            case State.FIGHT:
                state_fight();
                break;
        }
	}

    void state_go_bar() {
        GameObject[] barSpots = world.bar.GetComponents<GameObject>();
        foreach (GameObject spot in barSpots) {
            GameObject[] childElements = spot.GetComponents<GameObject>();

        }
    }

    void state_order_drink() {

    }

    void state_drink() {

    }

    void state_fight() {

    }
}
