using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class AutoTypeScript : MonoBehaviour
{
    
    [SerializeField]
    private float letterPause = 0.08f;
    // public AudioClip sound;
    private string message;

    [SerializeField]
    private GameObject DirectionalLight;

    [SerializeField]
    private GameObject Cylinder;

    private Animator cameranim;
    private bool cameraStop=false;

    private bool TextRunning=false;

    private bool TextFinished=false;

    // Use this for initialization
    void Start()
    {
        message = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        DirectionalLight.SetActive(false);

        cameranim = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && TextFinished==false && TextRunning == false)
        {
            TextRunning = true;
            StartCoroutine(TypeText());

        }
        else if (Input.GetKeyDown("space") && TextFinished == false && TextRunning == true)
        {
            TextFinished = true;
            TextRunning = false;
            StopCoroutine(TypeText());

            GetComponent<Text>().text = message;
           

        }
        else if (TextFinished == true && Input.GetKeyDown("space") && TextRunning==false)
        {
            GetComponent<Text>().text = "";
            DirectionalLight.SetActive(true);
            cameranim.Play("Camera");

           
        }

        if (cameraStop == false)
        {
            cameraStop = cameranim.GetCurrentAnimatorStateInfo(0).IsName("Stop");
        }
        else
        {
            //activate fake screen controls
            if (null != Cylinder.GetComponent<PlayerControl>())
            {
                Cylinder.GetComponent<PlayerControl>().ActivateControls();
            }
            else
            {
                Debug.LogError("Cylinder.PlayerControl was not fetched correctly");
            }
        }
           

    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            if (!TextFinished)
            {
                GetComponent<Text>().text += letter;
                //if (sound)
                //    GetComponent<AudioSource>().PlayOneShot(sound);

                yield return new WaitForSeconds(letterPause);
            }
        }

        TextFinished = true;
        TextRunning = false;
        //yield return new WaitForSeconds(5.0f);

        //GetComponent<Text>().text = "";

    }
}
