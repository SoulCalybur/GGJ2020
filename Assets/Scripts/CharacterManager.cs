using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{   
    public List<CharacterData> characters;

    public GameObject CharacterSceneObj;
    public ProgressBar progessBar;
    public Text characterText;

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
        characterText.text = currentCharacter.charName + "\n" + currentCharacter.introText;
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
        characterText.text = currentCharacter.charName + "\n" + currentCharacter.introText;
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

    public void AdviceGiven(int oceanType)
    {
        QuestionAsked(oceanType);
        SwitchReaction(oceanType);
        //TODO: 



    }

    public void SwitchReaction(int oceanType)
    {
        switch (oceanType)
        {
            case 0:
                characterText.text = currentCharacter.answers_category_O[0];
                break;
            case 1:
                characterText.text = currentCharacter.answers_category_C[0]; break;
            case 2:
                characterText.text = currentCharacter.answers_category_E[0]; break;
            case 3:
                characterText.text = currentCharacter.answers_category_A[0]; break;
            case 4:
                characterText.text = currentCharacter.answers_category_N[0]; break;
            default: break;

        }

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
