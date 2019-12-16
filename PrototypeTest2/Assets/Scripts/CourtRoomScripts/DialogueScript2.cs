using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is attached to DailogueCanvas->DialogueBox->Dialogue
public class DialogueScript2 : MonoBehaviour
{
    [SerializeField]
    private Sprite _Face1;
    [SerializeField]
    private Sprite _Face2;

    [SerializeField]
    private string _Name1="";

    [SerializeField]
    private string _Name2="";

    [SerializeField]
    private GameObject _DialogueCanvas;

    [SerializeField]
    private float _letterPause = 0.5f;

    [SerializeField]
    private bool _InstantText=true;

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

    //================================================================
    //CHANGE THIS IF YOU WANT TO CHANGE THE NUMBER OF DIALOGUES
    private static int _NumberOfDialogues = 10;
    //================================================================

    private string[] _Dialogue = new string[_NumberOfDialogues];

    private Sprite[] _Faces = new Sprite[_NumberOfDialogues];

    private string[] _Names = new string[_NumberOfDialogues];

    //The dialogue

    private string _D0 = "Rechter, op 20 april 2038 ben ik ontslagen door Quick Sales. Dit is echter niet gegaan om een acceptabele reden. Quick Sales geeft aan dat ik personen aanbiedingen heb gedaan die niet besluitvaardig zijn.";
    private string _D1 = "Ik heb echter de personen die de AI mij aanbeval te contacteren gecontacteerd. Ik heb echter de personen gecontacteerd die de AI mij heeft aanbevolen, deze AI is blijkbaar niet goed ingesteld.";
    private string _D2 = "Ik ben er vanuit gegaan dat de door Quick Sales aangeboden AI te vertrouwen is.";
    private string _D3 = "Bij nader onderzoeken blijkt echter dat de AI een algoritme gebruikt wat personen aandraagt gebaseerd op hun gedrag en of de kans van het accepteren van een aanbieding groot is.";
    private string _D4 = "De fout ligt dus niet bij mij, maar bij quick sales, die mij een AI heeft gefaciliteerd die de problemen creëert.";
    private string _D5 = "Rechter, M. Jansen heeft onjuist gehandeld. Ze heeft contracten aangeboden aan personen die dronken en wilsonbekwaam zijn op moment van besluit.";
    private string _D6 = "Dit is zo veelvuldig gebeurt dat het Quick Sales in de rechtelijke problemen is gekomen. Dit heeft Quick Sales veel tijd en geld gekost.";
    private string _D7 = "Wij zijn een intern onderzoek gestart naar hoe dit heeft kunnen gebeuren. Hieruit is naar voren gekomen dat mevrouw Jansen vaak aan de personen heeft verkocht waarbij dit niet had mogen gebeuren.";
    private string _D8 = "Op grond daarvan hebben wij haar arbeidscontract ontbonden.";
    private string _D9 = "Het gebruikte algoritme draagt alleen mensen aan als potentiële klanten, maar het is aan de verkoper zelf om de persoon te beoordelen. Dit is bij mevrouw Jansen duidelijk nooit goed gebeurt.";

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
        _Names[4] = _Name1;
        _Names[5] = _Name2;
        _Names[6] = _Name2;
        _Names[7] = _Name2;
        _Names[8] = _Name2;
        _Names[9] = _Name2;

        _Faces[0] = _Face1;
        _Faces[1] = _Face1;
        _Faces[2] = _Face1;
        _Faces[3] = _Face1;
        _Faces[4] = _Face1;
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
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) == true);
            if (_TutorialText != null)
                _TutorialText.SetActive(false);
        }
        _FirstCanvas.ActivateMouseAndSecondCanvas();
        _DialogueCanvas.SetActive(false);
        //initiate the next cutscene here
    }



}
