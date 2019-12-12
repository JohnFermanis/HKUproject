using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    [SerializeField]
    private int ChangeToScene;


    [SerializeField]
    private UnityEngine.Video.VideoPlayer vp;

    void Update()
    {
        if (!vp.isPlaying)
            _gm.ChangeScene(ChangeToScene);
    }
}
