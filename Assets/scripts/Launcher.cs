using UnityEngine;

public class Launcher : MonoBehaviour
{
    #region variables
    public GameObject missile;
    Rangescript scrange;
    public Rigidbody2D rb2d;
    public int damage;
    public float rate = 3;
    public bool isReady;
    #endregion
    void Start()
    {
        #region components
        scrange = FindObjectOfType<Rangescript>();
        rb2d = GetComponent<Rigidbody2D>();
        #endregion

        isReady = true;
        damage = 1;
    }
    void FixedUpdate()
    {
        LauncherControl();
    }
    //move launcher's lookrotation to meteorite
    void LauncherMove()
    {
        Vector3 vectorToTarget = scrange.meteoriteposition - this.transform.position;
        Vector3 rotated = Quaternion.Euler(0, 0, 180) * vectorToTarget;
        Quaternion targetrotation = Quaternion.LookRotation(Vector3.forward, rotated);
        transform.rotation = targetrotation;
    }

    void LauncherControl()
    {
        //if the meteorite in range and rocket ready to launch, launch it 
        if (scrange.isTouched && isReady)
        {
            scrange.isTouched = false;
            isReady = false;
            Invoke("GetRocketReady", rate);
            InstantiateRocket();
        }
    }
    void InstantiateRocket()
    {
        scrange.meteoriteposition = scrange.meteorite.transform.position; 
        scrange.meteorite.GetComponent<Meteoritescript>().imaginaryhp -= damage;
        LauncherMove();
        Instantiate(missile);
    }
    void GetRocketReady()
    {
        isReady = true;
    }
}
