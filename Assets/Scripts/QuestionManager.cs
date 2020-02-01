using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour {
    // [CATEGORY, QUESTION-TEXT]
    public string[,] questions = new string[,] { { "test a", "test a2" }, { "test b", "test b2"}, { "test c","test c2" }, { "test d", "test d2" }, { "test e", "test e2" } };
    // [CATEGORY, ADVICE-TEXT]
    public string[,] advice = new string[,] { { "advice 1" }, { "advice 2" }, { "advice 3" }, { "advice 4" }, { "advice 5" } };
    public Button[] questionbuttons;
    public Button[] advicebuttons;

    // Start is called before the first frame update
    void Start()
    {

        ShuffleAdvice();
        for (int i = 0; i < 5; i++)
        {

            //getNextQuestion(i);
        }
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

    public void AskQuestion(int i) {
        //Debug.Log(questionbuttons[i].GetComponentInChildren<Text>().text);
        getNextQuestion(i);
    }

    public void getNextQuestion(int i) {


        questionbuttons[i].GetComponentInChildren<Text>().text = questions[i, 0];

    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
