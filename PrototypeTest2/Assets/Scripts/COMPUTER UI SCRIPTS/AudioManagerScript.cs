using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]
    private RedFolderCounterScript _RedFolderCounter;

    [SerializeField]
    private AudioSource _InitialBackgroundMusic;
    [SerializeField]
    private AudioClip _RedFoldersMusic;

    private bool _RedsOn=false;

    private void Update()
    {
        if(_RedsOn==false){
            if(_RedFolderCounter.counter >= _RedFolderCounter.TurnAllRedAfter)
            {
                _RedsOn=true;
                _InitialBackgroundMusic.Stop();
                _InitialBackgroundMusic.clip = _RedFoldersMusic;
                _InitialBackgroundMusic.Play();
            }
        }
    }

}
