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
    private AudioSource _RedFoldersMusic;

    private void Update()
    {
        if(_RedFolderCounter.counter >= _RedFolderCounter.TurnAllRedAfter)
        {
            _InitialBackgroundMusic.Stop();
            _RedFoldersMusic.PlayDelayed(1);
        }
    }

}
