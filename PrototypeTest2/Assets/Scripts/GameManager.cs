﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
