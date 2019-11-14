using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandPanelScript : MonoBehaviour
{
    private float _width;
    private RectTransform _Rect;
    private void Start()
    {
        _Rect=GetComponent<RectTransform>();
        _width = _Rect.rect.width;
    }

    public void ExpandPanelF()
    {
        if(_Rect.rect.width < 300)
            _Rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10.0f, 600.0f);
        else
            _Rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10.0f, _width);
    }

  
}
