using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public GameObject player;
    public float smoothSpeed = .125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        if (player != null)
        {
            Vector3 desiredPostiton = player.transform.position + offset;
            Vector3 smootherdPostiton = Vector3.Lerp(transform.position, desiredPostiton, smoothSpeed);
            transform.position = smootherdPostiton;
            transform.LookAt(player.transform);
        }
    }
}
