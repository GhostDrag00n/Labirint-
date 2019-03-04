using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{

    public Sprite icon;
    public Sprite ItemImage;
    public new string name;
    public Material renderMaterial;
    public string Desctiption = "adsf";
    public bool usable;
    public int price;

    public enum UsableType
    {
        Equipable,
        Note,
        HealthPotion,
        AttackPotion,
        DefencePotion,
    }
    public UsableType Type;

    public void HealthPotion()
    {
        PlayerController.instance.HM.Heal(100);
        Inventory.instance.Delete(this);
    }
}
