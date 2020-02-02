using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameEndPopup : MonoBehaviour
{
    public GameObject Popup;

    private void OnEnable() {
    }

    void ShowPopup() {
        Popup.SetActive(true);
        GameSessionManager.onRoundEnd -= ShowPopup;

    }

    void Start() {
        GameSessionManager.onRoundEnd += ShowPopup;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
