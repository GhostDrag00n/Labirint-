using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingObjects : MonoBehaviour {

    public List<string> tags;

    private void OnTriggerEnter(Collider hit)
    {
        if (tags.Contains(hit.tag))
            hit.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider hit)
    {
        if (tags.Contains(hit.tag))
            hit.transform.parent = null;
    }
}
