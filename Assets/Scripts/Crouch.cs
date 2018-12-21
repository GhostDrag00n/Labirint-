using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Crouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    GameObject PC;

    bool crouching;

	private void Start()
    {
        PC = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (crouching)
        {
            PC.GetComponent<Animator>().SetBool("Crouch", true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("DOWN");
        crouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("UP");
        crouching = false;
    }
}
