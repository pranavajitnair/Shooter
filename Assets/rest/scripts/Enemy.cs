using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PrefabToUse;

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
        ParticleSystem sys=Instantiate(PrefabToUse, transform.position, Quaternion.identity).GetComponentInChildren<ParticleSystem>();
        sys.Play();
        Destroy(gameObject);
        print("Collision");
    }
}
