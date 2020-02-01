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
        currentCharacter = characters[0];
        charIndex++;

        sRenderer.sprite = currentCharacter.expressionSprites[0];
        progessBar.SetFillAmount(currentCharacter.stressLevel);
    }

    void loadNextCharacter() {
        charIndex++;
        currentCharacter = characters[charIndex % characters.Count];
        UpdateCharExpressionSprite();
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.D)) {
            increaseStress();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            decreaseStress();
        }
    }
    void UpdateCharExpressionSprite() {
        sRenderer.sprite = currentCharacter.GetExprByStressLvl();
    }

    public void increaseStress() {
        float increaseAmount = currentCharacter.GetStressIncreaseAmount();

        currentCharacter.stressLevel += increaseAmount;
        if(currentCharacter.stressLevel > 1.0f) {
            Debug.Log("Character stresslevel MAXED!");
            currentCharacter.stressLevel = 1.0f;
        }

        //UPDATE EXTERNAL DEPENDENCIES
        progessBar.SetFillAmount(currentCharacter.stressLevel);
        UpdateCharExpressionSprite();
    }

    public void decreaseStress() {
        float decreaseAmount = currentCharacter.GetStressDecreaseAmount();
        currentCharacter.stressLevel -= decreaseAmount;
        if (currentCharacter.stressLevel < 0.0f) {
            Debug.Log("Character stresslevel ZERO!");
            currentCharacter.stressLevel = 0.0f;
        }

        //UPDATE EXTERNAL DEPENDENCIES
        progessBar.SetFillAmount(currentCharacter.stressLevel);
        UpdateCharExpressionSprite();
    }

}
