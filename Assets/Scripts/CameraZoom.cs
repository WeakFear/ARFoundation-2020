using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float Scale = 0.50f;
    public float camtextsize;

    [SerializeField]
    private GameObject cameratextchure;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch Inital = Input.GetTouch(0);
            Touch Final = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 InitalPrevPos = Inital.position - Inital.deltaPosition;
            Vector2 FinalPrevPos = Final.position - Final.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float InitialTouch = (InitalPrevPos - FinalPrevPos).magnitude;
            float FinalTouch = (Inital.position - Final.position).magnitude;

            // Find the difference in the distances between each frame.
            float TouchDifference = InitialTouch - FinalTouch;


            camtextsize = cameratextchure.transform.localScale.x - (TouchDifference * Scale);
            camtextsize = Mathf.Clamp(camtextsize, 1f, 2f);
            cameratextchure.transform.localScale = new Vector2(camtextsize,camtextsize);
            
            




        }
    }
}