using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class FirstCanvasScript : MonoBehaviour
{
    //  Here is the flow of this scene:
    //                  1.Summary pops up and then closes
    //                  2.Mouse tutorial pops up and waits for the player to move the camera around (currently disabled, meaning that it instantly proceeds from step 2 to step 3)
    //                  3.Dialogue Starts
    //                  4.Dialogue finishes and waits for the player to open the in-game computer 

    [SerializeField]
    private FirstPersonController _Fp;
    [SerializeField]
    private GameObject _ControllerObj;
    [SerializeField]
    private GameObject _TutorialText;
    [SerializeField]
    private Text _TextBox;
    private string _message;
    [SerializeField]
    private GameObject _FirstCanvas;
    [SerializeField]
    private GameObject _secondCanvas;
    [SerializeField]
    private GameObject _mouseStuff;
    [SerializeField]
    private GameObject _DialogueCanvas;
    
    [SerializeField]
    private float _letterPause = 0.01f;

    [SerializeField]
    private bool _EnableSummary=true;

    void Start()
    {
       

        _Fp.mouseLookCustom.XSensitivity = 0.0f;
        _Fp.mouseLookCustom.YSensitivity = 0.0f;

       
        // _ControllerObj.GetComponent<Script>
        _TutorialText.SetActive(false);
        _DialogueCanvas.SetActive(false);
        _mouseStuff.SetActive(false);
        _secondCanvas.SetActive(false);
        _message = _TextBox.text;
        _TextBox.text = "";
        StartCoroutine(TypeText());

        if (!_EnableSummary)
        {
            ActivateMouseAndSecondCanvas();
            _FirstCanvas.SetActive(false);
        }
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
        _TutorialText.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) == true);
        //_Fp.mouseLookCustom.XSensitivity = 2.0f;
        //_Fp.mouseLookCustom.YSensitivity = 2.0f;
        ActivateMouseAndSecondCanvas();
        _FirstCanvas.SetActive(false);
    }

    public void ActivateMouseAndSecondCanvas()
    {
        _secondCanvas.SetActive(true);
        _mouseStuff.SetActive(true);
    }


}