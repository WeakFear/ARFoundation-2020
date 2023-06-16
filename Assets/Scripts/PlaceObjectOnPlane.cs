using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

// Add this header if you want your component to be added automatically
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectOnPlane : MonoBehaviour
{
    // What object would you like to spawn
    [SerializeField] private GameObject prefab;
    private GameObject spawnedObject;

    //3 object Materials

    [SerializeField]
    private Material beige;

    [SerializeField]
    private Material monochrome;

    [SerializeField]
    private Material glitch;

    private ARRaycastManager raycaster;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Start()
    {
        raycaster = GetComponent<ARRaycastManager>();
    }


    //3 buttons for object materials

    public void beigeMaterial()
    {
        spawnedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = beige;
    }

    public void monochromeMaterial()
    {
        spawnedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = monochrome;
    }

    public void glitchMaterial()
    {
        spawnedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = glitch;
    }

    public void OnPlaceObject(InputValue value)
    {
        // Get the screen touch position
        Vector2 touchPosition = value.Get<Vector2>();   
        // Perform a raycast from the touchPosition into the 3D scene to look for a plane
        if(raycaster.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            // Get the hit point (pose) on the plane
            Pose hitPoint = hits[0].pose;
            // Is this the first time we will place an object?
            if(spawnedObject == null) 
            {
                // Instantiate our own prefab
                spawnedObject = Instantiate(prefab, hitPoint.position, hitPoint.rotation);
            }
            else
            {
                // If there is an existing spawnedObject, we simply move its position
                spawnedObject.transform.SetPositionAndRotation(hitPoint.position, hitPoint.rotation);
            }
        } 
    }
}

