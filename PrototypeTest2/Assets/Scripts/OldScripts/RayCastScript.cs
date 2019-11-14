using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField]
    private float _cooldown = 2.0f;
    private float _canFire = -1.0f;

    private int count = 0;

    //  [SerializeField]
    //  private GameObject _SSTyper;

    //  [SerializeField]
    //  private GameObject _winObject;
    //  private AutotypeScript _SSTyperScript;

   // [SerializeField]
    private Light _LightVar;

    [SerializeField]
    private GameObject _TextObject;

    [SerializeField]
    private GameObject _Wintext;

    private void Start()
    {
        _Wintext.SetActive(false);
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _cooldown;


            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            RaycastHit hit1;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit1, 1000))
            {
                //_SSTyperScript.TypeSSText();
                if (hit1.collider.gameObject.tag == "ItemToPick")
                {
                    hit1.collider.gameObject.SetActive(false);
                    count++;
                   // if(_TextObject.GetComponent<TextScript>()!=null)
                    _TextObject.GetComponent<TextScript>().addNumber(count);
                }
                if (count >= 4)
                    _Wintext.SetActive(true);
            }
           // else
           // {
               // _SSTyperScript.TypeFailText();
           // }


        }

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //  hit.collider.gameObject.SetActive(false);
            if (hit.collider.gameObject.tag == "ItemToPick")
            {
                if (_LightVar == null)
                {
                    _LightVar = hit.collider.gameObject.GetComponentInChildren<Light>();
                    _LightVar.intensity = 400.0f;
                }
               
            }
            else if (_LightVar != null)
            {
                if (_LightVar.intensity == 400.0f)
                    _LightVar.intensity = 0.0f;
                _LightVar = null;
            }


            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
            if ( _LightVar != null)
            {
                if(_LightVar.intensity == 400.0f)
                    _LightVar.intensity = 0.0f;
                _LightVar = null;
            }
              

           // if (_LightVar.intensity == 400.0f)
           //     _LightVar.intensity = 0.0f;
            //Debug.Log("Did not Hit");
        }

        
    }
    
}
