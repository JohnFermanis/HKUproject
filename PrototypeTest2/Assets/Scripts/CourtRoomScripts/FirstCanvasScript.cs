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
    private AudioSource _AudioS;
    [SerializeField]
    private GameObject _PopUpPanel;

    private bool _ButtonPressed=false;

    [SerializeField]
    private bool _enablePopUp=false;
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
    private bool _InstantText = true;

    [SerializeField]
    private bool _EnableSummary=true; //This exists for debugging purposes, should be true

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
        if(!_enablePopUp)
        StartCoroutine(TypeText());

        if (!_EnableSummary)
        {
            ActivateMouseAndSecondCanvas();
            _FirstCanvas.SetActive(false);
        }
    }
    

    IEnumerator TypeText()
    {
        if(_AudioS!=null)
         _AudioS.Play();
        if (_InstantText == false)
        {
            foreach (char letter in _message.ToCharArray())
            {

                _TextBox.text += letter;
                //if (sound)
                //    GetComponent<AudioSource>().PlayOneShot(sound);

                yield return new WaitForSeconds(_letterPause);
            }
        }
        else
        {
            _TextBox.text = _message;
            yield return new WaitForSeconds(0.1f);
        }
        _TutorialText.SetActive(true);
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) == true);
        yield return new WaitUntil(() => _ButtonPressed == true);
        _AudioS.Stop();
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

    // To be called by the pop up buttons
    public void ActivateCoRoutine()
    {
        if (_PopUpPanel != null)
        {
            _PopUpPanel.SetActive(false);

        }
        StartCoroutine(TypeText());
    }

    public void ButtonWasPressed()
    {
        _ButtonPressed = true;
    }


}