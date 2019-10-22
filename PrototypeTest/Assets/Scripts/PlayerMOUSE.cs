using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOUSE : MonoBehaviour
{
    [SerializeField]
    private float _cooldown = 2.0f;
    private float _canFire = -1.0f;

    private int count = 0;

    [SerializeField]
    private GameObject _SSTyper;

    [SerializeField]
    private GameObject _winObject;
    private AutotypeScript _SSTyperScript;

    [SerializeField]
    private float _speed = 1.0f;
    private bool PosSelected;

    private float HoriInput;
    private float VertiInput;

    private float eux, euy, euz;

    void Start()
    {
        _SSTyperScript = _SSTyper.GetComponent<AutotypeScript>();
    }

    void Update()
    {
        HoriInput = Input.GetAxis("Mouse X") * Time.deltaTime * _speed;
        VertiInput = Input.GetAxis("Mouse Y") * Time.deltaTime * _speed;
        eux = transform.eulerAngles.x;
        euy = transform.eulerAngles.y;




        transform.eulerAngles = new Vector3(eux - VertiInput, euy + HoriInput, 0.0f);


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _cooldown;


            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            RaycastHit hit1;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit1, 1000))
            {
                _SSTyperScript.TypeSSText();
                hit1.collider.gameObject.SetActive(false);
                count++;
                if (count >= 3)
                    _winObject.GetComponent<ImageScript>().ActivateImage();
            }
            else
            {
                _SSTyperScript.TypeFailText();
            }


        }

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //  hit.collider.gameObject.SetActive(false);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }

    }


}
