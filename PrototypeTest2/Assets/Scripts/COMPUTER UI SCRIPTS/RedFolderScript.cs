using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedFolderScript : MonoBehaviour, IPointerClickHandler
{
  

    [SerializeField]
    private Sprite _RedFolderSprite;

    [SerializeField]
    private Sprite _ErrorTextSprite;

    [SerializeField]
    private Image _Image;

    [SerializeField]
    private XbuttonScript _XScript;

    [SerializeField]
    private RedFolderCounterScript _CounterScript;

    [SerializeField]
    private AudioSource _OpenRedFolderSound;

    private bool _TurnOn=false;

    //private int _counter=0;

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenRedFolder();
    }

    
    public void OpenRedFolder()
    {
        if (!_TurnOn)
        {
            _TurnOn = true;
            _CounterScript.Plus1();

            _OpenRedFolderSound.Play();
        }
        
        _Image.sprite = _RedFolderSprite;
        
        _XScript.ChangeImage(_ErrorTextSprite);
        _XScript.ChangeText("");
    }

    private void Update()
    {
        if (!_TurnOn)
        {
            if (_CounterScript.counter >= _CounterScript.TurnAllRedAfter)
            {
                _TurnOn = true;
                _Image.sprite = _RedFolderSprite;
            }   
        }
    }
}
