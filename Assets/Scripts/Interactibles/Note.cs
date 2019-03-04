using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable {
    
    public GameObject ImageHandeler;
    public GameObject CloseButton;
    public Item noteItem;
    private bool isImageAcitve;

    private void Start()
    {
        isImageAcitve = false;
    }

    public override void Activate()
    {
        isImageAcitve = !isImageAcitve;
        ImageHandeler.SetActive(true);
        ImageHandeler.GetComponent<Image>().sprite = noteItem.ItemImage;
        CloseButton.SetActive(true);
        CloseButton.GetComponent<Button>().onClick.AddListener(AddItemOnCLosing);
        ActivateButton.gameObject.SetActive(false);
    }

    public override void DeActivate()
    {
        if (isImageAcitve)
        {
            HideImage();
            ActivateButton.gameObject.SetActive(false);
        }
    }

    public void HideImage()
    {
        ImageHandeler.SetActive(false);
        CloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
        CloseButton.SetActive(false);
        ActivateButton.gameObject.SetActive(true);
    }

    public void AddItemOnCLosing()
    {
        if (Inventory.instance.Add(noteItem))
        {
            Destroy(this.gameObject);
        }
        HideImage();
    }

}
