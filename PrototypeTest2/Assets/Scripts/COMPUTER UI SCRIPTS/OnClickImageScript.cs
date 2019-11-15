using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickImageScript : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private string _evidenceText = "";

    private GameObject _contentObj;

    private GameObject _imageObj;

    private Image _image;

    private Sprite _sprite;

    private Text _text;

    private Vector3 _pos;

    private bool dragging = false;

    private GameObject _bin;

    private BinScript _binScript;

    private GameObject _canvasObj;

    

    private void Start()
    {
        _pos = transform.localPosition;
        _contentObj = GameObject.FindGameObjectWithTag("CONTENT");
        _canvasObj = GameObject.FindGameObjectWithTag("SCROLL");
        _imageObj = GameObject.FindGameObjectWithTag("EXPLAIMAGE");
        _bin = GameObject.FindGameObjectWithTag("BIN");
        if (_bin != null)
        {
            _binScript = _bin.GetComponent<BinScript>();
        }
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
        if (!dragging)
        {
            _image.gameObject.SetActive(true);
            _image.sprite = this.GetComponent<Image>().sprite;
            _text.text = _evidenceText;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        if (_canvasObj != null)
            transform.SetParent(_canvasObj.transform);

        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _binScript.Destroyer(this.gameObject);

        if(_contentObj!=null)
        transform.SetParent(_contentObj.transform);

        transform.localPosition = _pos;
        dragging = false;
    }
}