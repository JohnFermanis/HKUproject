using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCanvasScript : MonoBehaviour
{
    [SerializeField]
    private Text _TextBox;
    private string _message;
    [SerializeField]
    private GameObject _secondCanvas;
    [SerializeField]
    private GameObject _mouseStuff;
    [SerializeField]
    private GameObject _DialogueCanvas;
    
    [SerializeField]
    private float _letterPause = 0.01f;

    void Start()
    {
        _DialogueCanvas.SetActive(false);
        _mouseStuff.SetActive(false);
        _secondCanvas.SetActive(false);
        _message = _TextBox.text;
        _TextBox.text = "";
        StartCoroutine(TypeText());
    }
    

    IEnumerator TypeText()
    {
        foreach (char letter in _message.ToCharArray())
        {

            _TextBox.text += letter;
            //if (sound)
            //    GetComponent<AudioSource>().PlayOneShot(sound);

            yield return new WaitForSeconds(_letterPause);
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) == true);

        _DialogueCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ActivateMouseAndSecondCanvas()
    {
        _secondCanvas.SetActive(true);
        _mouseStuff.SetActive(true);
    }
}