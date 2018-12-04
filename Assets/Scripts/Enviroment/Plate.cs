using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public enum plType
    {
        Light,
        LightStatic,
        Heavy,
        HeavyStatic
    }

    public GameObject player;

    public plType PlateType;

    public bool Active;

    public GameObject ObjectToActivate;

    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log("Object in");
        switch (PlateType)
        {
            case plType.Light:
                if (hit.tag == "Draggable" || hit.tag == "PlayerBody" || hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().Activate();
                }
                break;

            case plType.LightStatic:
                if (hit.tag == "Draggable" || hit.tag == "PlayerBody" || hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().Activate();
                }
                break;

            case plType.Heavy:
                if (hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().Activate();
                }
                break;

            case plType.HeavyStatic:
                if (hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().Activate();
                }
                break;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        switch (PlateType)
        {
            case plType.Light:
                if (hit.tag == "Draggable" || hit.tag == "PlayerBody" || hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().DeActivate();
                }
                break;

            case plType.Heavy:
                if (hit.tag == "Heavy")
                {
                    ObjectToActivate.GetComponent<PlateActivator>().DeActivate();
                }
                break;
        }
    }

}
