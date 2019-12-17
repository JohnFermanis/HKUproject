using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    private int _Ver=0;

    [SerializeField]
    private int ChangeToScene=1;

    public void ButtonIsPressed1()
    {
        _Ver = 0;
        _gm.ChangeScene(ChangeToScene);
    }

    public void ButtonIsPressed2()
    {
        _Ver = 1;
        _gm.ChangeScene(ChangeToScene);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("BiasScore1", 0);
        PlayerPrefs.SetInt("BiasScore2", 0);
        PlayerPrefs.SetInt("BiasScore3", 0);

        PlayerPrefs.SetInt("Version", _Ver); //version 0 is the short version, 1 is the full version
    }
}
