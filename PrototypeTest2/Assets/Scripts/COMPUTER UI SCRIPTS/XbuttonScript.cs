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

    [SerializeField]
    private bool _IsThisTutorial;

    [SerializeField]
    private GameObject _TutorialUI;

    private AudioSource _TurnOffSound;

    private void Start()
    {
        _TurnOffSound = this.GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    public void TurnOff()
    {
        if(_TurnOffSound!=null)
        _TurnOffSound.Play();
        this.gameObject.SetActive(false);
        if(_IsThisTutorial)
        _TutorialUI.SetActive(true);
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
