using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is attached to DailogueCanvas->DialogueBox->Dialogue
public class DialogueScript : MonoBehaviour
{
    [SerializeField]
    private Sprite _Face1;
    [SerializeField]
    private Sprite _Face2;

    [SerializeField]
    private string _Name1;

    [SerializeField]
    private string _Name2;

    [SerializeField]
    private GameObject _DialogueCanvas;

    [SerializeField]
    private float _letterPause=0.5f;

    [SerializeField]
    private FirstCanvasScript _FirstCanvas;

    [SerializeField]
    private Text _NameText;

    [SerializeField]
    private Image _FaceImage;

    private Text _thisText;

    private bool _TextRunning=false;

    private bool _TextFinished;

    private static int _NumberOfDialogues = 3;

    private string[] _Dialogue = new string[_NumberOfDialogues];

    private Sprite[] _Faces = new Sprite[_NumberOfDialogues];

    private string[] _Names = new string[_NumberOfDialogues];

    //The dialogue

    private string _D0 = "This is the dialogue1";
    private string _D1 = "This is the dialogue2";
    private string _D2 = "This is the dialogue3";
    //private string _D3 = "This is the dialogue4";
    //private string _D4 = "This is the dialogue5";
    //private string _D5 = "This is the dialogue6";
    //private string _D6 = "This is the dialogue7";
    //private string _D7 = "This is the dialogue8";
    //private string _D8 = "This is the dialogue9";
    //private string _D9 = "This is the dialogue10";

    //Corresponding Names for each dialogue
    
    void Start()
    {
        _thisText=this.GetComponent<Text>();

        if (_thisText == null)
            Debug.Log("ERROR");
        //_off.SetActive(false);

        _Dialogue[0] = _D0;
        _Dialogue[1] = _D1;
        _Dialogue[2] = _D2;
        //_Dialogue[3] = _D3;
        //_Dialogue[4] = _D4;
        //_Dialogue[5] = _D5;
        //_Dialogue[6] = _D6;
        //_Dialogue[7] = _D7;
        //_Dialogue[8] = _D8;
        //_Dialogue[9] = _D9;

        _Names[0] = _Name1;
        _Names[1] = _Name2;
        _Names[2] = _Name1;
        //_Names[3] = _Name1;
        //_Names[4] = _Name2;
        //_Names[5] = _Name1;

        _Faces[0] = _Face1;
        _Faces[1] = _Face2;
        _Faces[2] = _Face1;
        //_Faces[3] = _Face1;
        //_Faces[4] = _Face2;
        //_Faces[5] = _Face1;

    }

    void Update()
    {
        if (!_TextRunning)
        {
           
           // if (Input.GetKeyDown(KeyCode.Space))
           // {
                _TextRunning = true;
                StartCoroutine(TypeText());
                //move the conversation forward
           // }
        }
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < _NumberOfDialogues; i++)
        {
            _FaceImage.sprite = _Faces[i];
            _NameText.text = _Names[i];
            _thisText.text = "";
            foreach (char letter in _Dialogue[i].ToCharArray())
            {

                _thisText.text += letter;
                //if (sound)
                //    GetComponent<AudioSource>().PlayOneShot(sound);

                yield return new WaitForSeconds(_letterPause);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) == true);

        }
        _FirstCanvas.ActivateMouseAndSecondCanvas();
        _DialogueCanvas.SetActive(false); 
        //initiate the next cutscene here
    }


    
}
