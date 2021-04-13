using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TaptoPlace : MonoBehaviour
{
    public GameObject gameObject1;

    private List<GameObject> placedPrebabs = new List<GameObject>();

    public int maxPrefabs = 0;
    private int placedPrefabCount;

    private GameObject spawnPoint1;
    private ARRaycastManager rayManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        rayManager = GetComponent<ARRaycastManager>();
    }

    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if(!GetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(rayManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitP = hits[0].pose;

                if(placedPrefabCount < maxPrefabs)
                {
                    SpawnPrefab(hitP);
                }
            
        }
    }

    public void SetPrefabType(GameObject prefabType)
    {
        gameObject1 = prefabType;
    }

    private void SpawnPrefab(Pose hitP)
    {
        spawnPoint1 = Instantiate(gameObject1, hitP.position, hitP.rotation * Quaternion.Euler(-90, 0, 0));
        placedPrebabs.Add(spawnPoint1);
        placedPrefabCount++;
    }
}
