using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCube : MonoBehaviour 
{
    public bool CanAttack = false;

    public HealthManager HM;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<HealthManager>() != null)
        {
            HM = hit.GetComponent<HealthManager>();
            CanAttack = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<HealthManager>() != null)
        {
            HM = null;
            CanAttack = false;
        }
    }
}
