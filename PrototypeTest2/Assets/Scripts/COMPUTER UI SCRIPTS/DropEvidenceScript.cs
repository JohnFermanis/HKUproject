using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropEvidenceScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    

    bool _pointer = false;


    // Start is called before the first frame update
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointer = true;
        Debug.Log("WOOOO");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointer = false;
    }

    public void DropEvidence(GameObject go)
    {
        if (_pointer)
        {
            Debug.Log("EMILIAAA");
            this.GetComponent<Image>().sprite = go.GetComponent<Image>().sprite;
        }
    }
}
