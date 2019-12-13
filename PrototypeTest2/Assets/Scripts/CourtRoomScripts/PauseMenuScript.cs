using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    private bool _menuIsOn = false;

    //This activates and deactivates the pause menu when pressing ESC. The menu has been reducded to just a restart button because it is obsolete.

    private void Start()
    {
        _menuIsOn = false;
        _menu.gameObject.SetActive(false);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_menuIsOn)
            {
                //_ui.gameObject.SetActive(false);
                _menuIsOn = true;
                _menu.gameObject.SetActive(true);
                //freeze controls
                //_player.gameObject.SetActive(false);
            }
            else
            {
                _menuIsOn = false;
                _menu.gameObject.SetActive(false);

            }
        }
    }
}
