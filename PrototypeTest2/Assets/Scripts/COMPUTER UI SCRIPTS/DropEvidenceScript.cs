﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropEvidenceScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool _Pass=false;
    bool _pointer = false;
    public int BiasToBeAdded;

    [SerializeField]
    private AudioSource _DropSound;

   

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointer = true;
  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointer = false;
    }

    public void DropEvidence(GameObject go,bool CorrectEvidence,int Bias)
    {
        if (_pointer)
        {
            _Pass = CorrectEvidence;
            this.GetComponent<Image>().sprite = go.GetComponent<Image>().sprite;
            BiasToBeAdded = Bias;
            _DropSound.Play();
        }
    }
}
