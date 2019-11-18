using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VerdictScript : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }
    
}
