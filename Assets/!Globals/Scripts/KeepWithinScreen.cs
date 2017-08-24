using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))] //Force Renderer component to be attached
public class KeepWithinScreen : MonoBehaviour {
    private Renderer rend; //Renderer attached to the object
    private Camera cam; // Camera container (variable)
    private Bounds camBounds; //camera bounds structure
    private float camWidth, camHeight;
	// Use this for initialization
	void Start () {
        //set camer variable to main camera
        cam = Camera.main;
        // Get the renderer component attached to this object
        rend.GetComponent<Renderer>();
	}
	
    void UpdateCamBounds()
    {
        //calculate camera bounds
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }
	// Update is called once per frame
	void Update () {
        UpdateCamBounds();
        transform.position = CheckBounds();
	}
    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * .5f;
        float halfHeight = size.y * .5f;
        float halfCamWidth = camWidth * .5f;
        float halfCamHeight = camHeight * .5f;
        //Check left
        if (pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }
        //Check right
        if (pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }
        //Check up
        if(pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.max.y - halfHeight; 
        }
        //Check down
        if (pos.y - halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.min.y + halfHeight;
        }
        return pos;
    }
}
