using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : Interactable
{
    public Item item;

    private void Start()
    {
        if (item.renderMaterial != null)
            this.GetComponent<MeshRenderer>().material = item.renderMaterial;
    }

    public override void Activate()
    {
        if (Inventory.instance != null)
        {
            Inventory.instance.Add(item);
        }
        //PlayerController.instance.Inventory.Add(item.id);
        Destroy(this.gameObject);
    }   

    public override void DeActivate()
    {
        
    }
}
