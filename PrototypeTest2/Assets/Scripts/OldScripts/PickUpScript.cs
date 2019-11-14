using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private Light _Light;

    private bool _myVar;
    // Start is called before the first frame update
    void Start()
    {
        _Light =GetComponentInChildren<Light>();
    }

    private void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        _myVar = true;
        _Light.intensity = 400.0f;
    }

    private void OnMouseExit()
    {
        _myVar = false;
        _Light.intensity = 0.0f;
    }



    
}
