using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {


    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;         // quaternion is the class for the rotation


	// Use this for initialization
	void Start () {

        cameraContainer = new GameObject("Camera Container");     // Create a new GameObject name as Camera Container
        cameraContainer.transform.position = transform.position;  // Set the postion of camera container to thee position of the camera
        transform.SetParent(cameraContainer.transform);           // Make camera container the parent of main camera

        gyroEnabled = EnableGyro();
	}
	
    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)    // Check for the device supports Gyroscope or not?
        {
            gyro = Input.gyro;              // If supports -> take input from the device
            gyro.enabled = true;            // set gyro as enabled

            cameraContainer.transform.rotation = Quaternion.Euler(90f,90f,0f);          //Set the rotation of the cameracontainer
            rot = new Quaternion(0,0,1,0);                                              //need to study this

            return true;
        }
        return false;
    }


    public void Update()
    {
        transform.localRotation = gyro.attitude * rot;

    }

}
