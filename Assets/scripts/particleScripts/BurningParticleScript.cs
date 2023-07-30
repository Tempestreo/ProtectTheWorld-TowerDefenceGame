using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningParticleScript : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {        //launch particle system and change its properties by size
        particle = this.GetComponent<ParticleSystem>();
        particle.startSize = this.transform.parent.GetComponent<MeteoriteParticleScript>().meteorhp * 0.15f;
    }

    void Update()
    {
        
    }
}
