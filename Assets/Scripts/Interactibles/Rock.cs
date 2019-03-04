using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Interactable {

    public PlayerController player;
    public Item reqiredItem;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public override void Activate()
    {
        if (Inventory.instance.Exist(reqiredItem))
        {
            Inventory.instance.Delete(reqiredItem);
            DestroyRock();
        }
    }

    public override void DeActivate()
    {
        
    }

    void DestroyRock()
    {
        Destroy(GetComponent<SphereCollider>());
        //Make some fancy destruction
        Destroy(this.gameObject);
    }
}
