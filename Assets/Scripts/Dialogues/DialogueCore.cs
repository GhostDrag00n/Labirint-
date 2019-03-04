using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueCore : MonoBehaviour {

    public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
    public GameObject DialogueContinue;
    public List<GameObject> UIElementsToDisable;
    public bool isDialogueEnded;
    public bool isDialoguePlaying;
    public Button[] choises;

    private bool[] UIElementsToEnable;
    private Queue<string> sentences;


    void Start()
    {
        isDialogueEnded = false;
        sentences = new Queue<string>();
        UIElementsToEnable = new bool[UIElementsToDisable.Count];
        for (int i = 0; i < UIElementsToDisable.Count; i++)
        {
            UIElementsToEnable[i] = UIElementsToDisable[i].activeSelf;
        }
    }

	public void StartDialogue (Dialogue dialogue)
	{
        isDialogueEnded = false;
        //animator.SetBool("IsOpen", true);
        foreach (GameObject go in UIElementsToDisable)
        {
            if(go.activeSelf == true)
            {
                go.SetActive(false);  

            }
        }

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

        DialogueContinue.SetActive(false);
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
        if (!isDialogueEnded)
        {
            StopAllCoroutines();
            dialogueText.text = "";
            dialogueText.text = sentence;
            Debug.Log(sentence);
        }
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
        DialogueContinue.SetActive(true);
	}

	void EndDialogue()
	{
        isDialogueEnded = true;
        nameText.text = "";
        dialogueText.text = "";
        //Debug.Log("Dialogude end");
        for (int i = 0; i < UIElementsToDisable.Count; i++)
        {
            if (UIElementsToEnable[i] == true)
            {
                UIElementsToDisable[i].SetActive(true);
            }
        }
        DialogueContinue.SetActive(false);
	}
}
