using UnityEngine;

public class Rangescript : MonoBehaviour
{
    public bool isTouched = false;
    public Vector3 meteoriteposition;
    public GameObject meteorite;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "meteortag")
        {
            if (other.gameObject.GetComponent<Meteoritescript>().imaginaryhp > 0)
            {
                meteorite = other.gameObject;
                isTouched = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "meteortag")
        {
                isTouched = false;
        }
    }
}
