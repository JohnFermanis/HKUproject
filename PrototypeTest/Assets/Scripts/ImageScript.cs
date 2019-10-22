using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);  
    }


    public void ActivateImage()
    {
        this.gameObject.SetActive(true);
    }
}
