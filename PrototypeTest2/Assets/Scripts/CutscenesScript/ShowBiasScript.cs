using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBiasScript : MonoBehaviour
{

    [SerializeField]
    private Text _text;

    private bool _update = false;

    private int _b1;
    private int _b2;
    private int _b3;
    private int _bAll;

    void OnEnable()
    {
        _b1 = PlayerPrefs.GetInt("BiasScore1");

        _b2 = PlayerPrefs.GetInt("BiasScore2");

        _b3 = PlayerPrefs.GetInt("BiasScore3");

        _bAll = _b1 + _b2 + _b3;
    }

    private void Update()
    {
        if (!_update)
        {

            _text.text = "Your final Bias is:  " + _bAll;
        }
    }
}
