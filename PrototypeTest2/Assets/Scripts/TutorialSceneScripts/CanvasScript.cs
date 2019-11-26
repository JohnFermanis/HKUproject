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
   
    void Start()
    {
        _menu.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _ui.gameObject.SetActive(false);

            _menu.gameObject.SetActive(true);
            //freeze controls
            _player.gameObject.SetActive(false);
        }
    }
}
