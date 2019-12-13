using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMeScript : MonoBehaviour
{
    //This script is currently disabled
    [SerializeField]
    private CharacterController _player;

    [SerializeField]
    private GameObject _ui;

    public void HideMe()
    {
        this.gameObject.SetActive(false);

        if(_player!=null)
        _player.gameObject.SetActive(true);

        if(_ui!=null)
        _ui.gameObject.SetActive(true);
            
    }

}
