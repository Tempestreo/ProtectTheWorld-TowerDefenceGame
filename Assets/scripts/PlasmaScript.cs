using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaScript : MonoBehaviour
{
    #region variables
    Rigidbody2D rb2d;
    SpaceShipScript scship;
    TriggerScript sctrigger;
    Worldscript scworld;
    Vector3 protectorLocation;
    Vector3 Protector;
    Quaternion rotation;
    #endregion
    void Start()
    {
        #region linking components
        rb2d = GetComponent<Rigidbody2D>();
        scship = FindObjectOfType<SpaceShipScript>();
        sctrigger = FindObjectOfType<TriggerScript>();
        scworld = FindObjectOfType<Worldscript>();
        #endregion

        this.transform.localScale = new Vector3(this.transform.localScale.x * (scship.fullhp / 5), this.transform.localScale.y * (scship.fullhp / 5), this.transform.localScale.z * (scship.fullhp / 5));
        protectorLocation = sctrigger.protectorPos;
        Protector = protectorLocation - this.transform.position;
        Invoke("Movement", 3f);
        Invoke("SelfDestroy", 5);
    }
    private void Update()
    {
        if (scworld.endOfFight == true || scship.startTheWar == false || Time.timeScale == 0 || sctrigger.protectorDestroyed == true)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Protector")
        {
            Destroy(this.gameObject);
        }
    }
    //moving the plasma towards to the protector ship
    void Movement()
    {
        rotation = Quaternion.LookRotation(Protector);
        if (protectorLocation.x > 0)
        {
            rotation *= Quaternion.Euler(0, 0, -90);
        }
        else
        {
            rotation *= Quaternion.Euler(0, 0, 90);
        }
        rotation.Set(0, 0, rotation.z, rotation.w);
        rb2d.transform.rotation = rotation;
        rb2d.AddForce(Vector2.MoveTowards(new Vector2(rotation.x, rotation.y), Protector, 2));
    }
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
