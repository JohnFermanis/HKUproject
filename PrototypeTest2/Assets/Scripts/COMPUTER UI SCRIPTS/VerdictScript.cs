using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VerdictScript : MonoBehaviour
{
    private bool _acti = false;


    [SerializeField]
    private DropEvidenceScript _evid1;

    [SerializeField]
    private DropEvidenceScript _evid2;

    [SerializeField]
    private DropEvidenceScript _evid3;

    [SerializeField]
    private GameObject _ExplaImage;

    [SerializeField]
    private GameObject _Tutorial1;

    [SerializeField]
    private GameManager _manager;

    [SerializeField]
    private int ChangeSceneTo;

    [SerializeField]
    private int ComputerSceneNumber=1;
    //has to be 1,2 or 3

    private int _FinalBias;

    void Start()
    {
        
        this.gameObject.SetActive(false);
    }

    public void Activate()
    {
        if (!_acti)
        {
            _acti = true;
            _ExplaImage.SetActive(false);
            this.gameObject.SetActive(true);
            if(_Tutorial1!=null)
            _Tutorial1.SetActive(false);
        }
        else
        {
            TurnOff();
            _Tutorial1.SetActive(true);
        }
    }

    public void FinalDecision()
    {
        if (_evid1._Pass && _evid2._Pass && _evid3._Pass)
        {
            _FinalBias = _evid1.BiasToBeAdded + _evid2.BiasToBeAdded + _evid3.BiasToBeAdded;
            Debug.Log(_FinalBias);
            if(PlayerPrefs.GetInt("Version")==1 || ChangeSceneTo!=7)
                _manager.ChangeScene(ChangeSceneTo);
            else
                _manager.ChangeScene(ChangeSceneTo+5);

        }
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
        _acti = false;
    }

    void OnDisable()
    {
        switch (ComputerSceneNumber)
        {
            case 1:
                PlayerPrefs.SetInt("BiasScore1", _FinalBias);
                Debug.Log("Print1");
                break;
            case 2:
                PlayerPrefs.SetInt("BiasScore2", _FinalBias);
                Debug.Log("Print2");
                break;
            case 3:
                PlayerPrefs.SetInt("BiasScore3", _FinalBias);
                Debug.Log("Print3");
                break;
        }


        /*if(WhichComputerSceneIsThis==1)
            PlayerPrefs.SetInt("BiasScore1", _FinalBias);
        else if(WhichComputerSceneIsThis==2)
            PlayerPrefs.SetInt("BiasScore2", _FinalBias);
        else if (WhichComputerSceneIsThis == 3)
            PlayerPrefs.SetInt("BiasScore3", _FinalBias);*/
    }
}
