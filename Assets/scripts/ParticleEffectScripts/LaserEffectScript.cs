using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class LaserEffectScript : MonoBehaviour
{
    SpaceShipScript scShip;
    Worldscript scworld;
    public VisualEffect LaserEffect;
    public VisualEffect Laser;
    public BoxCollider2D Collider;
    Vector2 offset;
    Vector2 size;

    void Start()
    {
        scworld = FindObjectOfType<Worldscript>();
        scShip = FindObjectOfType<SpaceShipScript>();
        Laser.Stop();
        LaserEffect.Stop();
        offset = Collider.offset;
        size = Collider.size;
    }
    void Update()
    {
        //stops the laser that attacks to the world
        if (scworld.ProtectorsAreReady)
        {
            LaserEffect.Stop();
            Laser.Stop();
        }
        //launch the laser ball that attacks to the protector
        else if(!scworld.ProtectorsAreReady && scShip.isEngineStopped)
        {
            LaserEffect.Play();
            Invoke("LaserReady", 4);
        }
    }
    void LaserReady()
    {
        Laser.Play();
        for (; size.x < 13f;)   
        {
            StartCoroutine(num());
        }

    }
    //changes properties by size
    IEnumerator num()
    {
        offset.x += 0.5f;
        size.x += 1.1f;
        yield return new WaitForSeconds(0.3f);
        Collider.offset = offset;
        Collider.size = size;
    }
}
