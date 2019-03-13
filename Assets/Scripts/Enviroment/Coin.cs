using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int Money;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag.Equals("PlayerActivation"))
        {
            PlayerController.instance.CM.Add(Money);
            Destroy(this.gameObject);
        }
    }
}
