using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningParticleScript : MonoBehaviour
{
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle =this.GetComponent<ParticleSystem>();
        particle.startSize = this.transform.parent.GetComponent<MeteoriteParticleScript>().meteorhp * 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
