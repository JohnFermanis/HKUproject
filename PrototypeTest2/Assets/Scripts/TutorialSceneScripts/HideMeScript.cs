using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMeScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController _player;

    [SerializeField]
    private GameObject _ui;

    public void HideMe()
    {
        this.gameObject.SetActive(false);

        _player.gameObject.SetActive(true);

        _ui.gameObject.SetActive(true);
            
    }

}
