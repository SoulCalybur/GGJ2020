using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameSessionManager : MonoBehaviour
{

    // EventManager
    public delegate void OnRoundEnd();
    public static event OnRoundEnd onRoundEnd;

    public CharacterManager characterM;

    public static void RaiseOnEnd() {
        if(onRoundEnd != null) {
            onRoundEnd();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
            /*
    GAME ABLAUF

    INIT GAMEPLAY
        LOAD CHARACTERDATA
        LOAD QUESTIONS INTO UI
        INIT COUNTDOWN
        
    UPDATE LOOP
        UPDATE COUNTDOWN

    CHOOSE QUESTION
        HIDE QUESTIONS
        GET REACTION FROM CHARACTER
            DISPLAY REACTION TEXT
            UPDATE STRESSLVL / PICTURE OF CHARACTER
                IF STRESSLVL TOO HIGH => 
                    CHARACTER LEAVES
                    LOAD NEW CHARACTER
        DISPLAY NEXT QUESTIONS
        
    */


}

    // Update is called once per frame
    /*
     
            UPDATE LOOP
        UPDATE COUNTDOWN

         */
    void Update()
    {
        
    }



}
