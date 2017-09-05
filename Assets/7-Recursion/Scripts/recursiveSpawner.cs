using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recursiveSpawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public int amount = 10;
    public float positionOffset = 10f;
    [Range(0, 1)]
    public float scalePercentage = .2f;

    void RecursiveSpawn(int currentAmount, Vector3 position, Vector3 scale)
    {
        Vector3 adjustedScale = scale * (1 - scalePercentage);
        Vector3 adjustedPosition = position + Vector3.up * adjustedScale.magnitude* positionOffset;
        
        //Create a new clone of Spawnprefab
        GameObject clone = Instantiate (spawnPrefab);
        clone.transform.position = adjustedPosition;
        clone.transform.localScale = adjustedScale;

        //Decrease amount
        amount--;

        //Exit strategy
        if (amount <= 0)
        {
            return;
        }


        RecursiveSpawn(amount, adjustedPosition, adjustedScale);
    }

	// Use this for initialization
	void Start () {
        Vector3 position = transform.position;
        Vector3 scale = spawnPrefab.transform.localScale;
        RecursiveSpawn(amount, position, scale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
