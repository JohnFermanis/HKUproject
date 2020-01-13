using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    //[SerializeField]
    //private bool _GoToNextScene=true;
    [SerializeField]
    private int ChangeToScene;

    [SerializeField]
    private bool _SkipCutscene=true;


    [SerializeField]
    private UnityEngine.Video.VideoPlayer vp;

    
    void Update()
    {
        if (!vp.isPlaying || _SkipCutscene){

            //if(_GoToNextScene)
            _gm.ChangeScene(ChangeToScene);
        }
    }
}
