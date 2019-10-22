using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    private bool PosSelected;

    private float HoriInput;
    private float VertiInput;

    private float eux,euy,euz;
    

    void Update()
    {
            HoriInput = Input.GetAxis("Horizontal")*Time.deltaTime* _speed;
            VertiInput = Input.GetAxis("Vertical")*Time.deltaTime* _speed;
        eux = transform.eulerAngles.x;
        euy = transform.eulerAngles.y;
        //euz = transform.eulerAngles.z;
           // transform.Rotate(new Vector3(-VertiInput, HoriInput, 0));
        //transform.Rotate(-VertiInput, HoriInput, 0);

        transform.eulerAngles = new Vector3(eux - VertiInput, euy + HoriInput, 0);
    }

    
}
