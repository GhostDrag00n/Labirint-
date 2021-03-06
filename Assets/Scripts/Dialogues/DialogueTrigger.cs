using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    [HideInInspector]
    public DialogueCore DC;

    //public Dialogue dialogue;
    public Button DialogueContinue;
    public DialogueManager DM;

    private bool dialogueEnd;

    public void Start()
    {
        dialogueEnd = false;    
        DC = FindObjectOfType<DialogueCore>();
        DM = GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (DC.isDialogueEnded && dialogueEnd)
        {
            dialogueEnd = !dialogueEnd;
            ActivateButton.gameObject.SetActive(true);
        }
    }

    public override void Activate()
    {
        DialogueContinue.gameObject.SetActive(true);
        DC.StartDialogue(DM.GetDialogue());
        DialogueContinue.onClick.AddListener(DC.DisplayNextSentence);
        ActivateButton.gameObject.SetActive(false);
        dialogueEnd = !dialogueEnd;
    }

    public override void DeActivate()
    {
        Debug.Log("Exiting");
        //Debug.Log(DM.LoopStart.sentences[0]);
        //DM.currentDialogue = DM.LoopStart;
        DialogueContinue.onClick.RemoveAllListeners();
    }
}