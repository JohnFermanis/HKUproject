using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    [SerializeField]
    private int ChangeToScene=1;

    public void ButtonIsPressed()
    {
        _gm.ChangeScene(ChangeToScene);
    }
}
