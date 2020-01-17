using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script to add to end of animation, to go to the next scene.

public class CutsceneEndScript : MonoBehaviour
{

    public int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
         SceneManager.LoadScene(sceneNumber);
    }


}
