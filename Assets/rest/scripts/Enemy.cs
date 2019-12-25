using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PrefabToUse;
    [SerializeField] int scorePerHit = 10;

    [SerializeField] int numberOfHits;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        numberOfHits--;

        if (numberOfHits <= 0)
        {
            FindObjectOfType<ScoreBoard>().ScoreHit(scorePerHit);
            ParticleSystem sys = Instantiate(PrefabToUse, transform.position, Quaternion.identity).GetComponentInChildren<ParticleSystem>();
            sys.Play();
            Destroy(gameObject);
            print("Collision");
        }
    }
}
