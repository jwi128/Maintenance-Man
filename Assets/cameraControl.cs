using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 20f;


    public Vector3 offset;

    public float pitch = 2f;

    public float yawSpeed = 100f;
    private float currentYaw = 0f;


    private float zoom = 10f;

    void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;



    }

    public void CameraPositon(Transform bot)
    {
        target = bot;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * zoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
