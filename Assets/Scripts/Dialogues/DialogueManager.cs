using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{

    //public Dialogue[] dialogues;
    public GameObject player;
    public Dialogue currentDialogue;
    private Dialogue nextDialogue;
    private Dialogue LoopDialogue;
    [HideInInspector]
    public Dialogue LoopStart;
    private int dialogueIndex;
    private PlayerController pc;

    private void Start()
    {
        pc = player.GetComponent<PlayerController>();
        nextDialogue = currentDialogue;
        dialogueIndex = 0;
    }

    public Dialogue GetDialogue()
    {
        if (currentDialogue.type == Dialogue.NodeType.ContinuesDialogue)
        {
            Debug.Log("I am here");
            //nextDialogue = currentDialogue.nextDialogue;
            currentDialogue = nextDialogue.nextDialogue;
            nextDialogue = currentDialogue;
            return currentDialogue;
        }
        else if (currentDialogue.type == Dialogue.NodeType.ItemReqired)
        {
            if (pc.PickedUpItems.Contains(currentDialogue.reqiredItemId))
            {
                currentDialogue = nextDialogue.nextDialogue;
                nextDialogue = currentDialogue;
                return currentDialogue;
                LoopStart = null;
            }
            else
            {
                //LoopDialogue = currentDialogue.LoopDialogue;
                //nextDialogue = currentDialogue.LoopDialogue;
                currentDialogue = currentDialogue.LoopDialogue;
                LoopStart = currentDialogue;
                nextDialogue = currentDialogue;
                return currentDialogue;
            }
        }

        return currentDialogue;
    }
}

/*
 *         Dialogue d = dialogues[dialogueIndex];
        if(d.type == Dialogue.NodeType.ContinuesDialogue)
        {
            if (dialogueIndex == dialogues.Length - 1)
            {
                return d;
            }
            else dialogueIndex++;   
        }
        else if(d.type == Dialogue.NodeType.ItemReqired)
        {
            List<GameObject> arr = player.GetComponent<PlayerController>().PickedUpItems;
            GameObject res = arr.Find(x => x.Equals(d.reqiredItem));
            if (res != null)
            {
                return d;
                dialogueIndex++;
            }
            else 
            {
                //dialogueIndex = Array.FindIndex(dialogues, x => dialogues[x] == d.LoopDialogue);
                return d.LoopDialogue;

                //dialogueIndex = Array.IndexOf(dialogues, d.LoopDialogue);
                //return dialogues[
*/