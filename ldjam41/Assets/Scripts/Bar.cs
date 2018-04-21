using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    private GameObject[] barSpots;
    private GameObject[] standSpots;
    private GameObject[] spotOccupiers;

	// Use this for initialization
	void Start () {
        barSpots = findBarSpots();
        standSpots = findStandSpots();
        spotOccupiers = new GameObject[barSpots.Length];
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private GameObject[] findBarSpots() {
        List<GameObject> foundSpots = new List<GameObject>();

        foreach (Transform child in gameObject.transform) {
            if (child.gameObject.tag == "OrderSpot") {
                foundSpots.Add(child.gameObject);
            }
            
        }

        return foundSpots.ToArray();
    }

    public GameObject[] getRecieveSpots() {
        return null;
    }

    public GameObject[] getStandSpots() {
        return standSpots;
    }

    private GameObject[] findStandSpots() {
        GameObject[] standSpots = new GameObject[barSpots.Length];
        for (int i = 0; i < barSpots.Length; i++) {
            GameObject barSpot = barSpots[i];
            // find stand spot on bar spot
            foreach (Transform child in barSpot.gameObject.transform) {
                if (child.gameObject.tag == "StandSpot") {
                    standSpots[i] = child.gameObject;
                    break;
                }

            }
        }

        return standSpots;
    }

    public int[] getVacantStandSpotIndices() {
        List<int> vacantSpots = new List<int>();

        for (int i = 0; i < standSpots.Length; i++) {
            if (!isSpotOccupied(i)) {
                vacantSpots.Add(i);
            }
        }

        return vacantSpots.ToArray();
    }

    public int getFirstVacantStandSpotIndex() {
        int result = -1;

        int[] vacant = getVacantStandSpotIndices();
        if (vacant != null && vacant.Length > 0) {
            result = vacant[0];
        }

        return result;
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
