using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Countdown : MonoBehaviour {

    public float timer = 180.0f;
    public Text uiText;

  
        void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 0.0f;
            Debug.Log("Timer is up!");
            GameSessionManager.RaiseOnEnd();
        } else {
            UpdateText();
        }
    }

    private void UpdateText() {
        int minutes = (int)(timer / 60.0f);
        int seconds = Mathf.RoundToInt(timer) % 60;

        string minutesText;
        if (minutes < 10) minutesText = "0" + minutes;
        else minutesText = minutes.ToString();

        string secondsText;
        if (seconds < 10) secondsText = "0" + seconds;
        else secondsText = seconds.ToString();

        uiText.text = minutesText + ":" + secondsText;

    }

}
