using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat_e : MonoBehaviour
{
    //public float rotatespeed = 10f;
    private float startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, (Input.GetTouch(0).position.x - Input.GetTouch(0).rawPosition.x) * 2f, 0);
            //Touch touch = Input.GetTouch(0);
            //switch (touch.phase)
            //{
            //    case TouchPhase.Began:
            //        startingPosition = touch.position.x;
            //        break;
            //    case TouchPhase.Moved:
            //        if (startingPosition > touch.position.x)
            //        {
            //            transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
            //        }
            //        else if (startingPosition < touch.position.x)
            //        {
            //            transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
            //        }
            //        break;
            //    case TouchPhase.Ended:
            //        Debug.Log("Touch Phase Ended.");
            //        break;
            //}
        }
    }
}
