using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateActivator : MonoBehaviour {

    public Material first;
    public Material second;

    public void Activate()
    {
        Debug.Log("Stepped In");
        GetComponent<Renderer>().material = first;
    }
    public void DeActivate()
    {
        Debug.Log("Stepped Out");
        GetComponent<Renderer>().material = second;
    }
}
