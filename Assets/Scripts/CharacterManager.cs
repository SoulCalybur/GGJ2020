using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterManager : MonoBehaviour
{   
    public List<CharacterData> characters;

    public GameObject CharacterSceneObj;
    public ProgressBar progessBar;

    private SpriteRenderer sRenderer;

    // CURRENTLY loaded
    CharacterData currentCharacter;
    int charIndex = 0;

    void Start() {
        sRenderer = CharacterSceneObj.GetComponent<SpriteRenderer>();
        currentCharacter = characters[charIndex];
        currentCharacter.stressLevel = 0;
        UpdateCharExpressionSprite();
        progessBar.SetFillAmount(currentCharacter.stressLevel);
        charIndex++;
    }

    void loadNextCharacter() {
        if (charIndex >= characters.Count) {
            Debug.Log("Last character reached. End the Round");
            EndRound();
            return;
        }
        currentCharacter = characters[charIndex];
        currentCharacter.stressLevel = 0;
        UpdateCharExpressionSprite();
        progessBar.SetFillAmount(currentCharacter.stressLevel);

        charIndex++;
        Debug.Log("CharIndex = " + charIndex);
        

    }

    // Update is called once per frame
    void Update() {

        
    }
    void UpdateCharExpressionSprite() {
        sRenderer.sprite = currentCharacter.GetExprByStressLvl();
    }

    private void EndRound() {

    }

    public void QuestionAsked(int buttonIndex) {
        float amount = currentCharacter.GetStressAmountByCategory(buttonIndex);
        currentCharacter.stressLevel += amount;
        if (currentCharacter.stressLevel < 0.0f) {
            Debug.Log("Character stressLevel ZERO!");
            currentCharacter.stressLevel = 0.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();

        } else if (currentCharacter.stressLevel > 1.0f) {
            Debug.Log("Character stressLevel MAXED!");
            currentCharacter.stressLevel = 1.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();

            loadNextCharacter();
        } else {
            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
        }
    }

}
