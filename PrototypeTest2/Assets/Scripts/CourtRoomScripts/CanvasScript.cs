using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    [SerializeField]
    private CharacterController _player;

    [SerializeField]
    private GameObject _ui;

    private bool _menuIsOn;
   
    void Start()
    {
        _menu.gameObject.SetActive(false);
    }


    
    
}
