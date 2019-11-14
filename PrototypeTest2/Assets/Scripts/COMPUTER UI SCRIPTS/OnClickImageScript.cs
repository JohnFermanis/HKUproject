using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickImageScript : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private string _evidenceText="";

    private GameObject _imageObj;

    private Image _image;

    private Sprite _sprite;

    private Text _text;

    private void Start()
    {
        _imageObj=GameObject.FindGameObjectWithTag("EXPLAIMAGE");

        if (_imageObj != null)
        {
            _image = _imageObj.GetComponent<Image>();
            _text = _imageObj.GetComponentInChildren<Text>();
        }
        else
            Debug.Log("Error in OnClickImageScripts");
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _image.gameObject.SetActive(true);
        _image.sprite= this.GetComponent<Image>().sprite;
        _text.text = _evidenceText;
    }

    public void TurnOff()
    {
        _image.gameObject.SetActive(false);
    }

    
}
