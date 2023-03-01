using UnityEngine;

public class Meteoritescript : MonoBehaviour
{
    #region variables
    public GameObject meteoriteparticle;
    public Sprite meteor;
    public int fullhp;
    public int hp;
    public float speed;
    public int imaginaryhp;
    #endregion
    #region components
    Rigidbody2D rb2d;
    Launcher sclauncher;
    WaveManager scwave;
    ButtonManager scbutton;
    SphereScript scsphere;
    #endregion
    void Start()
    {
        #region components
        rb2d = GetComponent<Rigidbody2D>();
        scwave = FindObjectOfType<WaveManager>();
        sclauncher = FindObjectOfType<Launcher>();
        scbutton = FindObjectOfType<ButtonManager>();
        scsphere = FindObjectOfType<SphereScript>();
        #endregion

        float positionx = this.transform.position.x;
        float positiony = this.transform.position.y;
        this.transform.Rotate(new Vector3(this.transform.rotation.x * 2, this.transform.rotation.y * 2, 1 * Time.deltaTime));
        hp = fullhp;
        speed = (fullhp * 25) / (fullhp * 3);
        //using imaginary hp to dont waste the next rocket if previous one is gonna destroy the meteorite.
        imaginaryhp = fullhp;
        this.transform.localScale = new Vector3(fullhp * 2, fullhp * 2, 0);
        rb2d.AddForce(new Vector2(-positionx * speed, -positiony * speed));
        Invoke("SelfDestroy", scwave.wavetiming);
    }
    #region destroy meteorite and gain point
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rockettag")
        {
            hp -= sclauncher.damage;
            if (hp <= 0)
            {
                scwave.point += fullhp + PlayerPrefs.GetInt("Gold");
                meteoriteparticle.transform.position = this.transform.position;
                meteoriteparticle.GetComponent<MeteoriteParticleScript>().meteorhp = fullhp;
                Instantiate(meteoriteparticle);
                SelfDestroy();
            }
        }
        if (other.tag == "worldtag")
        {
            scwave.population -= (scwave.population / 100);
            scwave.damageRatio += (fullhp * 5) / scbutton.lvlsize;
            scwave.txtDamagerate.text = (Mathf.RoundToInt(scwave.damageRatio)).ToString();
            scsphere.hit = true;
            if (scwave.damageRatio > 99)
            {
                scwave.OverAnim();
            }
            SelfDestroy();
        }
        if (other.tag == "Protector")
        {
            SelfDestroy();
        }
    }
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
