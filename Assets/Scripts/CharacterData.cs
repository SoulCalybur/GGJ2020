using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterData", menuName = "Character")]
public class CharacterData : ScriptableObject {

    public string charName;
    public string introText;

    [Range(0,1)]
    public float stressLevel = 0.0f;
    public List<Sprite> expressionSprites;

    [Header("Stress Amount per Category")]
    public float stressAmount_O = 0.1f;
    public float stressAmount_C = 0.1f;
    public float stressAmount_E = 0.1f;
    public float stressAmount_A = 0.1f;
    public float stressAmount_N = 0.1f;


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

    public float GetStressAmountByCategory(int i) {
        switch (i) {
            case 0: return stressAmount_O;
            case 1: return stressAmount_C;
            case 2: return stressAmount_E;
            case 3: return stressAmount_A;
            case 4: return stressAmount_N;
            default:
                Debug.LogError("Wrong index for getting AnswerCategory");
                return 0.9f;
        }
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


}
