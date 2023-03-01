using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Worldscript : MonoBehaviour
{
    #region components
    WaveManager scwave;
    SphereScript scsphere;
    #endregion
    #region variables
    public int protectorcount;
    public int protectors;
    public GameObject Protector;
    public Vector2 position;
    public bool ProtectorsAreReady;
    public bool endOfFight;
    bool spaceShipattacking;
    #endregion
    private void Start()
    {
        #region Linking components
        scsphere = FindObjectOfType<SphereScript>();
        scwave = FindObjectOfType<WaveManager>();
        #endregion
        protectorcount = 0;
        ProtectorsAreReady = false;
        endOfFight = false;
    }
    private void FixedUpdate()
    {
        FlightsMove();

    }
    //instantiating protectors
    private void FlightsMove()
    {
        if (ProtectorsAreReady)
        {
            for (; protectorcount > 0; protectorcount--)
            {
                Instantiate(Protector);
                protectors++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lasertag")
        {
            spaceShipattacking = true;
            StartCoroutine(num());
        }
        if (collision.tag == "meteortag")
        {
            position = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lasertag")
        {
            spaceShipattacking = false;
        }

    }
    //Alien attack to the world
    IEnumerator num()
    {
        while (spaceShipattacking)
        {
            scsphere.hit = true;
            scwave.damageRatio+=1;
            scwave.txtDamagerate.text = scwave.damageRatio.ToString();
            if (scwave.damageRatio > 99)
            {
                scwave.OverAnim();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
