using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutotypeScript : MonoBehaviour
{
    [SerializeField]
    private Text _ScreenShotText;
    private string _message;

    [SerializeField]
    private Text _FailText;
    private string _failmessage;
    [SerializeField]
    private float _letterPause=0.3f;
    
    void Start()
    {
        _message = _ScreenShotText.text;
        _ScreenShotText.text = " ";

        _failmessage = _FailText.text;
        _FailText.text = " ";
    }

  
    public void TypeSSText()
    {
        StartCoroutine(TypeText());
    }

    public void TypeFailText()
    {
        StartCoroutine(TypeFailText1());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in _message.ToCharArray())
        {
           
                _ScreenShotText.text += letter;
                //if (sound)
                //    GetComponent<AudioSource>().PlayOneShot(sound);

                yield return new WaitForSeconds(_letterPause);
            }
        yield return new WaitForSeconds(1.0f);

        _ScreenShotText.text = " ";
    }


    IEnumerator TypeFailText1()
    {
        foreach (char letter in _failmessage.ToCharArray())
        {

            _FailText.text += letter;
            //if (sound)
            //    GetComponent<AudioSource>().PlayOneShot(sound);

            yield return new WaitForSeconds(_letterPause);
        }
        yield return new WaitForSeconds(1.0f);

        _FailText.text = " ";
    }
}
