using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterData", menuName = "Character")]
public class CharacterData : ScriptableObject {

    [Range(0,1)]
    public float stressLevel = 0.3f;
    public List<Sprite> expressionSprites;

    public float stressLvlInscrease = 0.2f;
    public float stressLvlDecrease = 0.1f;

    public List<string> answers_category_O;
    public List<string> answers_category_C;
    public List<string> answers_category_E;
    public List<string> answers_category_A;
    public List<string> answers_category_N;

    public List<string> reactions_category_O;
    public List<string> reactions_category_C;
    public List<string> reactions_category_E;
    public List<string> reactions_category_A;
    public List<string> reactions_category_N;

    public Sprite GetExprByStressLvl() {
        Debug.Assert((stressLevel >= 0 && stressLevel <= 1), "StressLevel not in Range(0,1)");
        Debug.Assert((expressionSprites.Count != 0), "No Sprites set in CharacterData!");
        float range = (expressionSprites.Count - 1) * stressLevel;
        int i = (int)Math.Floor(range);
        return expressionSprites[i];
    }

    public List<string> GetAnswersByCategory(int i) {
        switch (i) {
            case 0: return answers_category_O;
            case 1: return answers_category_C;
            case 2: return answers_category_E;
            case 3: return answers_category_A;
            case 4: return answers_category_N;
            default:
                Debug.LogError("Wrong index for getting AnswerCategory");
                return null;
        }
    }
    public List<string> GetReactionsByCategory(int i) {
        switch (i) {
            case 0: return reactions_category_O;
            case 1: return reactions_category_C;
            case 2: return reactions_category_E;
            case 3: return reactions_category_A;
            case 4: return reactions_category_N;
            default:
                Debug.LogError("Wrong index for getting ReactionCategory");
                return null;
        }
    }

    public float GetStressIncreaseAmount() {
        return stressLvlInscrease;
    }
    public float GetStressDecreaseAmount() {
        return stressLvlDecrease;
    }

}
