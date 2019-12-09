using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BinScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool _mouseHere=false;

    private AudioSource _BinSound;

    private void Start()
    {
        _BinSound = this.GetComponent<AudioSource>();
    }

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
        _BinSound.Play();
    }

   
}
