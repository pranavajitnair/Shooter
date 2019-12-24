using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_script : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Invoke("LoadFirstScene",2);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
