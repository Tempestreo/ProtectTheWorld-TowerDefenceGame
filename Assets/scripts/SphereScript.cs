using System.Collections;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    #region components
    SpriteRenderer SR;
    WaveManager scwave;
    Worldscript scworld;
    #endregion
    public Vector2 ShockwavePos;
    public Material mat;
    public float transparency,x,y;
    public bool hit;

    void Start()
    {
        #region Linking components
        scworld = FindObjectOfType<Worldscript>();
        scwave = FindObjectOfType<WaveManager>();
        mat = GetComponent<Renderer>().material;
        SR = GetComponent<SpriteRenderer>();
        #endregion
        hit = false;
        SR.color = new Color(1f, 1f, 1f, transparency);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //center of the shockwave on the hexagonal sphere which protects the world
        if (other.tag == "meteortag")
        {
            float x = other.transform.position.x;
            float y = other.transform.position.y;
            if (x < 0)
            {
                x *= -0.1f;
            }
            else if (x < 0.5f)
            {
                x += 0.5f;
            }
            if (y < 0)
            {
                y *= -0.1f;
            }
            else if (y < 0.5f)
            {
                y += 0.5f;
            }
            mat.SetVector("_Focal",new Vector2(x,y));
        }   
    }
    void FixedUpdate()
    {
        if (hit)
        {
            transparency = 1 - (float)(scwave.damageRatio / 100);
            SR.color = new Color(1f, 1f, 1f, transparency);
            StartCoroutine(Restore());
            hit = false;
        }
    }
    //transparency of the hexagonal sphere. changes by damage
    IEnumerator Restore()
    {
        for (; transparency > 0; transparency -= 0.02f)
        {
            SR.color = new Color(1f, 1f, 1f, transparency);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
