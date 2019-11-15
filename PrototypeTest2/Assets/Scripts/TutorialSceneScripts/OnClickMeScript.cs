using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _mouseSciptObject;

   

    private MouseCheckScript _mouseScript;

    private void Start()
    {
        _mouseScript = _mouseSciptObject.GetComponent<MouseCheckScript>();
    }

    private void OnMouseDown()
    {
        if(_mouseScript.DONE)
         Debug.Log("NYA");
    }
}
