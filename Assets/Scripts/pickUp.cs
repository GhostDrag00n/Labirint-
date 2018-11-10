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
        this.gameObject.SetActive(false);
        DeActivate();
    }

    public override void DeActivate()
    {
        ActivateButton.gameObject.SetActive(false);
        isActivated = !isActivated;
    }
}
