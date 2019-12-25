using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_handler : MonoBehaviour
{
    [SerializeField] GameObject DeathFX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        startDeathSequence();
    }

    void startDeathSequence()
    {
        DeathFX.SetActive(true);
        ParticleSystem sys = DeathFX.GetComponentInChildren<ParticleSystem>();
        sys.Play();
        SendMessage("onPlayerDeath");
        Invoke("loadScene", 0.5f);
    }

    void loadScene()
    {
        SceneManager.LoadScene(1);
        FindObjectsOfType<AudioSource>()[0].Play();
    }
}
