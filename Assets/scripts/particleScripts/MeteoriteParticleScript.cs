using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteParticleScript : MonoBehaviour
{
    ParticleSystem particle;
    public float meteorhp;
    [System.Obsolete]
    void Start()
    {// changes particle properties by size 
        particle = this.GetComponent<ParticleSystem>();
        particle.Play();
        particle.startSize *= meteorhp;
        particle.startLifetime *= meteorhp;
        particle.startSpeed *= meteorhp/2;
        Invoke("SelfDestroy", 2);
    }
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
