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
    public List<string>[] tempQuestionList = new List<string>[5];



    // [CATEGORY, ADVICE-TEXT]
    public string[,] advice = new string[,] { 
        
        {"Haben Sie keine Angst davor, mit der Zeit zu gehen", "Versuchen sie mit Enthusiasmus auf neue Herausforderungen zuzugehen", "Teilen Sie doch Ihre Gefühle mit anderen.","Integrieren Sie Ihr Umfeld in Ihre Unternehmungen!"},  //O
        {"Setzen sie klare Ziele", "Ein geregelter Tagesablauf könnte für mehr Sicherheit in ihrem Leben sorgen", "Sie können einen Fünfjahresplan aufstellen und ihr Problem in Einzelschritte zerlegen" ,"Schreiben Sie Tagebuch, um Ihren Tag besser planen zu können" },     //C
        {"Social Media kann ihnen helfen neue Kontakte zu knüpfen", "Gehen Sie mehr aus sich heraus und reden sie mit Leuten. ","Erweitern Sie ihr soziales Umfeld mit Gleichgesinnten ","Sie sollten einem Club oder Verein beitreten. " },     //E
        {"Gewähren sie anderen denselben Respekt den sie empfangen möchten.", "Sorgen Sie zuerst dafür dass es Ihnen gut geht, bevor Sie sich um andere kümmern.", "Gehen sie mehr auf Menschen ein.","Suchen Sie sich andere Leute, mit denen Sie in Wettbewerb treten können." },     //A
        {"Sie sollten sich eine Bezugsperson zulegen", "Arbeiten sie an ihrem Selbstbild, vielleicht müssen sie ihre Einstellung zu sich selbst ändern","Sie müssen Nähe zulassen","Tun Sie das, was Ihnen Spaß macht, und machen Sie es zu einer Gewohnheit" } };   //N
    public Button[] questionbuttons;
    public Button[] advicebuttons;

    private int adviceSetNumber = 0, adviceAmount = 4, question;


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


        //erzeuge 5 listen in einem array
        for (int i = 0; i < 5; i++)
        {
            tempQuestionList[i] = new List<string>();
            print(questions[i]);
            tempQuestionList[i].AddRange(questions[i]);

        }

        


        ShuffleAdvice();
        FillQuestionButtons();
        
    }

    public void GiveAdvice(int buttonIndex) {

        characterM.QuestionAsked(buttonIndex);
        ShuffleAdvice();

    }

    public void ShuffleAdvice()
    {

        List<string> tmpStringList = new List<string>();

        //go through
        adviceSetNumber = (++adviceSetNumber)%adviceAmount;

        for (int i = 0; i < 5; i++)
        {
            tmpStringList.Add(advice[i, adviceSetNumber]);
        }

        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, tmpStringList.Count);
            advicebuttons[i].GetComponentInChildren<Text>().text = tmpStringList[randomIndex];
            tmpStringList.RemoveAt(randomIndex);

        }
    }

    public void AskQuestion(int buttonIndex) {
       // FillQuestionButtons();
        characterM.QuestionAsked(buttonIndex);
        getNextQuestion(buttonIndex);
    }

    public void getNextQuestion(int i)
    {


        questionbuttons[i].GetComponentInChildren<Text>().text = tempQuestionList[i][0];
        if (tempQuestionList[i].Count > 0) tempQuestionList[i].Remove(tempQuestionList[i][0]);

    }
    /*
    public void getNextQuestion(int buttonIndex) {
        questionbuttons[buttonIndex].GetComponentInChildren<Text>().text = questions[buttonIndex][questionIndex];
    }

    // Update is called once per frame
    void Update() {
        
    }


    */

    private void FillQuestionButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            getNextQuestion(i);
        }
        questionIndex++;
    }
}
