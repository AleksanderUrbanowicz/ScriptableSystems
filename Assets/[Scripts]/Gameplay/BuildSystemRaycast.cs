using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class BuildSystemRaycast : MonoBehaviour
    {

        public Transform cam;

        public RaycastHit raycastHit;
        public bool isRaycasting;
        public int raycastInterval;
        public int counter=0;
        public float raycastMaxDistance = 12.0f;
        public float offset = 1.0f;
        public float gridSize = 1.0f;
        public float previewSnapFactor = 1.0f;

        public Vector3 collisionNormal;
        public LayerMask layersToBuildOn;
        public bool output;
        public ScriptableEvent ScriptableEventHit;
        public ScriptableEvent ScriptableEventMiss;


        public void Init(ScriptableBuildSystem scriptableBuildSystem)
        {
            cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
            layersToBuildOn= scriptableBuildSystem.buildObjects.items[0].layersToBuildOn;
            ScriptableEventHit = scriptableBuildSystem.EventPreviewRaycastHit;
            ScriptableEventMiss = scriptableBuildSystem.EventPreviewRaycastMiss;
            raycastInterval = scriptableBuildSystem.raycastInterval;
        }
        public void Update()
        {
            if (isRaycasting)
            {
                counter++;
                if(counter>=raycastInterval)
                {
                    
                    if (output != Physics.Raycast(cam.position, cam.forward, out raycastHit, raycastMaxDistance, layersToBuildOn))
                    {
                        output = !output;
                        if(output)
                        {
                            ScriptableEventHit.Raise();
                        }
                        else { ScriptableEventMiss.Raise(); }
                        

                    }
                    
                    /*
                    output = Physics.Raycast(cam.position, cam.forward, out raycastHit, raycastMaxDistance, layersToBuildOn);
                    if(output)
                    {
                        ScriptableEventHit.Raise();

                    }

    */
                    counter = 0;
                }
              
            }
        }

        public void StartExecute(LayerMask _layersToBuildOn)
        {
            layersToBuildOn = _layersToBuildOn;
            isRaycasting = true;
        }
        public void StopExecute()
        {
            isRaycasting = false;
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
}