using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable {

    public Sprite image;
    public GameObject ImageHandeler;
    public GameObject CloseButton;

    public override void Activate()
    {
        ImageHandeler.SetActive(true);
        ImageHandeler.GetComponent<Image>().sprite = image;
        CloseButton.SetActive(true);
        CloseButton.GetComponent<Button>().onClick.AddListener(DeActivate);
        ActivateButton.gameObject.SetActive(false);
    }

    public override void DeActivate()
    {
        ImageHandeler.SetActive(false);
        CloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
        CloseButton.SetActive(false);
        ActivateButton.gameObject.SetActive(true);
    }

}
