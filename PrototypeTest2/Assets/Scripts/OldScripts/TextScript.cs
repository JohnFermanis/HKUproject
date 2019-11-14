using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void addNumber(int count)
    {
        
        text.text = "";
        text.text = count.ToString() + "/4 gevonden";
    }


}
