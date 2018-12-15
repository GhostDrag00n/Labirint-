﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int StartHealth;
    [HideInInspector]
    public int Health;
    public float invincibleTime;
    bool isLerping = true;

    #region
    public float SliderSmoothnes;
    public Image HealthImage;
    public Image HealthSlider;
    #endregion

    private void Start()
    {
        Health = StartHealth;
    }

    private void Update()
    {
        if (isLerping)
        {
            HealthSlider.fillAmount = Mathf.Lerp(HealthSlider.fillAmount, HealthImage.fillAmount, SliderSmoothnes * Time.deltaTime);
            if ((HealthSlider.fillAmount - HealthImage.fillAmount) < Mathf.Epsilon)
            {
                isLerping = false;
            }
        }

    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        HealthImage.fillAmount -= (float)damage / (float)StartHealth;
        isLerping = true;
    }
}
