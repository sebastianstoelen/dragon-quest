using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Tilemap tilemap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {

        target = PlayerController.instance.transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        Vector3 mapMin = tilemap.localBounds.min;
        Vector3 mapMax = tilemap.localBounds.max;

        bottomLeftLimit = mapMin + new Vector3(halfWidth, halfHeight, 0);
        topRightLimit = mapMax + new Vector3(-halfWidth, -halfHeight, 0);

        PlayerController.instance.SetBounds(mapMin, mapMax);
    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        transform.position = GetNewCameraPosition();
    }

    private Vector3 GetNewCameraPosition()
    {
        float newXPosition = Mathf.Clamp(target.position.x, bottomLeftLimit.x, topRightLimit.x);
        float newYPosition = Mathf.Clamp(target.position.y, bottomLeftLimit.y, topRightLimit.y);

        return new Vector3(newXPosition, newYPosition, transform.position.z);
    }
}
