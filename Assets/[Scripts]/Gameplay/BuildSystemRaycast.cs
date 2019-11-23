using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystemRaycast : MonoBehaviour
{
    private Vector3 currentPosition = Vector3.zero;
    public Transform cam;
    public Transform buildObjectsParent;
    private RaycastHit raycastHit;

    public float raycastMaxDistance = 12.0f;
    public float offset = 1.0f;
    public float gridSize = 1.0f;
    public float previewSnapFactor = 1.0f;

    public Vector3 collisionNormal;
    public LayerMask layersToBuildOn;

    // Function: RaycastExecute
    // RaycastExecute description.
    public void Update()
    {
        Debug.Log(gameObject.name + ".Update()");

    }

    public void RaycastExecute()
    {
        // CustomStart();
        if (Physics.Raycast(cam.position, cam.forward, out raycastHit, raycastMaxDistance, layersToBuildOn))
        {
            if (raycastHit.transform != this.transform)
            { 
                
              //  Object hit event
            
            }
        }

    }
}
