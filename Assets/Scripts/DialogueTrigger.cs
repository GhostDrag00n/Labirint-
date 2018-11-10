using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    [HideInInspector]
    public DialogueCore DC;

    public Dialogue dialogue;
    public Button DialogueContinue;
    public DialogueManager DM;

    private bool dialogueEnd;

    public void Start()
    {
        DC = FindObjectOfType<DialogueCore>();
        DM = GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (DC.isDialogueEnded && dialogueEnd)
        {
            dialogueEnd = !dialogueEnd;
            ActivateButton.gameObject.SetActive(true);
            Debug.Log(ActivateButton.onClick.GetPersistentEventCount());
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
        DialogueContinue.onClick.RemoveAllListeners();
    }


    //public override void StayActivate()
    //{
    //    ActivateButton.gameObject.SetActive(true);
        //if(DC.isDialogueEnded)
        //{
        //    Activate();
        //}
    //}
}