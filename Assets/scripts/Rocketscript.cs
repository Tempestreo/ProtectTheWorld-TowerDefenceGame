using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocketscript : MonoBehaviour
{

    #region components
    Launcher sclauncher;
    Rangescript scrange;
    ButtonManager scbutton;
    Rigidbody2D rb2d;
    WaveManager scwave;
    #endregion
    Vector3 meteoriteposition;
    Quaternion rotation;
    Vector3 location;
    public int Cost;
    void Start()
    {
        #region components
        scbutton = FindObjectOfType<ButtonManager>();
        sclauncher = FindObjectOfType<Launcher>();
        scrange = FindObjectOfType<Rangescript>();
        scwave = FindObjectOfType<WaveManager>();
        rb2d = GetComponent<Rigidbody2D>();
        #endregion
        meteoriteposition = scrange.meteoriteposition - this.transform.position;
        Cost = Mathf.RoundToInt((scbutton.lvlrange + scbutton.lvlrate + scbutton.lvldamage) / (10*scbutton.lvlcost));
        scwave.point -= Cost;
        this.transform.position = sclauncher.transform.position;
        
        Invoke("SelfDestroy", 4f);
        Movement();
    }
    //move the rocket towards to the meteorite
    void Movement()
    {
        rotation = Quaternion.LookRotation(scrange.meteoriteposition - this.transform.position);
        if (meteoriteposition.x > 0)
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
        rb2d.AddForce(Vector2.MoveTowards(location, meteoriteposition, 2));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "meteortag")
        {
            Destroy(this.gameObject);
        }
    }
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
