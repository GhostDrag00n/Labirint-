using UnityEngine;

public class ShowHideUI : MonoBehaviour {

    public GameObject UI;
    public GameObject UIButton;
    public GameObject Stick;
    public GameObject CrouchButton;


    public void Change()
    {
        UI.SetActive(!UI.activeSelf);
        if (UIButton!=null)
            UIButton.SetActive(!UIButton.activeSelf);
        Stick.SetActive(!Stick.activeSelf);
    }
}
