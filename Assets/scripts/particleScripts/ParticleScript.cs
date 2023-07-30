using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem particle;
    [System.Obsolete]
    void Start()
    {
        //launch particle system and change its properties by size
        particle = this.GetComponent<ParticleSystem>();
        particle.startSize *= GetComponentInParent<Meteoritescript>().fullhp;
        particle.startLifetime *= GetComponentInParent<Meteoritescript>().fullhp;
    }
}
