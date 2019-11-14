using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButtonsScript : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateButtons()
    {
        gameObject.SetActive(true);
    }
}
