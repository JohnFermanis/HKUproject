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
    private GameObject _Tutorial1;

    [SerializeField]
    private GameManager _manager;


    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Activate()
    {
        if (!_acti)
        {
            _acti = true;
            this.gameObject.SetActive(true);
            if(_Tutorial1!=null)
            _Tutorial1.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
            _acti = false;
            _Tutorial1.SetActive(true);
        }
    }

    public void FinalDecision()
    {
        if (_evid1._Pass && _evid2._Pass && _evid3._Pass)
            _manager.ChangeScene(3);
    }
    
}
