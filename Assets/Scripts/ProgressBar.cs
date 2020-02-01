using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum = 100;
    public int currentFill = 50;

    [Range(0.0f,1.0f)]
    public float fillAmount = 0.0f;

    public Image mask;
    public Image fill;
    public Color color_neutral;
    public Color color_stressed;


    // Update is called once per frame
    void Update() {
        UpdateFillAmount();
    }
    public void SetFillAmount(float amount) {
        Debug.Assert((amount >= 0.0f && amount <= 1.0f), "Fill amount not in Range(0,1)!");
        fillAmount = amount;
    }

    void UpdateFillAmount() {
        //fillAmount = (float)currentFill / (float)maximum;
        mask.fillAmount = fillAmount;
        Color tmpColor = (1.0f - fillAmount) * color_neutral + (fillAmount * color_stressed);
        tmpColor.a = 1.0f;
        fill.color = tmpColor;
    }
}
