using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//TO REIMPLEMENT

namespace ScriptableSystems
{
    public class BuildSystemMonoBehaviour : MonoBehaviour
    {
        public BuildSystemRaycast buildSystemRaycast;

        public Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        public Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        public Material previewMaterial;

        public List<BuildObjectData> buildObjectsData = new List<BuildObjectData>();
        private BuildObjectData currentBuildObject;
        public int currentBuildObjectIndex = 0;
        public Quaternion rotation;
        public Quaternion userRotation;

        public float userRotationF;
        private GameObject currentPreviewGameObject;
        private BuildObjectData currentPreviewObject;
        public Transform currentPreview;
        private Vector3 currentPosition = Vector3.zero;
        private BoxCollider previewCollider;
        private MeshRenderer previewRenderer;

        public Transform cam;
        public Transform buildObjectsParent;
        private RaycastHit raycastHit;


        public float raycastMaxDistance = 12.0f;
        public float offset = 1.0f;
        public float gridSize = 1.0f;
        public float previewSnapFactor = 1.0f;
        public float mainAxisLength = 15.0f;

        private bool canBuild;
        private bool isBuilding;
        private bool isShowingPreview;
        public Vector3 collisionCenterDebug;
        public Vector3 collisionNormal;
        public Vector3 cornerAxisVector = new Vector3(-5, 0, -5);

        public ScriptableBuildSystem scriptableBuildSystem;
        ScriptableEvent ScriptableEventStart;
        ScriptableEvent ScriptableEventStop;

        public ScriptableEventListener scriptableEventListenerOnHit;
        public ScriptableEventListener scriptableEventListenerOnMiss;
        public void Init(ScriptableBuildSystem _scriptableBuildSystem)
        {
            scriptableBuildSystem = _scriptableBuildSystem;
            Debug.Log("BuildSystemMonoBehaviour. Init(): " + _scriptableBuildSystem.id);
            ScriptableEventStart = _scriptableBuildSystem.OnStartEvent;
            ScriptableEventStop = _scriptableBuildSystem.OnStopEvent;

            buildSystemRaycast = new GameObject("buildSystemRaycast").AddComponent<BuildSystemRaycast>();
            buildSystemRaycast.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnHit = new GameObject("scriptableEventListenerOnHit").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnHit.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnHit.Response = new UnityEngine.Events.UnityEvent();

            scriptableEventListenerOnMiss = new GameObject("scriptableEventListenerOnMiss").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnMiss.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnMiss.Response = new UnityEngine.Events.UnityEvent();

            availableColor = _scriptableBuildSystem.availableColor;
            unavailableColor = _scriptableBuildSystem.unavailableColor;
            previewMaterial = _scriptableBuildSystem.previewMaterial;
            buildObjectsData = _scriptableBuildSystem.buildObjects.items;
            buildSystemRaycast.Init(_scriptableBuildSystem);
            scriptableEventListenerOnHit.Event = _scriptableBuildSystem.EventPreviewRaycastHit;
            scriptableEventListenerOnHit.Response.AddListener(() => HandlePreviewHit());
            scriptableEventListenerOnHit.Validate();

            scriptableEventListenerOnMiss.Event = _scriptableBuildSystem.EventPreviewRaycastMiss;
            scriptableEventListenerOnMiss.Response.AddListener(() => HandlePreviewMiss());
            scriptableEventListenerOnMiss.Validate();

        }

        private void Start()
        {
            if (buildObjectsParent == null)
            {
                buildObjectsParent = new GameObject("BuildObjects").transform;
               // buildObjectsParent.parent = gameObject.transform;
            }
            if (isBuilding)
            {
                CustomStart();

            }

        }

        void Update()
        {


            if (isBuilding)
            {
                if (Input.GetKeyDown(KeyCode.N))
                {
                    currentBuildObjectIndex++;
                    CancelPreview();
                    CustomStart();
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    RotatePreview(currentPreviewObject);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isBuilding = !isBuilding;
                    CancelPreview();
                }
                // StartRaycastPreview();
               // CustomStart();
               if(isShowingPreview)
                {
                    ShowPreview();
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        BuildPreviewObject();
                        CustomStart();
                    }


                }

            }
            else
            {

                if (Input.GetKeyDown(KeyCode.B))
                {
                    isBuilding = !isBuilding;
                   

                    CustomStart();
                   // StartRaycastPreview();

                }
                //CancelPreview();

            }

        }

        private void CustomStart()
        {
            currentBuildObjectIndex = currentBuildObjectIndex % buildObjectsData.Count;
            currentBuildObject = buildObjectsData[currentBuildObjectIndex];
            CancelPreview();
            InstantiatePreview();

            //ShowPreview(raycastHit.point, raycastHit.normal);

            StartRaycastPreview();


        }

        public void InstantiatePreview()
        {
            Destroy(currentPreviewGameObject);
            rotation = Quaternion.identity;
            currentPreviewGameObject = Instantiate(currentBuildObject.objectPrefab, currentPosition, rotation);
            currentPreviewGameObject.name = "PreviewPrefab";
            currentPreviewObject = currentBuildObject;
            currentPreviewGameObject.transform.localPosition += currentBuildObject.offset;
            //currentPreviewGameObject.SetActive(false);
            currentPreview = currentPreviewGameObject.transform;
            AddPreviewCollider(currentPreviewGameObject, currentPreviewObject);
            AddPreviewMesh(currentPreviewGameObject, currentPreviewObject);
        }


        public void BuildPreviewObject()
        {
           
            rotation = Quaternion.identity;
            GameObject go = Instantiate(currentBuildObject.objectPrefab, currentPosition, rotation);
            go.name = currentBuildObject.id;
            go.layer = LayerMask.NameToLayer(scriptableBuildSystem.buildObjectLayerString);
           // go.transform.parent = buildObjectsParent;
            AddPreviewCollider(go, currentPreviewObject);
        }
        

        public void StartRaycastPreview()
        {
            //buildSystemRaycast.layersToBuildOn = currentPreviewObject.layersToBuildOn;
            buildSystemRaycast.StartExecute(currentPreviewObject.layersToBuildOn);
            // CustomStart();
            // if (Physics.Raycast(cam.position, cam.forward, out raycastHit, raycastMaxDistance, currentPreviewObject.layersToBuildOn))
            //  {
            //     if (raycastHit.transform != this.transform)
            //    { ShowPreview(raycastHit.point, raycastHit.normal); }
            //  }

        }
        public void CancelPreview()
        {
           if(scriptableBuildSystem.logs) Debug.LogError("CancelPreview");
            if (currentPreviewGameObject != null)
            {
                Destroy(currentPreviewGameObject);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            buildSystemRaycast.StopExecute();

        }

        public void HandlePreviewHit()
        {
            isShowingPreview = true;

        }
        public void HandlePreviewMiss()
        {
            isShowingPreview = false;

        }

        public void ShowPreview()
        {

            if (scriptableBuildSystem.logs) Debug.LogError("ShowPreview");
          Vector3  point = buildSystemRaycast.raycastHit.point;
            Vector3 normal = buildSystemRaycast.raycastHit.normal;

            
            if (currentPreviewObject == null)
            {
                return;

            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ShowPreview( point: " + point + "normal: " + normal);

            float distance = Vector3.Distance(currentPosition, point);
            sb.AppendLine("Distance: " + distance);
            if (distance > (previewSnapFactor * gridSize))
            {

                collisionNormal = normal;

                rotation = Quaternion.FromToRotation(currentPreviewObject.orientationVector, collisionNormal);
                rotation *= Quaternion.Euler(currentPreviewObject.orientationVector * userRotationF);

                currentPosition = point;
                currentPosition -= Vector3.one * offset;
                currentPosition /= gridSize;
                currentPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
                currentPosition *= gridSize;
                currentPosition += Vector3.one * offset;

                currentPreview.position = currentPosition;

                currentPreview.rotation = rotation;
               // Debug.LogError(sb.ToString());

                CheckObject();
            }
            else
            //   if (currentPreview.rotation != rotation)
            {
               // sb.AppendLine("distance too small");
                //   Debug.LogError(sb.ToString());

                // rotation = Quaternion.FromToRotation(currentPreviewObject.orientationVector, collisionNormal);
                //     currentPreview.rotation = rotation;
                CheckObject();
            }


        }

        public bool CheckAvailability()
        {
            //  Debug.Log("CheckAvailability");
            collisionCenterDebug = currentPreview.position + previewCollider.center;
            Collider[] hitColliders = Physics.OverlapBox(currentPreview.position + previewCollider.center, previewCollider.bounds.extents * currentPreviewObject.collsionBoundsFraction, Quaternion.identity, currentPreviewObject.obstacleLayers);
            int i = 0;


            while (i < hitColliders.Length)
            {
                Collider hitCollider = hitColliders[i];
                // Debug.Log("CheckAvailability hit:" + hitCollider.gameObject.name);
                if (hitCollider.gameObject != this.gameObject && hitCollider.gameObject.layer != currentPreviewObject.layersToBuildOn)
                {
                    //Debug.Log("Hit obstacle : " + hitCollider.name);
                    //  Debug.Log("CheckAvailability: uNAVAILABLE");
                    return false;
                }

                i++;
            }
          //  Debug.Log("CheckAvailability: available");

            return true;

        }

        public void CheckObject()
        {
           // Debug.Log("CheckObject  ");


            if (CheckAvailability() == true)
            {
                SetPreviewColor(availableColor);
                canBuild = true;
            }
            else
            {
                canBuild = false;
                SetPreviewColor(unavailableColor);

            }
            if (!currentPreviewGameObject.activeInHierarchy)
            {
                // Debug.Log("CheckObject: !activeInHierarchy ");
                //  currentPreviewGameObject.SetActive(true);
            }
        }

        public void SetPreviewColor(Color c)
        {
            // Debug.Log("SetPreviewColor: " + c);
            previewRenderer.material.color = c;
        }


        private void AddPreviewCollider(GameObject _sceneGO, BuildObjectData _currentPreviewObject)
        {

            BoxCollider boxCollider = _sceneGO.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            if (_currentPreviewObject.objectOrientation == ObjectOrientation.WALL)
            {
                boxCollider.center = new Vector3(0, 0, -(_currentPreviewObject.gridSize.z / 2.0f) + _currentPreviewObject.actualSize.z);


            }
            else if (_currentPreviewObject.objectOrientation == ObjectOrientation.FLOOR)
            {

                boxCollider.center = new Vector3(0, _currentPreviewObject.gridSize.y / 2.0f, 0);

            }
            boxCollider.size = _currentPreviewObject.gridSize;
            previewCollider = boxCollider;

        }

        private void AddPreviewMesh(GameObject _sceneGO, BuildObjectData _currentPreviewObject)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);


            cube.transform.SetParent(_sceneGO.transform);

            cube.transform.localScale = new Vector3(_currentPreviewObject.gridSize.x, _currentPreviewObject.gridSize.y, _currentPreviewObject.gridSize.z);
            if (_currentPreviewObject.objectOrientation ==ObjectOrientation.WALL)
            {
                cube.transform.localPosition = new Vector3(0, 0, -(_currentPreviewObject.gridSize.z / 2.0f) + _currentPreviewObject.actualSize.z);


            }
            else if (_currentPreviewObject.objectOrientation == ObjectOrientation.FLOOR)
            {

                cube.transform.localPosition = new Vector3(0, (_currentPreviewObject.actualSize.y) / 2.0f, 0) + _currentPreviewObject.offset;

            }
            previewRenderer = cube.gameObject.GetComponent<MeshRenderer>();
            previewRenderer.material = previewMaterial;
        }

        private void RotatePreview(BuildObjectData _currentPreviewObject)
        {
            float newAngle = ((rotation.eulerAngles.x * _currentPreviewObject.orientationVector.x * collisionNormal.x)
                + (rotation.eulerAngles.y * _currentPreviewObject.orientationVector.y * collisionNormal.y)
                + (rotation.eulerAngles.z * _currentPreviewObject.orientationVector.z * collisionNormal.z)
                + _currentPreviewObject.rotationStep);

            float newAngleAlt = ((rotation.eulerAngles.x * _currentPreviewObject.orientationVector.x)
               + (rotation.eulerAngles.y * _currentPreviewObject.orientationVector.y)
               + (rotation.eulerAngles.z * _currentPreviewObject.orientationVector.z)
               + _currentPreviewObject.rotationStep);
            Vector3 orientationVectorMultiplied = new Vector3(_currentPreviewObject.orientationVector.x * collisionNormal.x,
                _currentPreviewObject.orientationVector.y * collisionNormal.y,
                 _currentPreviewObject.orientationVector.z * collisionNormal.z);
            //  Debug.LogError("angle: " + newAngle+ ",alt: " + newAngleAlt + ", orientationVector: " + _currentPreviewObject.orientationVector);
            //   Debug.LogError("orMult: " + orientationVectorMultiplied);
            // if (_currentPreviewObject.objectOrientation==Enums.ObjectOrientation.WALL)
            //  {
            //rotation = Quaternion.AngleAxis(newAngle,orientationVectorMultiplied);
            //rotation = Quaternion.AngleAxis(newAngle, _currentPreviewObject.orientationVector);
            // rotation = Quaternion.FromToRotation(currentPreviewObject.orientationVector, collisionNormal);
            // rotation = Quaternion.AngleAxis(newAngle, _currentPreviewObject.orientationVector);
            // userRotation = Quaternion.AngleAxis(newAngleAlt, _currentPreviewObject.orientationVector);
            currentPreview.Rotate(_currentPreviewObject.orientationVector, newAngle);
            Debug.LogError("userRotation: " + userRotation.eulerAngles);

            // currentPreview.rotation = rotation;



            //StartPreview();
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(currentPosition, 0.04f);
            // Gizmos.color = Color.red;
            Gizmos.DrawSphere(raycastHit.point, 0.02f);

            Gizmos.DrawLine(raycastHit.point, raycastHit.point + raycastHit.normal);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.right * mainAxisLength);
            if (currentPreview != null)
            {

                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.right * 1.5f);

            }

            Gizmos.color = Color.green;
            Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.up * mainAxisLength);
            if (currentPreview != null)
            {

                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.up * 1.5f);
            }
            Gizmos.color = Color.blue;
            if (currentPreview != null)
            {

                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.forward * 1.5f);
            }
            Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.forward * mainAxisLength);

        }
    }
}