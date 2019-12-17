using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _mouseSciptObject;

    [SerializeField]
    private GameManager _gm;

    [SerializeField]
    private int ChangeSceneTo;

    [SerializeField]
    private bool _IsThisCourtRoom3=false;

    private int _b1 = 0;

    private int _b2 = 0;

    private int _Threshold1=5;

    private int _Threshold2 =10;

    private MouseCheckScript _mouseScript;

    private bool _DialogueDone=false;

    void OnEnable()
    {
        _b1 = PlayerPrefs.GetInt("BiasScore1");
     
        _b2 = PlayerPrefs.GetInt("BiasScore2");
        
    }

    private void Start()
    {
        _mouseScript = _mouseSciptObject.GetComponent<MouseCheckScript>();
    }

    private void OnMouseDown()
    {
        if (_mouseScript.DONE && !_IsThisCourtRoom3 && _DialogueDone)
            _gm.ChangeScene(ChangeSceneTo);
        else if (_mouseScript.DONE && _IsThisCourtRoom3 && _DialogueDone)
        {
            if (_b1 + _b2 >= _Threshold2)
                _gm.ChangeScene(ChangeSceneTo+2);
            else if (_b1 + _b2 >= _Threshold1)
                _gm.ChangeScene(ChangeSceneTo+1);
            else
                _gm.ChangeScene(ChangeSceneTo);
        }
    }

    public void DialogueIsOver()
    {
        _DialogueDone = true;
    }
}
