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
    private OnClickMeScript _EndScript;

    [SerializeField]
    private FirstCanvasScript _FirstCanvas;

    [SerializeField]
    private GameObject _TutorialText;

    [SerializeField]
    private Text _NameText;

    [SerializeField]
    private Image _FaceImage;


    [SerializeField]
    private float _letterPause = 0.5f;

    [SerializeField]
    private bool _InstantText=true;

    [SerializeField]
    private float _ButtonDelay=1.1f;

    private Text _thisText;

    private bool _TextRunning=false;

    private bool _TextFinished;

    private bool _ButtonPressed=false;

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

    private string _D0 = "Rechter, ik ben recent ontslagen door Quick Sales, maar ik vind dat onterecht.";
    private string _D1 = "Ik was daar werkzaam als verkoopmedewerker en door middel van onze artificial intelligence selecteren wij potentiële klanten.";
    private string _D2 = "Ik ben er vanuit gegaan dat de door Quick Sales aangeboden AI te vertrouwen is. Ik contacteer dan de mensen die de AI aanbeveelt.";
    private string _D3 = "Quick Sales zegt nu dat ik spullen heb aangeboden aan mensen die niet besluitvaardig zijn. Dat kan misschien kloppen, maar dat is dan niet mijn schuld.";
    private string _D4 = "Ik ga er vanuit dat de AI van Quick Sales betrouwbaar is, maar blijkbaar verwerkt de AI de data niet op de juiste manier.";
    private string _D5 = "De fout ligt dus niet bij mij, maar bij Quick Sales. Zij hebben mij deze problematische AI gegeven om mee te werken."; // end first party
    private string _D6 = "Mevrouw Jansen heeft onjuist gehandeld. Ze heeft contracten aangeboden aan klanten die handelingsonbekwaam zijn--of dronken--op het moment van besluit.";
    private string _D7 = "Dit heeft ze zo frequent gedaan dat het Quick Sales juridische problemen heeft gebracht en dat heeft ons veel geld gekost.";
    private string _D8 = "Op grond daarvan hebben wij haar ontslagen. De AI is slechts een tool. Het gebruikte algoritme draagt alleen mensen aan als potentiële klant.";
    private string _D9 = "Het is uiteindelijk aan de verkoper zelf om deze persoon eerlijk te beoordelen. Dit heeft mevrouw Jansen duidelijk nooit gedaan."; //end second party

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
        _Names[5] = _Name1;
        _Names[6] = _Name2;
        _Names[7] = _Name2;
        _Names[8] = _Name2;
        _Names[9] = _Name2;

        _Faces[0] = _Face1;
        _Faces[1] = _Face1;
        _Faces[2] = _Face1;
        _Faces[3] = _Face1;
        _Faces[4] = _Face1;
        _Faces[5] = _Face1;
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
            //yield return new WaitForSeconds(_ButtonDelay);
            _ButtonPressed = false;
            yield return new WaitUntil(() => _ButtonPressed == true);
            _ButtonPressed = false;
            if (_TutorialText!=null)
            _TutorialText.SetActive(false);
        }
        _FirstCanvas.ActivateMouseAndSecondCanvas();
        _EndScript.DialogueIsOver();
        _DialogueCanvas.SetActive(false); 
    }


    public void ButtonWasPressed()
    {
        _ButtonPressed = true;
    }
}
