using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{ 
    public float zoomSpeed = 2f;
    public float maxZoom = 80f;
    private float minZoom = 50.0f;
    private float minPan = 0.0f;
    public float panSpeed = 2f;
    public float maxPan = 5.0f;

    float y;
    void Update()
    {
        if (transform.position.y >= 2)
        {
            ZoomOut();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            ZoomOut();
        }
        else if (Input.GetKey (KeyCode.E))
        {
            ZoomIn();
        }
    }

    void ZoomOut()
    {
        Camera.main.fieldOfView += zoomSpeed / 8;
        if (Camera.main.fieldOfView > maxZoom)
        {
            Camera.main.fieldOfView = maxZoom;
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, panSpeed / 8, Camera.main.transform.position.z);
        panSpeed += 0.1f;
        if (Camera.main.transform.position.y > maxPan)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, maxPan, Camera.main.transform.position.z);
        }
    }

    void ZoomIn()
    {
        Camera.main.fieldOfView -= zoomSpeed / 8;
        if (Camera.main.fieldOfView < minZoom)
        {
            Camera.main.fieldOfView = minZoom;
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, panSpeed / 8, Camera.main.transform.position.z);
        panSpeed -= 0.1f;
        if (Camera.main.transform.position.y < minPan)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, minPan, Camera.main.transform.position.z);
        }
    }

}
