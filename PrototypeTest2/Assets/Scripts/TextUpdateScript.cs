using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdateScript : MonoBehaviour
{
    string Text ="Great Job, now open the PC";

    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = this.GetComponent<Text>(); 
    }

    public void UpdateText1()
    {
        _text.text = Text;
    }
}
