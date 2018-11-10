using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<int> PickedUpItems;

    private void Start()
    {
        PickedUpItems = new List<int>();
    }
}
