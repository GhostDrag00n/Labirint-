using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCube : MonoBehaviour 
{
    public bool CanAttack = false;

    public HealthManager HM;

    private void OnTriggerEnter(Collider hit)
    {
        HM = hit.GetComponent<HealthManager>();
        
        if (HM != null)
        {
            CanAttack = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        HM = hit.GetComponent<HealthManager>();

        if (HM != null)
        {
            HM = null;
            CanAttack = false;
        }
    }
}
