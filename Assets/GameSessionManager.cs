using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameSessionManager : MonoBehaviour
{
    public CharacterManager characterM;

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
            UPDATE STRESSLVL OF CHARACTER
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
