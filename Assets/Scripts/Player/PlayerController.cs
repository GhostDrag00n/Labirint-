using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public int health;
    int currentHealth;
    public float invincibleTime;
    bool isLerping = true;

    #region
    public float SliderSmoothnes;
    public Image Health;
    public Image HealthSlider;
    #endregion

    float timer = 0;

    public List<int> PickedUpItems;

    private void Start()
    {
        currentHealth = health;
        PickedUpItems = new List<int>();
    }

    private void Update()
    {
        if (isLerping)
        {
            HealthSlider.fillAmount = Mathf.Lerp(HealthSlider.fillAmount, Health.fillAmount, SliderSmoothnes * Time.deltaTime);
            if ((HealthSlider.fillAmount - Health.fillAmount) < Mathf.Epsilon)
            {
                isLerping = false;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Health.fillAmount -= (float)damage / 100f;
        HealthSlider.fillAmount = Mathf.Lerp(HealthSlider.fillAmount, Health.fillAmount, Time.deltaTime);
        isLerping = true;
    }


    //IEnumerator Slide(out float f, float a, float b, float t)
    //{
    //    f = Mathf.Lerp(a, b, t);
    //    yield return new WaitForSeconds(t);
    //}
}
