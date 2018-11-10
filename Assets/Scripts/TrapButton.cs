using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapButton : Interactable
{

    public GameObject TrapParent;
    [HideInInspector]
    public GameObject[] traps;
    public float timeToShow;

    private void Start()
    {
        traps = GetAllTraps(TrapParent);
        AllUp(traps);
    }

    public override void Activate()
    {
        StartCoroutine(ShowThenHide(traps, timeToShow));

    }

    public override void DeActivate()
    {
        
    }

    IEnumerator ShowThenHide(GameObject[] traps, float t)
    {
        foreach (GameObject go in traps)
        {
            if (go.GetComponent<Trap>().isSafe)
                go.GetComponent<Animator>().SetBool("isActive", false);
        }

        yield return new WaitForSeconds(t);
        foreach(GameObject go in traps)
        {
            go.GetComponent<Animator>().SetBool("isActive", false);
        }
    }

    void AllUp(GameObject[] traps)
    {
        foreach (GameObject go in traps)
        {
            go.GetComponent<Animator>().SetBool("isActive", true);
        }
    }

    GameObject[] GetAllTraps(GameObject parent)
    {
        GameObject[] traps = new GameObject[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            traps[i] = parent.transform.GetChild(i).gameObject;
        }
        return traps;
    }

    //public override void StayActivate()
    //{
    //    throw new System.NotImplementedException();
    //}
}