using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{

    public Dialogue[] dialogues;
    public GameObject player;
    public Dialogue currentDialogue;
    private Dialogue nextDialogue;
    private int dialogueIndex;

    private void Start()
    {
        nextDialogue = currentDialogue;
        dialogueIndex = 0;
    }

    public Dialogue GetDialogue()
    {
        
        Dialogue d = new Dialogue();
        return d;
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