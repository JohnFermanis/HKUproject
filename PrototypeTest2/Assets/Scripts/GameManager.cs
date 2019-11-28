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

    public void ChangeScene(int n)
    {
        SceneManager.LoadScene(n);
    }

   

}
