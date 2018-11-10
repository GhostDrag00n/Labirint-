using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour{

    public Button ActivateButton;

    public abstract void Activate();

    //public abstract void StayActivate();

    public abstract void DeActivate();

    public bool isActivated = false;

    //private void OnTriggerEnter(Collider hit)
    //{
        //if(hit.tag == "Player")
        //{
        //    ActivateButton.gameObject.SetActive(true);
        //    ActivateButton.onClick.RemoveAllListeners();
        //    ActivateButton.onClick.AddListener(Activate);
        //    //Activate();
        //}
    //}

    private void OnTriggerStay(Collider hit)
    {
        if (hit.tag == "Player" && isActivated == false)
        {
            AssignActButton();
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "Player")
        {
            ActivateButton.onClick.AddListener(DeActivate);
            ActivateButton.gameObject.SetActive(false);
            isActivated = !isActivated;
        }
    }

    public void AssignActButton()
    {
        isActivated = !isActivated;
        ActivateButton.gameObject.SetActive(true);
        ActivateButton.onClick.RemoveAllListeners();
        ActivateButton.onClick.AddListener(Activate);
    }



}
