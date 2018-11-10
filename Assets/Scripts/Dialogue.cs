using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogues/Dialogue", order = 1)]
[System.Serializable]
public class Dialogue : ScriptableObject{

    [System.Flags]
    public enum NodeType
    {
        ContinuesDialogue,
        ItemReqired,
        ActionType
    }

    public Dialogue nextDialogue;
    public Dialogue RestartLDialogue;
    //public Dialogue previousDialogue;

	public new string name;
    public NodeType type;
    public int reqiredItemId;

	[TextArea(3, 10)]
	public string[] sentences;
    public Dialogue LoopDialogue;
}
