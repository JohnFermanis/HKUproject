using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickImageScript : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private string _evidenceText = "";

    [SerializeField]
    private bool _CorrectEvidence=false;

    [SerializeField]
    private Sprite _EvidenceImage;

    private GameObject _contentObj;

    private GameObject _canvasObj;

    private XbuttonScript _XbuttonScript;

    private Image _image;

    private Sprite _sprite;

    private Text _text;

    private Vector3 _pos;

    private bool dragging = false;

    private GameObject _bin;

    private BinScript _binScript;

    private GameObject _scrollObj;

    private DropEvidenceScript _foo1;

    private DropEvidenceScript _foo2;

    private DropEvidenceScript _foo3;

    private GameObject _TutorialUI;

    private VerdictScript _VerdictScript;

    [SerializeField]
    private bool _IsThisTutorial;

    private void Start()
    {
        _XbuttonScript=Resources.FindObjectsOfTypeAll<XbuttonScript>()[0];
        _VerdictScript = Resources.FindObjectsOfTypeAll<VerdictScript>()[0];
        _pos = transform.localPosition;
        //_canvasObj = GameObject.FindGameObjectWithTag("Canvas");
        if (_IsThisTutorial)
            _TutorialUI = GameObject.FindGameObjectWithTag("TUTORIAL");
        _contentObj = GameObject.FindGameObjectWithTag("CONTENT");
        _scrollObj = GameObject.FindGameObjectWithTag("SCROLL");
        _bin = GameObject.FindGameObjectWithTag("BIN");
        if (_bin != null)
        {
            _binScript = _bin.GetComponent<BinScript>();
        }
       /* if (_canvasObj != null)
        {
            _image = _imgObj.GetComponent<Image>();
            _text = _imgObj.GetComponentInChildren<Text>();
        }
        else
            Debug.Log("Error in Evidence Script");
            */
        DropEvidenceScript[] fooGroup = Resources.FindObjectsOfTypeAll<DropEvidenceScript>();
        if (fooGroup.Length > 0)
        {
             _foo1 = fooGroup[0];
             _foo2 = fooGroup[1];
             _foo3 = fooGroup[2];

        }
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!dragging)
        {
            //_image.gameObject.SetActive(true);
            //_image.sprite = _EvidenceImage;
            //_text.text = _evidenceText;
            
            _XbuttonScript.ChangeImage(_EvidenceImage);
            _XbuttonScript.ChangeText(_evidenceText);
            _VerdictScript.TurnOff();
            if (_IsThisTutorial)
                _TutorialUI.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        if (_scrollObj != null)
            transform.SetParent(_scrollObj.transform);

        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_foo1 != null)
        {
            _foo1.DropEvidence(this.gameObject,_CorrectEvidence);
        }

        if (_foo2 != null)
        {
            _foo2.DropEvidence(this.gameObject,_CorrectEvidence);
        }

        if (_foo3 != null)
        {
            _foo3.DropEvidence(this.gameObject, _CorrectEvidence);
        }

        _binScript.Destroyer(this.gameObject);

        if(_contentObj!=null)
        transform.SetParent(_contentObj.transform);

        transform.localPosition = _pos;
        dragging = false;
    }
}