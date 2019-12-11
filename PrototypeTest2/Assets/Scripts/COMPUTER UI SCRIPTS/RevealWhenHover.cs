using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RevealWhenHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField]
    private GameObject _go;

    [SerializeField]
    private bool _IsThisTutorial;

    private void Start()
    {
        if (_go!=null)
        {
            if (!_IsThisTutorial)
                _go.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_go != null)
        {
            if (!_IsThisTutorial)
                _go.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_go != null)
        {
            if (!_IsThisTutorial)
                _go.SetActive(false);
        }
    }
}
