using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    public List<CharacterData> characters;

    // CURRENTLY loaded
    CharacterData currentCharacter;
    int charIndex = 0;

    void Start() {
        sRenderer = GetComponent<SpriteRenderer>();
        currentCharacter = characters[0];
        charIndex++;
        sRenderer.sprite = currentCharacter.expressionSprites[0];
    }

    void loadNextCharacter() {
        charIndex++;
        currentCharacter = characters[charIndex % characters.Count];
        sRenderer.sprite = currentCharacter.GetExprByStressLvl();
    }

    // Update is called once per frame
    void Update() {
        sRenderer.sprite = currentCharacter.GetExprByStressLvl();
    }
}
