using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void StartScene0()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSceneA()
    {

        SceneManager.LoadScene(1);

    }

    public void ChangeSceneB()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeSceneC()
    {
        SceneManager.LoadScene(3);
    }

    public void ChangeSceneD()
    {
        SceneManager.LoadScene(4);
    }

}
