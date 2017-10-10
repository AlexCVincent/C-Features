using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithPanAndZoom : MonoBehaviour {
    public Transform target;
    public float panSpeed = 5f;
    public float sensitivity = 1f;

    //Minimum & Maximum zoom distance
    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private float distance = 0f;//Distance between target & camera
    //Stored X & Y in euler rotation
    public float x = 0.0f;
    public float y = 0.0f;

   
  
    //Creat an enum to use for mous input (readability)
    public enum MouseButton
    {
        LEFTMOUSE = 0,
        RIGHTMOUSE = 1,
        MIDDLEMOUSE = 2,
    }
	// Use this for initialization
	void Start () {
        // 1. Detach target from children
        //CALL target transform's SetParent(null)
        target.transform.SetParent(Camera.main.transform);
        //2. Calculate distance to target
        distance = Vector3.Distance(transform.position, target.position);
        //3. Record the current euler rotation
        //LET angles = transform's eulerAngles
        Vector3 angles = transform.eulerAngles;
        float x = angles.x;
        float y = angles.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Orbit()
    {
        x = x + Input.GetAxis("Mouse Y") * sensitivity;
        y = y + Input.GetAxis("Mouse X") * sensitivity;
    }
    void Movement()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(x, y, 0);
            float desiredDist = distance - Input.GetAxis("Mouse ScrollWheel");
            desiredDist *= sensitivity;
            distance = Mathf.Clamp(desiredDist, distanceMin, distanceMax);
            Vector3 invDistanceZ = new Vector3(0, 0 - distance);
            invDistanceZ = rotation * invDistanceZ;
            Vector3 position = target.position + invDistanceZ;
            transform.rotation = rotation;
            transform.position = position;
        }
    }
    void Pan()
    {
        float inputX = -Input.GetAxis("Mouse X");
        float inputY = -Input.GetAxis("Mouse Y");

        Vector3 inputDir = new Vector3(inputX, inputY);

        Vector3 movement = transform.TransformDirection(inputDir);
        target.transform.position += movement * panSpeed * Time.deltaTime;
    }
    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
    void LateUpdate()
    {
        if (Input.GetMouseButton((int)MouseButton.RIGHTMOUSE))
        {
            HideCursor(true);
            Orbit();
        }
        else if (Input.GetMouseButton((int)MouseButton.MIDDLEMOUSE))
        {
            HideCursor(true);
            Pan();
        }
        else
        {
            HideCursor(false);
        }
        Movement();
    }
}
