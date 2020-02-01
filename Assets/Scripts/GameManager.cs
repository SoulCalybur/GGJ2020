using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //load main menu
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }


    public static void LoadLevel(int n)
    {
        //ping pong between level and main menu
        if (n == 2)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(1, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
        /*else if (n == 1)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("JeremyScene");
        }*/

        //if(!SceneManager.GetSceneAt(n).isLoaded) 
    }


    public static void UnLoad(int n)
    {
        
    }



}
