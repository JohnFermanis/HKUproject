using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{

    [SerializeField]
    private GameObject _off;

    [SerializeField]
    private float _letterPause=0.5f;

    private Text _thisText;

    private bool _TextRunning=false;

    private bool _TextFinished;

    private string[] _Dialogue = new string[10];

    private string _D0 = "This is the dialogue1";
    private string _D1 = "This is the dialogue2";
    private string _D2 = "This is the dialogue3";
    private string _D3 = "This is the dialogue4";
    private string _D4 = "This is the dialogue5";
    private string _D5 = "This is the dialogue6";
    private string _D6 = "This is the dialogue7";
    private string _D7 = "This is the dialogue8";
    private string _D8 = "This is the dialogue9";
    private string _D9 = "This is the dialogue10";

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

    }

    void Update()
    {
        if (!_TextRunning)
        {
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _TextRunning = true;
                StartCoroutine(TypeText());
                //move the conversation forward
            }
        }
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < 10; i++)
        {
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
    }


    
}
