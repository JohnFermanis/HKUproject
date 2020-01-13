using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    private int _Ver=0; //There 2 versions of the game, a short version and long version. The long version is also complete but it is currently disabled

    [SerializeField]
    private int ChangeToScene=1;

    [SerializeField]
    private int _CreditsScene=14;

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

    public void ButtonIsPressed3()
    {
       
        _gm.ChangeScene(_CreditsScene); //credit Scene
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("BiasScore1", 0);
        PlayerPrefs.SetInt("BiasScore2", 0);
        PlayerPrefs.SetInt("BiasScore3", 0);

        PlayerPrefs.SetInt("Version", _Ver); //version 0 is the short version, 1 is the full version
    }
}
