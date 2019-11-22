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
        }
        else
        {
            this.gameObject.SetActive(false);
            _acti = false;
        }
    }

    public void FinalDecision()
    {
        if (_evid1._Pass && _evid2._Pass)
            Debug.Log("SHOBOU AHRI");
    }
    
}
