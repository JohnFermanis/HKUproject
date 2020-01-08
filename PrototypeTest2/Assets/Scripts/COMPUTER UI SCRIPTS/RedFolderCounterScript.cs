using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFolderCounterScript : MonoBehaviour
{
    public int counter=0;

    public int TurnAllRedAfter=0;

    [SerializeField]
    private AudioSource _VoiceClip;

    public void Plus1()
    {
        counter++;

        if (counter >= TurnAllRedAfter)
        {
            if (_VoiceClip != null)
                _VoiceClip.Play();
        }
    }



   // public int ReturnCounter()
   // {
   //    return counter;
   // }
}
