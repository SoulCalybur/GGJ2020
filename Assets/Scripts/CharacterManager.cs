using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    public List<CharacterData> characters;

    CharacterData currentCharacter;
    // Start is called before the first frame update
    void Start() {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = characters[0].expressionSprites[0];
    }

    // Update is called once per frame
    void Update() {
        sRenderer.sprite = characters[0].GetExprByStressLvl(characters[0].stressLevel);

    }
}
