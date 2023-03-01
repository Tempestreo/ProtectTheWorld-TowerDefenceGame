using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    #region variables
    Worldscript scworld;
    public Vector3 protectorPos;
    SpaceShipScript scship;
    LinkedList<GameObject> protectors;
    public bool protectorDestroyed;
    PlasmaScript scplasma;
    #endregion
    private void Start()
    {
        #region linking
        scworld = FindObjectOfType<Worldscript>();
        scship = FindObjectOfType<SpaceShipScript>();
        scplasma = FindObjectOfType<PlasmaScript>();
        #endregion
        protectors = new LinkedList<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Protector")
        {
            protectors.AddLast(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Protector")
        {
            protectorPos = protectors.First.Value.transform.position;
            protectorDestroyed = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Protector")
        {
            protectors.RemoveFirst();
            protectorDestroyed = true;
            if (protectors.First != null)
            {
                protectorPos = protectors.First.Value.transform.position;
            }
            scworld.protectors--;
            if (scworld.protectors == 0)
            {
                scship.startTheWar = false;
                scworld.ProtectorsAreReady = false;
            }
        }
    }
}
