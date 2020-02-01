using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    public CharacterManager characterM;

    public void InitGameplay() {
        LoadCharacterData();
    }

    private void LoadCharacterData() {
        throw new NotImplementedException();
    }
}
