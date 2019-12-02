using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XbuttonScript : MonoBehaviour
{

    [SerializeField]
    Image _ImgToChange;

    [SerializeField]
    Text _TextToChange;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeImage(Sprite _image)
    {
        this.gameObject.SetActive(true);
        _ImgToChange.sprite = _image;
    }

    public void ChangeText(string _text)
    {
        _TextToChange.text = _text;
    }
}
