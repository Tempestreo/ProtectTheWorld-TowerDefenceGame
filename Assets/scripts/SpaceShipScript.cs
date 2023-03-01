using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    #region variables
    Rigidbody2D rb2d;
    Worldscript scworld;
    TriggerScript sctrigger;
    ParticleSystem engine;
    public GameObject plasma;

    Vector2 location;
    Vector2 worldLocation;
    public bool isEngineStopped;
    public bool startTheWar;
    bool plasmaReady;
    public int hp;
    public int fullhp;
    #endregion
    void Start()
    {
        #region linking components
        sctrigger = FindObjectOfType<TriggerScript>();
        scworld = FindObjectOfType<Worldscript>();
        rb2d = GetComponent<Rigidbody2D>();
        engine = GetComponentInChildren<ParticleSystem>();
        #endregion

        plasmaReady = true;
        hp = fullhp;
        this.transform.localScale = new Vector3(fullhp / 90f, fullhp / 90f, 0);
        isEngineStopped = false;
        //rotating spaceship to the world
        rotate(worldLocation);
    }
    void FixedUpdate()
    {
        if (startTheWar)
        {
            //if spaceship encounter with protector, rotate spaceship to the protector
            rotate(sctrigger.protectorPos);
            PlasmaControl();
        }
        else
        {
            Move();
        }
    }
    //move spaceship to the world till attack range reach
    public void Move()
    {
        float x, y;
        location = this.transform.position;
        worldLocation = scworld.transform.position;
        x = worldLocation.x - location.x;
        y = worldLocation.y - location.y;
        rotate(worldLocation);
        if (Mathf.Abs(x) > 3f +(0.25f * fullhp) || Mathf.Abs(y) > 3f + (0.25f * fullhp))
        {
            rb2d.velocity = new Vector2(x / 2, y / 2);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            isEngineStopped = true;
            if (scworld.protectorcount > 0 && scworld.protectors == 0)
            {
                scworld.ProtectorsAreReady = true;
                scworld.endOfFight = false;
            }
            engine.Stop();
        }
    }
    void rotate(Vector3 target)
    {
        Vector3 vectorToTarget = target - this.transform.position;
        Vector3 rotated = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion targetrotation = Quaternion.LookRotation(Vector3.forward, rotated);
        transform.rotation = targetrotation;
    }
    void PlasmaControl()
    {
        if (startTheWar && plasmaReady)
        {
            plasma.transform.position = GetComponentInChildren<LaserEffectScript>().gameObject.transform.position;
            Instantiate(plasma);
            plasmaReady = false;
            Invoke("GetPlasmaReady", 1f);
        }
    }
    void GetPlasmaReady()
    {
        plasmaReady = true;
    }
}
