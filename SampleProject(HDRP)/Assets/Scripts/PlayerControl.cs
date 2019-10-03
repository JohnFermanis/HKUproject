using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool Active = false;

    [SerializeField]
    private float _speed=1.0f;
    private bool PosSelected;

    private float HoriInput;
    private float VertiInput;
    // Start is called before the first frame update



    private void Start()
    {
        for(int i=0; i < Display.displays.Length;i++)
            {
            Display.displays[i].Activate(1024,768,60);
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            HoriInput = Input.GetAxis("Horizontal");
            VertiInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(HoriInput,0,VertiInput)*Time.deltaTime*_speed);


            

        }
        

    }

    public void ActivateControls()
    {
        Active = true;
    }
}
