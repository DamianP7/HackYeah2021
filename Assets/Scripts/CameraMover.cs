using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public bool move = false;

    public Transform target;
    public float speed;

    public float zoomSpeed;
    public Camera camera;
    public float minZoom;

    private void Update()
    {
        if (!move)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        if (camera.orthographicSize > minZoom)
        camera.orthographicSize -= zoomSpeed;
    }
}
