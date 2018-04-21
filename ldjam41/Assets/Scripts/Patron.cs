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
    public float walkSpeed = 15f;

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

    private GameObject barTarget;

    void state_go_bar() {
        selectBarTarget();
        if (barTarget != null) {
            // TODO: Replace this with proper pathfinding.

            Vector3 tgtPos = barTarget.GetComponent<Transform>().position;
            Vector2 tgt2D = new Vector2(tgtPos.x, tgtPos.y);

            seekTarget(tgt2D);

            // TODO: check distance, if below threshold, change to order state

        } else {
            // TODO: do something else... line up & wait
        }
    }

    private void seekTarget(Vector2 target) {
        // TODO: Make these variables configurable?
        var MinimumDistance = 0.1f;
        var MaximumDistance = 10.0f;
        var StopDistance = 0.05f;
        var MinSpeed = 5.0f;
        var MaxSpeed = 15.0f;

        Rigidbody2D myPhysics = GetComponent<Rigidbody2D>();
        Vector2 myPos = myPhysics.position;

        var dist = Vector2.Distance(target, myPos);
        var moveSpeed = 0.0f;

        if (dist <= StopDistance) {
            moveSpeed = 0.0f;
        } else if (dist > MaximumDistance) {
            moveSpeed = MaxSpeed;
        } else if (dist < MinimumDistance) {
            moveSpeed = MinSpeed;
        } else {
            // speed proportional to distance
            var distRatio = (dist - MinimumDistance) / (MaximumDistance - MinimumDistance);
            var diffSpeed = MaxSpeed - MinSpeed;
            moveSpeed = (distRatio * diffSpeed) + MinSpeed;
        }

        Vector2 direction = target - myPhysics.position;
        Vector2 norm = direction.normalized;
        myPhysics.velocity = (norm * moveSpeed);
    }

    private void selectBarTarget() {
        if (barTarget == null) { 
            Bar barScript = world.bar.GetComponent<Bar>();
            int spotIndex = barScript.getFirstVacantStandSpotIndex();
            if (spotIndex >= 0) {
                GameObject spot = barScript.getStandSpots()[spotIndex];
                barScript.occupySpot(spotIndex, gameObject);

                barTarget = spot; 
            }
        }
    }

    void state_order_drink() {

    }

    void state_drink() {

    }

    void state_fight() {

    }
}
