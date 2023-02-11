using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{
    private Camera zoomCamera;

    public int minZoom2D, maxZoom2D;
    public int zoomSpeed2D;

    public int minZoom3D, maxZoom3D;
    public int zoomSpeed3D;

    // Start is called before the first frame update
    void Start()
    {
        zoomCamera = Camera.main;
    }

    //Update is called once per frame
    void Update()
    {
        CameraZoom();
    }

    public void CameraZoom()
    {
        // 2D camera 
        if (Camera.main.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                zoomCamera.orthographicSize -= zoomSpeed2D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                zoomCamera.orthographicSize += zoomSpeed2D * Time.deltaTime;
            }

            // restricting value of camera zoom 
            zoomCamera.orthographicSize = Mathf.Clamp(zoomCamera.orthographicSize, minZoom2D, maxZoom2D);

        }
        //3D camera
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                zoomCamera.fieldOfView -= zoomSpeed3D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                zoomCamera.fieldOfView += zoomSpeed3D * Time.deltaTime;
            }

            // restricting value of camera zoom 
            zoomCamera.fieldOfView = Mathf.Clamp(zoomCamera.fieldOfView, minZoom3D, maxZoom3D);
        }
    }
}
