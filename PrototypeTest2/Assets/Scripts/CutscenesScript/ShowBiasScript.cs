using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBiasScript : MonoBehaviour
{

    

    [SerializeField]
    private Sprite _Graph1;

    [SerializeField]
    private Sprite _Graph2;

    [SerializeField]
    private Sprite _Graph3;

    [SerializeField]
    private int _ThreshHold1=0;

    [SerializeField]
    private int _ThreshHold2=7;
    

    [SerializeField]
    private Text _text;

    [SerializeField]
    private Image _GraphImg;

    [SerializeField]
    private GameObject _GraphGO;

    private bool _GraphIsOn=false;

    private bool _update = false;

    private int _b1=0;
    private int _b2=0;
    private int _b3=0;
    private int _bAll=-100;

    void OnEnable()
    {
        _b1 = PlayerPrefs.GetInt("BiasScore1");
        Debug.Log(_b1+"b1");
        _b2 = PlayerPrefs.GetInt("BiasScore2");
        Debug.Log(_b2+"b2");
        _b3 = PlayerPrefs.GetInt("BiasScore3");
        Debug.Log(_b3+"b3");
        _bAll = _b1 + _b2 + _b3;

        //Here all the accumulated bias is added into one integer;

        Debug.Log(_bAll);
    }

    private void Start()
    {
        _GraphGO.SetActive(false);
    }

    private void Update()
    {
        if (!_update)
        {
           
            _update = true;
            _text.text = "Your final Bias is:  " + _bAll;

            if (_bAll >= _ThreshHold2)
            {
                _GraphImg.sprite = _Graph3;
            }
            else if (_bAll >= _ThreshHold1)
            {
                _GraphImg.sprite = _Graph2;
            }
            else
            {
                _GraphImg.sprite = _Graph1;
            }



        }
    }

    public void ShowHideGraph()
    {
        if (!_GraphIsOn) {
            _GraphIsOn = true;
            _GraphGO.SetActive(true);

        }
        else
        {
            _GraphIsOn = false;
            _GraphGO.SetActive(false);
        }
  

    }
}
