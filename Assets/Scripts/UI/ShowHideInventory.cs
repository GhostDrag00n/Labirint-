using UnityEngine;

public class ShowHideInventory : MonoBehaviour {

    public GameObject InventoryUI;
    public GameObject InventoryButton;
    public GameObject Stick;
    public GameObject CrouchButton;

    public void ShowInventory()
    {
        InventoryUI.SetActive(true);
        if (InventoryButton!= null)
            InventoryButton.SetActive(false);
        Stick.SetActive(false);
    }

    public void HideInventory()
    {
        InventoryUI.SetActive(false);
        if (InventoryButton!=null)
            InventoryButton.SetActive(true);
        Stick.SetActive(true);
    }
}
