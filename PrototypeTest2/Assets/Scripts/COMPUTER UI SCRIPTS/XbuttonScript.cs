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

    //[SerializeField]
    //private GameObject _RedFolderGO;

    private AudioSource _TurnOffSound;

    private OnClickImageScript _CurrentFetchedScript;

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
        if(_CurrentFetchedScript!=null)
        _CurrentFetchedScript.OpenCloseFolder(false);
        
    }

    public void ChangeImage(Sprite _image)
    {
        this.gameObject.SetActive(true);
        _ImgToChange.sprite = _image;
        if (_CurrentFetchedScript != null)
            _CurrentFetchedScript.OpenCloseFolder(false);// false if you want to close the folder
    }

    public void ChangeText(string _text)
    {
        _TextToChange.text = _text;
    }

    public void CurrentPrefab(OnClickImageScript _Script)
    {
        if(_Script!=null)
        _CurrentFetchedScript = _Script;   
    }

}
