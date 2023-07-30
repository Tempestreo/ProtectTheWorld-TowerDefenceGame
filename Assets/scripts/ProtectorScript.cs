using UnityEngine;

public class ProtectorScript : MonoBehaviour
{
    #region Components
    Rigidbody2D rb2d;
    SpaceShipScript scship;
    Worldscript scworld;
    ButtonManager scButton;
    #endregion

    public GameObject laser;
    
    Vector3 location;
    Vector2 position;
    Vector2 target;
    Quaternion rotation;

    float random;
    bool laserready;
    public int hp;

    void Start()
    {
        #region linking components
        scButton = FindObjectOfType<ButtonManager>();
        scship = FindObjectOfType<SpaceShipScript>();
        scworld = FindObjectOfType<Worldscript>();
        rb2d = GetComponent<Rigidbody2D>();
        #endregion

        hp = 3 + PlayerPrefs.GetInt("Protector");
        laserready = true;
        random = Random.Range(-6f, 6f);
        this.transform.localScale = new Vector3(this.transform.localScale.x * (scButton.lvlsize / 1.5f), this.transform.localScale.y * (scButton.lvlsize / 1.5f), this.transform.localScale.z * (scButton.lvlsize/ 1.5f));
    }

    void FixedUpdate()
    {
        if (hp < 1)
        {
            Destroy(this.gameObject);
        }
        position = this.transform.position;
        if (scworld.endOfFight == false)
        {
            MoveToAlien();
        }
        else
        {
            ComeBack();
        }
        LaserControl();
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "plasmatag")
        {
            hp--;
            if (hp<1)
            {
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "meteortag")
        {
            hp--;
            if (hp < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
    //Move protector to the alienship till attack range is enough
    void MoveToAlien()
    {
        target = new Vector2(scship.gameObject.transform.position.x, (scship.gameObject.transform.position.y - random)/3f);
        float x = scship.transform.position.x - position.x;
        float y = scship.transform.position.y - position.y;

        rotateIt(scship.transform.position);
        if (Mathf.Abs(x) > 1.5f + (scship.fullhp * 0.18f) || Mathf.Abs(y) > 1.5f + (scship.fullhp *0.18f))
        {
            location = new Vector3(rotation.x, rotation.y, rotation.z);
            rb2d.velocity = Vector2.MoveTowards(location, target, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            scship.startTheWar = true;

        }
    }
    //if the alienship die, return protector to the world
    void ComeBack()
    {
        scworld.ProtectorsAreReady = false;
        Vector3 worldLocation = scworld.transform.position;
        target = new Vector2(worldLocation.x / 2 , (worldLocation.y - random) / 2);
        float x = worldLocation.x - position.x;
        float y = worldLocation.y - position.y;
        if (Mathf.Abs(x) > 0.3f || Mathf.Abs(y) > 0.3f)
        {
            if (this.transform.position.x > 0)
            {
                rotation = Quaternion.LookRotation(worldLocation - this.transform.position);
                if (target.x > 0)
                {
                    rotation *= Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    rotation *= Quaternion.Euler(0, 0, 90);
                }
                rotation.Set(0, 0, rotation.z, rotation.w);
                rb2d.transform.rotation = rotation;
            }
            else
            {
                rotateIt(worldLocation);
            }
            rb2d.velocity = new Vector2(x / 1.5f, y / 1.5f);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            scworld.protectorcount++;
            Destroy(this.gameObject);
        }
    }
    //rotate the protector to the target(alienship or world)
    void rotateIt(Vector3 target)
    {
        rotation = Quaternion.LookRotation(target - this.transform.position);
        if (target.x >= 0)
        {
            rotation *= Quaternion.Euler(0, 0, -90);
        }
        else
        {
            rotation *= Quaternion.Euler(0, 0, 90);
        }
        rotation.Set(0, 0, rotation.z, rotation.w);
        rb2d.transform.rotation = rotation;
    }
    void LaserControl()
    {
        if (scship.startTheWar && laserready)
        {
            laser.transform.position = this.transform.position;
            Instantiate(laser);
            laserready = false;
            Invoke("GetLaserReady", 2);
        }

    }
    void GetLaserReady()
    {
        laserready = true;
    }
}
