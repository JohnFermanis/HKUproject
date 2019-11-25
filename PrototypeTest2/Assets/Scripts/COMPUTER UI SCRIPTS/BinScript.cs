﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BinScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool _mouseHere=false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseHere = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseHere = false;
    }

    public void Destroyer(GameObject go)
    {
        if(_mouseHere)
        Destroy(go);
        
    }

   
}
