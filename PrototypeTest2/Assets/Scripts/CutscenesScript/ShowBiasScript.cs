using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBiasScript : MonoBehaviour
{

    [SerializeField]
    private Text _text;

    private bool _update = false;

    private int _b1=0;
    private int _b2=0;
    private int _b3=0;
    private int _bAll=-1;

    void OnEnable()
    {
        _b1 = PlayerPrefs.GetInt("BiasScore1");
        Debug.Log(_b1+"b1");
        _b2 = PlayerPrefs.GetInt("BiasScore2");
        Debug.Log(_b2+"b2");
        _b3 = PlayerPrefs.GetInt("BiasScore3");
        Debug.Log(_b3+"b3");
        _bAll = _b1 + _b2 + _b3;

        Debug.Log(_bAll);
    }

    private void Update()
    {
        if (!_update)
        {
           
                _update = true;
                _text.text = "Your final Bias is:  " + _bAll;
            
        }
    }
}
