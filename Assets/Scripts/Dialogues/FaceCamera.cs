using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    public Canvas canv;
    Quaternion startRotation;
 
    void Start()
    {
        startRotation = canv.gameObject.transform.rotation;
    }
 
    void LateUpdate()
    {
        canv.gameObject.transform.rotation = startRotation;
    }
}
