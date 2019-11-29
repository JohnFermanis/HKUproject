using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdateScript : MonoBehaviour
{
    string Text ="Klik op het scherm om verder te gaan";

    [SerializeField]
    private Text _text;

    // Start is called before the first frame update
   

    public void ClearText()
    {
        _text.text = "";
    }

    public void UpdateText1()
    {
        _text.text = Text;
    }
}
