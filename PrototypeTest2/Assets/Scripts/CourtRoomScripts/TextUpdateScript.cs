using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdateScript : MonoBehaviour
{
    string Text;

    [SerializeField]
    private Text _text;

    // Start is called before the first frame update
   

    public void ClearText()
    {
        Text=_text.text;
        _text.text = "";
    }

    public void UpdateText1()
    {
        _text.text = Text;
    }
}
