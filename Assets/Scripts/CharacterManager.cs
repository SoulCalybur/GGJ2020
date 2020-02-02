using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{   
    public List<CharacterData> characters;

    public QuestionManager qstnMngr;

    public GameObject CharacterSceneObj;
    public ProgressBar progessBar;
    public Text characterText;
    public Text wonAmountTxt;
    public Text lostAmountTxt;


    private SpriteRenderer sRenderer;


    //Winning/Losing

    private int clientsWon;
    private int clientsLost;


    // CURRENTLY loaded
    CharacterData currentCharacter;
    int charIndex = 0;

    void Start() {
        sRenderer = CharacterSceneObj.GetComponent<SpriteRenderer>();
        currentCharacter = characters[charIndex];
        currentCharacter.stressLevel = 0.5f;
        UpdateCharExpressionSprite();
        progessBar.SetFillAmount(currentCharacter.stressLevel);
        characterText.text = currentCharacter.charName + "\n" + currentCharacter.introText;
        charIndex++;
        clientsWon = 0;
        clientsLost = 0;
        qstnMngr.EventMessage("Willkommen!");


    }

    void loadNextCharacter() {
        if (charIndex >= characters.Count) {
            Debug.Log("Last character reached. End the Round");
            //GameSessionManager.RaiseOnEnd();
          //  return;
        }
        currentCharacter = characters[charIndex];
        currentCharacter.stressLevel = 0.5f;
        characterText.text = currentCharacter.charName + "\n" + currentCharacter.introText;
        UpdateCharExpressionSprite();
        progessBar.SetFillAmount(currentCharacter.stressLevel);
        charIndex++;
        charIndex =  (charIndex) % characters.Count;
        Debug.Log("CharIndex = " + charIndex);

        qstnMngr.OnNewClientEnter();




    }

    // Update is called once per frame
    void Update() {
        setWinText();
    }


    void UpdateCharExpressionSprite() {
        sRenderer.sprite = currentCharacter.GetExprByStressLvl();
    }

    private void EndRound() {

    }

    public void AdviceGiven(int oceanType)
    {
        SwitchReaction(oceanType);

        float amount = currentCharacter.GetStressAmountByCategory(oceanType);
        currentCharacter.stressLevel += amount;
        if (currentCharacter.stressLevel < 0.0f)
        {
            Debug.Log("Character stressLevel ZERO!");
            currentCharacter.stressLevel = 0.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
            qstnMngr.EventMessage("Patient austherapiert.");
            clientsWon++;
            loadNextCharacter();
        }
        else if (currentCharacter.stressLevel > 1.0f)
        {
            Debug.Log("Character stressLevel MAXED!");
            currentCharacter.stressLevel = 1.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
            qstnMngr.EventMessage("Patient verloren.");
            clientsLost++;
            loadNextCharacter();
        }
        else
        {
            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
        }

    }

    public void setWinText()
    {
        wonAmountTxt.text = "Patienten austherapiert: " + clientsWon;
        lostAmountTxt.text = "Patienten suizidal: " + clientsLost;
    }

    public void SwitchAnswers(int oceanType)
    {
        characterText.text = currentCharacter .charName + "\n";
        switch (oceanType)
        {
            case 0:
                characterText.text += currentCharacter.answers_category_O[0] ?? "...";
                break;
            case 1:
                characterText.text += currentCharacter.answers_category_C[0] ?? "..."; break;
            case 2:
                characterText.text += currentCharacter.answers_category_E[0] ?? "..."; break;
            case 3:
                characterText.text += currentCharacter.answers_category_A[0] ?? "..."; break;
            case 4:
                characterText.text += currentCharacter.answers_category_N[0] ?? "..."; break;
            default: characterText.text += "..."; break;

        }

    }


    public void SwitchReaction(int oceanType)
    {
        characterText.text = currentCharacter.charName + "\n";

        switch (oceanType)
        {
            case 0:
                characterText.text += currentCharacter.reactions_category_O[0] ?? "...";break;
            case 1:
                characterText.text += currentCharacter.reactions_category_C[0] ?? "..."; break;
            case 2:
                characterText.text += currentCharacter.reactions_category_E[0] ?? "..."; break;
            case 3:
                characterText.text += currentCharacter.reactions_category_A[0] ?? "..."; break;
            case 4:
                characterText.text += currentCharacter.reactions_category_N[0] ?? "..."; break;
            default: characterText.text += "..."; break;

        }

    }

    public void QuestionAsked(int buttonIndex) {

        SwitchAnswers(buttonIndex);

        float amount = currentCharacter.GetStressAmountByCategory(buttonIndex);
        currentCharacter.stressLevel += amount;
        if (currentCharacter.stressLevel < 0.0f) {
            Debug.Log("Character stressLevel ZERO!");
            currentCharacter.stressLevel = 0.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
            qstnMngr.EventMessage("Patient austherapiert.");
            clientsWon++;
            loadNextCharacter();

        } else if (currentCharacter.stressLevel > 1.0f) {
            Debug.Log("Character stressLevel MAXED!");
            currentCharacter.stressLevel = 1.0f;

            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
            qstnMngr.EventMessage("Patient verloren.");
            clientsLost++;
            loadNextCharacter();
        } else {
            progessBar.SetFillAmount(currentCharacter.stressLevel);
            UpdateCharExpressionSprite();
        }
    }

}
