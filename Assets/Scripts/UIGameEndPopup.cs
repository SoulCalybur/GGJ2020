using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameEndPopup : MonoBehaviour
{
    public GameObject Popup;

    private void OnEnable() {
        GameSessionManager.onRoundEnd += ShowPopup;
    }

    void ShowPopup() {
        Popup.SetActive(true);
    }

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
