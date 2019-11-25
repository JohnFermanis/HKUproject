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

    private bool Rcheck=false, Lcheck=false;

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

        if (Rcheck == false || Lcheck == false) 
        {
            if (PlayerCamera.transform.rotation.y > 0.3f)
            {
                Rcheck = true;
                
            }
            else if (PlayerCamera.transform.rotation.y < -0.3f)
            {
                Lcheck = true;
          
            }

        }
        else if(!DONE)
        {
            Debug.Log("GG YOU CLEARED THE MOUSE TUTORIAL");
            DONE = true;
            _textUpdateScript.UpdateText1();
            _img.gameObject.SetActive(false);
        }
            
        
    }
}
