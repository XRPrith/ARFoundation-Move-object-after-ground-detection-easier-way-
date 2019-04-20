using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;  
[RequireComponent(typeof(ARSessionOrigin))]
public class Spawnattouchedplane : MonoBehaviour
{


  
    public GameObject placedPrefab;
    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        var touch = Input.GetTouch(0);

        if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
        {
       
            var hitPose = s_Hits[0].pose;
            placedPrefab.transform.position = hitPose.position; //places in the position of touch

            Destroy(GetComponent<ARPlaneManager>()); //Destroys plane manager (make sure to put this script where ARPlaneManager is present)
            Destroy(this); //Destroys this script (Stops the movement of object after spawning
        
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARSessionOrigin m_SessionOrigin;
}
