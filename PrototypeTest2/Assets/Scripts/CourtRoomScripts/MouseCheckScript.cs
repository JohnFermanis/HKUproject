using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCheckScript : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool DONE=false;

    private bool _SelectComputer=false;

    private bool Rcheck=false, Lcheck=false;

    [SerializeField]
    private GameObject _DialogueCanvas;

    [SerializeField]
    private GameObject _SecondCanvas;

    [SerializeField]
    private GameObject PlayerCamera;

    [SerializeField]
    private TextUpdateScript _textUpdateScript;

    [SerializeField]
    private GameObject _img;

    void Start()
    {
        // Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void Update()
    {

        /*if (Rcheck == false && Lcheck == false)
        {
            if (PlayerCamera.transform.rotation.y > 0.05f)
            {
                Rcheck = true;

            }
            else if (PlayerCamera.transform.rotation.y < -0.05f)
            {
                Lcheck = true;

            }

        }
        else */
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            if (!DONE && !_SelectComputer)
            {
                //   Debug.Log("GG YOU CLEARED THE MOUSE TUTORIAL");
                DONE = true;
                _textUpdateScript.ClearText();
                _img.gameObject.SetActive(false);
                
                _SelectComputer = true;
                
            StartCoroutine(LateDialogueStart());
           
        }
        //}
            
        
    }

    IEnumerator LateDialogueStart() {


        yield return new WaitForSeconds(1.0f);
        _DialogueCanvas.SetActive(true);
        _SecondCanvas.SetActive(false);
        _textUpdateScript.UpdateText1();
    }
}
