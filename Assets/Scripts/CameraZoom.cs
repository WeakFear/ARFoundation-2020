using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float orthospd = 0.50f;
    public float camtextsize;
    [SerializeField]
    private GameObject cameratextchure;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            //if (camera.isOrthoGraphic)
            //{
            //    // ... change the orthographic size based on the change in distance between the touches.
            //    camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

            //    // Make sure the orthographic size never drops below zero.
            //    camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            //}

            camtextsize = cameratextchure.transform.localScale.x + (deltaMagnitudeDiff * orthospd);
            camtextsize = Mathf.Clamp(camtextsize, 1f, 2f);
            cameratextchure.transform.localScale = new Vector2(camtextsize,camtextsize);
            
            




        }
    }
}