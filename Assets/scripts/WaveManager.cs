using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    #region components
    Worldscript scworld;
    SceneLoadment scScene;
    AdmobManager scAdmob;
    Camera maincamera;
    public Rangescript scrange;
    public Meteoritescript scmeteor;
    public SpaceShipScript scship;
    #endregion
    #region Variables

    
    public Text Score;
    public Text pointtext;
    public Text wavetext;
    public Text timingtext;
    public Text Level;

    public TextMeshProUGUI txtReserves;
    public TextMeshProUGUI txtPopulation;
    public TextMeshProUGUI txtDamagerate;

    public GameObject pnlEnding;
    public GameObject meteorite;
    public GameObject vfx;
    public GameObject SpaceShip;
    public GameObject GreenBar;
    public GameObject SolidBar;
    public GameObject TimeManipulation;

    public float population;
    public float reserves;
    public float consciousness;
    public float popratio;
    public float wavepoint;
    public float damageRatio;
    public float repairRate;

    public int point;
    public int wave;
    public int wavetiming;
    public int currentwave;
    int difficulty = 1;

    public Vector2 meteoriteposition;

    bool LevelUpAnim;
    public bool isover;
    float slowmoTime;
    public Quaternion rotation;
    #endregion
    private void Start()
    {
        if (PlayerPrefs.HasKey("Speeduptime") || PlayerPrefs.HasKey("Slowdowntime"))
        {
            TimeManipulation.SetActive(true);
        }

        #region linking components
        scAdmob = FindObjectOfType<AdmobManager>();
        scScene = FindObjectOfType<SceneLoadment>();
        scworld = FindObjectOfType<Worldscript>();
        maincamera = FindObjectOfType<Camera>();
        #endregion
        LevelUpAnim = false;

        repairRate = 1;
        population = 10;
        damageRatio =0;
        popratio = 10;
        point = 0;
        wave = 1;
        currentwave = 0;
        slowmoTime = 0.2f;
    }
    private void Update()
    {
        if (LevelUpAnim)
        {
            GreenBar.transform.localScale = new Vector3(Mathf.Lerp(GreenBar.transform.localScale.x, SolidBar.transform.localScale.x, 0.009f), 1, 1);
        }
    }
    private void FixedUpdate()
    {
        WaveSystem();
    }
    // game over animations
    public void OverAnim()
    {
        isover = true;
        Time.timeScale = slowmoTime;
        vfx.transform.position = scworld.transform.position;
        scworld.gameObject.SetActive(false);
        scrange.gameObject.SetActive(false);
        Instantiate(vfx);
        Invoke("GameOver", 1f);
    }
    public void GameOver()
    {
        scAdmob.CloseBanner();
        Time.timeScale = 0;
        pnlEnding.SetActive(true);
        pnlEnding.transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(scScene.RestartGame);
        pnlEnding.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(scScene.loadMenuScene);
        pnlEnding.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(scScene.PanelSkillTree);
        PlayerPrefs.SetFloat("Totalexp", PlayerPrefs.GetFloat("Totalexp") + ((currentwave * 10) / (PlayerPrefs.GetInt("Level") + 1)));
        if (currentwave > PlayerPrefs.GetInt("Bestscore"))
        {
            PlayerPrefs.SetInt("Bestscore", currentwave);
        }
        pnlEnding.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = currentwave.ToString();
        pnlEnding.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Bestscore").ToString();
        Level.text = (PlayerPrefs.GetInt("Level")+1).ToString(); 
        LevelUp();
    }
    //level up bar and store exp
    public void LevelUp()
    {
        while ((PlayerPrefs.GetFloat("Totalexp") / 500) - PlayerPrefs.GetInt("Level") >= 1)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            Level.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
            GreenBar.transform.localScale = new Vector3(0, 1, 1);
            SolidBar.transform.localScale = new Vector3((PlayerPrefs.GetFloat("Totalexp") / 500) - PlayerPrefs.GetInt("Level"), 1, 1);
            LevelUpAnim = true;
        }
            float previousExp = PlayerPrefs.GetFloat("Totalexp") - ((currentwave * 10) / (PlayerPrefs.GetInt("Level") + 1));
            GreenBar.transform.localScale = new Vector3((previousExp / 500) - PlayerPrefs.GetInt("Level"), 1, 1);
            SolidBar.transform.localScale = new Vector3((PlayerPrefs.GetFloat("Totalexp") / 500) - PlayerPrefs.GetInt("Level"), 1, 1);
            LevelUpAnim = true;
        
    }
    //instantiating meteorites, boss meteorites and aliens
    private void WaveSystem()
    {
        txtPopulation.text = Mathf.RoundToInt(population).ToString();
        txtReserves.text = Mathf.RoundToInt(reserves).ToString();
        wavetiming = Mathf.RoundToInt(maincamera.fieldOfView / 8);
        if (point < 0)
        {
            //yok oluş animasyonu
        }
        if (wave % 10 != 0)
        {
            wavetext.text = wave.ToString();
        }
        else
        {
            wavetext.text = "boss";
        }

        if (wave > currentwave)
        {
            if (wave >= 15 && wave%10 == 5 )
            {
                SendAlien();
            }
            SendMeteorite();
            currentwave++;
        }
        pointtext.text = point.ToString();
        point = int.Parse(pointtext.text);
    }
    void SendMeteorite()
    {
        wavepoint = wave * difficulty;
        for (; wavepoint > 0;)
        {
            int rnd3 = Random.Range(0, 3);
            int rnd = Random.Range(0, 2);
            int rnd2 = Random.Range(0, 2);
            float x = maincamera.fieldOfView / 5;
            float y = maincamera.fieldOfView / 5;
            #region meteor rotasyonu
            meteoriteposition = new Vector2(0, 0);
            if (rnd == 0)
            {
                meteoriteposition.x = Random.Range(-x, x);
            }
            else if (rnd == 1)
            {
                meteoriteposition.y = Random.Range(-y, y);
            }

            if (rnd == 0)
            {
                if (rnd2 == 0)
                    meteoriteposition.y = y;
                else if (rnd2 == 1)
                    meteoriteposition.y = -y;
            }
            else if (rnd == 1)
            {
                if (rnd2 == 0)
                    meteoriteposition.x = x;
                else if (rnd2 == 1)
                    meteoriteposition.x = -x;
            }
            #endregion
            meteorite.transform.position = meteoriteposition;
            meteorite.transform.rotation = rotation;
            if (wavetext.text == "boss")
            {
                wavepoint = 0;
                scmeteor.fullhp = (wave / 10) * 3;
                Instantiate(meteorite);
            }
            switch (rnd3)
            {
                case 0:
                    if (wavepoint >= 1)
                    {
                        scmeteor.fullhp = 1;
                        wavepoint -= 5;
                        Instantiate(meteorite);
                    }
                    break;
                case 1:
                    if (wavepoint >= 8)
                    {
                        scmeteor.fullhp = 2;
                        wavepoint -= 12;
                        Instantiate(meteorite);
                    }
                    break;
                case 2:
                    if (wavepoint >= 16)
                    {
                        scmeteor.fullhp = 3;
                        wavepoint -= 22;
                        Instantiate(meteorite);
                    }
                    break;
                case 3:
                    if (wavepoint >= 32)
                    {
                        scmeteor.fullhp = 4;
                        wavepoint -= 32;
                        Instantiate(meteorite);
                    }
                    break;
                case 4:
                    if (wavepoint >= 48)
                    {
                        scmeteor.fullhp = 5;
                        wavepoint -= 42;
                        Instantiate(meteorite);
                    }
                    break;
            }

        }
        StartCoroutine(TimingVoid());

    }
    void SendAlien()
    {
        SpaceShip.transform.position = -SpaceShip.transform.position;
        scship.fullhp = (wave/5)*2;
        Instantiate(SpaceShip);
    }
    IEnumerator TimingVoid()
    {
        int timing;

        for (timing = wavetiming; timing > 0; timing--)
        {
            timingtext.text = timing.ToString();
            yield return new WaitForSeconds(1);
        }
        timingtext.text = timing.ToString();
        EndofWave();
    }
    void EndofWave()
    {
        Score.text = currentwave.ToString();
        if (reserves > 0)
        {
            population += (population / popratio);
            point += Mathf.RoundToInt(population / 10);
            reserves -= population * 3 / consciousness;
        }
        wave++;
        if (damageRatio - repairRate > 0)
        {
            damageRatio -= repairRate;
            txtDamagerate.text = Mathf.RoundToInt(damageRatio).ToString();
        }
        else
        {
            damageRatio = 0;
            txtDamagerate.text = Mathf.RoundToInt(damageRatio).ToString();
        }
    }
}
