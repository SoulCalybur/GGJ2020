using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum = 100;
    public int currentFill = 50;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        GetFillAmount();
    }

    void GetFillAmount() {
        float fillAmount = (float)currentFill / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
