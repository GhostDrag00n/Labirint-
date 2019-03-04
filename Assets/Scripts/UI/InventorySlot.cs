using UnityEngine;
using UnityEngine.UI;
using TMPro;
   
public class InventorySlot : MonoBehaviour 
{
    public Color activeColor;
    public Image icon;
    public GameObject CurrentItemImg;
    public GameObject ItemDescription;
    public GameObject UseButton;
    Item item;


    public void AddItem(Item NewItem)
    {
        item = NewItem;

        if (item.icon != null)
            icon.sprite = item.icon;
        icon.enabled = true;
    }
	
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void Clear()
    {
        CurrentItemImg.GetComponent<Image>().sprite = null;
        ItemDescription.GetComponent<TextMeshProUGUI>().text = "";
        UseButton.SetActive(false);

    }

    public void DisplayInfo()
    {
        Debug.Log("displaying info");
        UseButton.SetActive(false);

        if (item != null)
        {
			CurrentItemImg.GetComponent<Image>().sprite = item.ItemImage;
			ItemDescription.GetComponent<TextMeshProUGUI>().text = item.Desctiption;
            if (item.usable)
            {
                UseButton.SetActive(true);
                UseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";

                switch (item.Type)
                {
                    case Item.UsableType.HealthPotion:
						UseButton.GetComponent<Button>().onClick.AddListener(Clear);
                        UseButton.GetComponent<Button>().onClick.AddListener(item.HealthPotion);
                        return;
                }
            }
        }
            
    }
}
