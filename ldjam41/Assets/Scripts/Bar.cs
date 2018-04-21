using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    private GameObject[] barSpots;
    private GameObject[] spotOccupiers;

	// Use this for initialization
	void Start () {
        barSpots = findBarSpots();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private GameObject[] findBarSpots() {
        GameObject[] childObjects = gameObject.GetComponents<GameObject>();
        foreach (GameObject child in childObjects) {

        }

        return null;
    }

    public GameObject[] getRecieveSpots() {
        return null;
    }

    public GameObject[] getStandSpots() {
        return null;
    }

    public GameObject[] getVacantStandSpots() {
        return null;
    }

    public GameObject getFirstVacantStandSpot() {
        return null;
    }

    public void occupySpot(int spotIndex, GameObject occupier) {
        spotOccupiers[spotIndex] = occupier;
    }

    public void vacateSpot(int spotIndex) {
        spotOccupiers[spotIndex] = null;
    }

    public GameObject getSpotOccupier(int spotIndex) {
        return spotOccupiers[spotIndex];
    }

    public bool isSpotOccupied(int spotIndex) {
        return getSpotOccupier(spotIndex) != null;
    }
}
