﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);

        }
        else if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(1);

        }
    }
}
