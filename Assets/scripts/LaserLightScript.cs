using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLightScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 Alienship;
    Vector2 location;
    Quaternion rotation;
    SpaceShipScript scship;
    Worldscript scworld;
    // Start is called before the first frame update
    void Start()
    {
        #region components
        scworld = FindObjectOfType<Worldscript>();
        scship = FindObjectOfType<SpaceShipScript>();
        rb2d = GetComponent<Rigidbody2D>();
        #endregion
        //start position and movement of the laser
        Alienship = scship.transform.position  - this.transform.position;
        movement();
        Invoke("selfdestroy", 4);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if collider of the laser hit protector's collider give damage
        if (other.tag == "spaceshiptag")
        {
            scship.hp--;
            if (scship.hp < 1)
            {
                scworld.endOfFight = true;
                scship.startTheWar = false;
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    void movement()
    {
        rotation = Quaternion.LookRotation(Alienship);
        if (Alienship.x > 0)
        {
            rotation *= Quaternion.Euler(0, 0, -90);
        }
        else
        {
            rotation *= Quaternion.Euler(0, 0, 90);
        }
        rotation.Set(0, 0, rotation.z, rotation.w);
        rb2d.transform.rotation = rotation;
        location = new Vector2(rotation.x, rotation.y);
        rb2d.AddForce(Vector2.MoveTowards(location, Alienship, 2));
    }
    void selfdestroy()
    {
        Destroy(this.gameObject);
    }
}
