using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoTypeScript : MonoBehaviour
{

    private Text _AutoTypeText;
    private string _helperString;

    [SerializeField]
    private float _typingSpeedPause=0.2f;

    [SerializeField]
    private ActivateButtonsScript Button1;

    [SerializeField]
    private ActivateButtonsScript Button2;

    [SerializeField]
    private ActivateButtonsScript Button3;

    [SerializeField]
    private ActivateButtonsScript Button4;

    void Start()
    {

        _AutoTypeText = GetComponent<Text>();
        _helperString = _AutoTypeText.text;
        _AutoTypeText.text = "";
        TypeSSText();

      //  Debug.Log(_helperString);
    }


    public void TypeSSText()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in _helperString.ToCharArray())
        {

            _AutoTypeText.text += letter;
            //if (sound)
            //    GetComponent<AudioSource>().PlayOneShot(sound);

            yield return new WaitForSeconds(_typingSpeedPause);
        }
        Button1.ActivateButtons();
        yield return new WaitForSeconds(1.0f);
        Button2.ActivateButtons();
        yield return new WaitForSeconds(1.0f);
        Button3.ActivateButtons();
        yield return new WaitForSeconds(1.0f);
        Button4.ActivateButtons();
        // yield return new WaitForSeconds(1.0f);

        // _AutoTypeText.text = " ";
    }

}
