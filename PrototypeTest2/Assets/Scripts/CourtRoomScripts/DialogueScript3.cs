using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is attached to DailogueCanvas->DialogueBox->Dialogue
public class DialogueScript3 : MonoBehaviour
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
    private OnClickMeScript _EndScript;

    [SerializeField]
    private float _letterPause = 0.5f;

    [SerializeField]
    private bool _InstantText = false;

    [SerializeField]
    private float _ButtonDelay=1.1f;

    [SerializeField]
    private FirstCanvasScript _FirstCanvas;

    [SerializeField]
    private GameObject _TutorialText;

    [SerializeField]
    private Text _NameText;

    [SerializeField]
    private Image _FaceImage;

    private Text _thisText;

    private bool _TextRunning = false;

    private bool _TextFinished;


    private bool _ButtonPressed = false;

    //================================================================
    //CHANGE THIS IF YOU WANT TO CHANGE THE NUMBER OF DIALOGUES

    private static int _NumberOfDialogues = 10;
    //================================================================

    [SerializeField]
    private AudioSource _AudioS;

    [SerializeField]
    private AudioClip[] _AudioD = new AudioClip[_NumberOfDialogues];

    private string[] _Dialogue = new string[_NumberOfDialogues];

    private Sprite[] _Faces = new Sprite[_NumberOfDialogues];

    private string[] _Names = new string[_NumberOfDialogues];

    //The dialogue

    private string _D0 = "Wij hebben een slecht werkende AI ontvangen van Semain Technologies.";
    private string _D1 = "We hebben de hele bedrijfsstructuur omgegooid om onze volledige klantenservice afdeling door een AI over te laten nemen, maar binnen drie dagen heeft deze aanschaf ons heel veel ellende bezorgd!";
    private string _D2 = "Klanten werden uitgescholden, geïntimideerd, bedreigd… Het was niet normaal. Je zou verwachten dat er bepaalde filters zijn waardoor een AI geen ongewenst gedrag vertoont."; 
    private string _D3 = "We willen een vergoeding voor de schade als gevolg van het verlies aan klanten door toedoen van deze AI zijn kwijtgeraakt en daarbij willen we ook een nieuwe AI ontvangen die wél zijn werk doet."; //end first party
    private string _D4 = "Onze AI’s worden schoon afgeleverd. Dit betekent dat ze een leeg canvas zijn die wordt ontwikkeld door te leren van de interacties met de mensen op wie de AI wordt toegepast.";
    private string _D5 = "Een klantenservice lijkt niet altijd de meest tevreden mensen aan te trekken en het is te verwachten dat de AI gevoed wordt met negatieve informatie en opmerkingen.";
    private string _D6 = "Daarom raden wij aan om de AI een week op te leiden voordat deze op een positie als dit wordt inzet. ";
    private string _D7 = "Zo kan de AI namelijk context vinden om te snappen dat bepaald gedrag ongewenst is. Net als een echt mens. ";
    private string _D8 = "Om deze reden vinden wij dat we niet verantwoordelijk zijn voor de geleden schade van Dipak.com.";
    private string _D9 = "Dipak.com heeft er zelf voor gekozen om de AI te laten leren van boze klanten en duidelijk niet naar de gebruiksaanwijzing gekeken."; // end second party

    //Corresponding Names for each dialogue

    void Start()
    {
        _thisText = this.GetComponent<Text>();

        if (_thisText == null)
            Debug.Log("ERROR");
        //_off.SetActive(false);

        _Dialogue[0] = _D0;
        _Dialogue[1] = _D1;
        _Dialogue[2] = _D2;
        _Dialogue[3] = _D3;
        _Dialogue[4] = _D4;
        _Dialogue[5] = _D5;
        _Dialogue[6] = _D6;
        _Dialogue[7] = _D7;
        _Dialogue[8] = _D8;
        _Dialogue[9] = _D9;

        _Names[0] = _Name1;
        _Names[1] = _Name1;
        _Names[2] = _Name1;
        _Names[3] = _Name1;
        _Names[4] = _Name2;
        _Names[5] = _Name2;
        _Names[6] = _Name2;
        _Names[7] = _Name2;
        _Names[8] = _Name2;
        _Names[9] = _Name2;

        _Faces[0] = _Face1;
        _Faces[1] = _Face1;
        _Faces[2] = _Face1;
        _Faces[3] = _Face1;
        _Faces[4] = _Face2;
        _Faces[5] = _Face2;
        _Faces[6] = _Face2;
        _Faces[7] = _Face2;
        _Faces[8] = _Face2;
        _Faces[9] = _Face2;

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

            if (_AudioS != null)
            {
                if (i != 0)
                {
                    _AudioS.Stop();
                }
                if (_AudioD[i] != null)
                {
                    _AudioS.clip = _AudioD[i];
                    _AudioS.Play();
                }
            }


            _FaceImage.sprite = _Faces[i];
            _NameText.text = _Names[i];
            _thisText.text = "";
            if (_InstantText == false)
            {
                foreach (char letter in _Dialogue[i].ToCharArray())
                {

                    _thisText.text += letter;
                    //if (sound)
                    //    GetComponent<AudioSource>().PlayOneShot(sound);

                    yield return new WaitForSeconds(_letterPause);
                }

            }
            else
            {
                _thisText.text = _Dialogue[i];
                
                yield return new WaitForSeconds(_ButtonDelay);
            }
            _ButtonPressed = false;
            yield return new WaitUntil(() => _ButtonPressed == true);
            _ButtonPressed = false;
            if (_TutorialText != null)
                _TutorialText.SetActive(false);
        }
        _FirstCanvas.ActivateMouseAndSecondCanvas();
        _EndScript.DialogueIsOver();
        _DialogueCanvas.SetActive(false);
        //initiate the next cutscene here
    }

    public void ButtonWasPressed()
    {
        _ButtonPressed = true;
    }

}
