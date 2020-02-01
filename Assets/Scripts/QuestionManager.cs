using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour {

    [Header("Linking")]
    public CharacterManager characterM;

    [Header("Questions")]
    public int questionIndex = 0;
    // [CATEGORY, QUESTION-TEXT]
    public string[][] questions;
    // [CATEGORY, ADVICE-TEXT]
    public string[,] advice = new string[,] { { "advice 1" }, { "advice 2" }, { "advice 3" }, { "advice 4" }, { "advice 5" } };
    public Button[] questionbuttons;
    public Button[] advicebuttons;

    

    void Start() {
        InitContent();
    }

    private void InitContent() {

        questions = new string[5][];

        //KATEGORIE O
        questions[0] = new string[3];
        questions[0][0] = "Legen Sie Wert auf Traditionen?";
        questions[0][1] = "Probieren Sie gerne Dinge aus?";

        //KATEGORIE C
        questions[1] = new string[2];
        questions[1][0] = "Würden Sie sich als ordentliche Person bezeichnen?";
        questions[1][1] = "Planen Sie viel voraus?";

        //KATEGORIE E
        questions[2] = new string[3];
        questions[2][0] = "Sind Sie gerne unter Leuten?";
        questions[2][1] = "Verbringen Sie gerne Zeit alleine?";
        questions[2][2] = "Ich bin Frage C von E?";

        //KATEGORIE A
        questions[3] = new string[4];
        questions[3][0] = "Sind Sie Teil einer Gruppe oder eines Teams?";
        questions[3][1] = "Würden Sie sagen, Sie haben Feinde?";

        //KATEGORIE N
        questions[4] = new string[4];
        questions[4][0] = "Wie haben Sie sich letzte Woche gefühlt?";
        questions[4][1] = "Streiten Sie sich häufig?";


        ShuffleAdvice();
        FillQuestionButtons();
        
    }

    public void GiveAdvice(int i) {

        ShuffleAdvice();

    }

    public void ShuffleAdvice()
    {

        List<string> tmpStringList = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            tmpStringList.Add(advice[i,0]);
        }

        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, tmpStringList.Count);
            advicebuttons[i].GetComponentInChildren<Text>().text = tmpStringList[randomIndex];
            tmpStringList.RemoveAt(randomIndex);

        }
    }

    public void AskQuestion(int buttonIndex) {
        FillQuestionButtons();
        characterM.QuestionAsked(buttonIndex);
    }

    public void getNextQuestion(int buttonIndex) {
        questionbuttons[buttonIndex].GetComponentInChildren<Text>().text = questions[buttonIndex][questionIndex];
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void FillQuestionButtons() {
        for (int i = 0; i < 5; i++) {
            getNextQuestion(i);
        }
        questionIndex++;
    }

}
