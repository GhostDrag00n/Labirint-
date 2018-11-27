using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : Interactable
{
    public PlayerController PC;
    public Item item;

    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }

    public override void Activate()
    {
        PC.PickedUpItems.Add(item.id);
        Destroy(this.gameObject);
    }   

    public override void DeActivate()
    {
        
    }
}
