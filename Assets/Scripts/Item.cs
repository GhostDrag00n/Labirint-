using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Dialogues/PickableItems", order = 1)]
public class Item : ScriptableObject {

    public Image ico;
    public new string name;
    public int id;
}
