using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Restart the game
    public void StartScene0()
    {
        SceneManager.LoadScene(0);
    }

    //Load a given scene
    public void ChangeScene(int n)
    {
        SceneManager.LoadScene(n);
    }

   

}
