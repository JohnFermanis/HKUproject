using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimScript : MonoBehaviour
{
    private bool visible = false;
    private string aim;
    // Start is called before the first frame update
    void Start()
    {
        aim=GetComponent<Text>().text;
        GetComponent<Text>().text=" ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h")&& visible==false)
        {
            visible = true;
            GetComponent<Text>().text = aim;
        }
        else if (Input.GetKeyDown("h") && visible == true)
        {
            visible = false;
            GetComponent<Text>().text = " ";
        }
      
    }
}
