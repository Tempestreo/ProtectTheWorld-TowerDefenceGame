using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    #region variables
    bool isEnough;
    float rangesize;
    float ratio = 3.5f;
    public int point;
    public int cost;
    public int lvlsize = 1, lvlscience = 1, lvlrange = 1, lvlrate = 1, lvldamage = 1, lvlcost = 1, lvlrepair = 1;
    public Text txtPoint;
    public TextMeshProUGUI txtInformation;
    public GameObject range;
    Camera maincamera;
    WaveManager scwave;
    Worldscript scworld;
    Launcher sclauncher;
    #endregion
    #region buttons
    //redbuttons
    public GameObject pnlRocket;
    public GameObject pnlUpgrade;
    public GameObject pnlWorld;
    //levelbuttons
    public GameObject btnRange;
    public GameObject btnCost;
    public GameObject btnDamage;
    public GameObject btnRate;
    //worldbuttons
    public GameObject btnReserves;
    public GameObject btnSize;
    public GameObject btnConsciousness;
    public GameObject btnScience;
    //Techbuttons
    public GameObject btnRepair;
    public GameObject btnFleet;
    #endregion
    private void Start()
    {
        #region components
        scworld = FindObjectOfType<Worldscript>();
        scwave = FindObjectOfType<WaveManager>();
        sclauncher = FindObjectOfType<Launcher>();
        maincamera = Camera.FindObjectOfType<Camera>();
        #endregion
        isEnough = false;

        // if lvlscience less than three, dont let player to interact with button
        if (lvlscience < 3)
        {
            btnSize.GetComponent<Button>().interactable = false;
        }
        else
        {
            btnSize.GetComponent<Button>().interactable = true;
        }
    }
    #region level-upgrade-worldbutton
    public void RocketButon()
    {
        pnlWorld.SetActive(false);
        pnlUpgrade.SetActive(false);
        pnlRocket.SetActive(true);
    }
    public void UpgradeButon()
    {
        pnlWorld.SetActive(false);
        pnlRocket.SetActive(false);
        pnlUpgrade.SetActive(true);
    }
    public void WorldButon()
    {
        pnlUpgrade.SetActive(false);
        pnlRocket.SetActive(false);
        pnlWorld.SetActive(true);
    }
    #endregion
    public void RangeButon()
    {
        if (lvlrange > (3 * lvlsize))
        {
            txtInformation.text = "Not enough *Size* level.\n Upgrade *Size* to upgrade *Range*";
            return;
        }
        else
        {
            ManageButtons(btnRange);
            if (isEnough)
            {
                lvlrange += 1;
                rangesize = (maincamera.fieldOfView / 20);
                maincamera.fieldOfView += (rangesize);
                range.transform.localScale += new Vector3(rangesize, rangesize, 0);
                isEnough = false;
            }
        }
    }
    public void CostButon()
    {
        ManageButtons(btnCost);
        if (isEnough)
        {
            lvlcost += 1;
            cost = Mathf.RoundToInt((lvlrange + lvlrange + lvldamage) / (7 * lvlcost));
            isEnough = false;
        }
    }
    public void DamageButon()
    {
        ManageButtons(btnDamage);
        if (isEnough)
        {
            lvldamage += 1;
            sclauncher.damage += 1;
            isEnough = false;
        }
    }
    public void RateButon()
    {

        ManageButtons(btnRate);
        if (isEnough)
        {
            lvlrate += 1;
            sclauncher.rate -= (sclauncher.rate / (ratio+0.5f)) + (PlayerPrefs.GetInt("Rocket") * 0.05f);
            isEnough = false;
        }
    }
    public void ReserveButon()
    {
        ManageButtons(btnReserves);
        if (isEnough)
        {
            scwave.reserves += (int.Parse(btnReserves.GetComponentInChildren<Text>().text) * 50) + (PlayerPrefs.GetInt("Resource") * 30);
            isEnough = false;
        }
    }
    public void SizeButon()
    {
        ManageButtons(btnSize);
        if (isEnough)
        {
            lvlsize += 1;
            scworld.gameObject.transform.localScale += new Vector3(range.transform.localScale.x / 10, range.transform.localScale.x / 10, 0);
            isEnough = false;
        }
    }
    public void ConsciousnessButon()
    {
        ManageButtons(btnConsciousness);
        if (isEnough)
        {
            scwave.consciousness += 0.1f + (PlayerPrefs.GetInt("Resource") * 0.1f) + (PlayerPrefs.GetInt("Population") * 0.1f);
            isEnough = false;
        }
    }
    public void RepairButon()
    {
        if (lvlrepair < (3 * lvlscience))
        {
            ManageButtons(btnRepair);
            if (isEnough)
            {
                lvlrepair++;
                scwave.repairRate *= 1.30f + (PlayerPrefs.GetInt("Repair")*0.2f);
                isEnough = false;
            }
        }
        else
        {
            txtInformation.text = "Not enough *Science* \n level to upgrade *Repair*";
            return;
        }
    }
    public void FlightButon()
    {
        ManageButtons(btnFleet);
        if (isEnough)
        {
            scworld.protectorcount++;
            isEnough = false;
        }

    }
    public void ScienceButon()
    {
        ManageButtons(btnScience);
        if (isEnough)
        {
            lvlscience += 1;
            scwave.popratio -= 0.4f + (PlayerPrefs.GetInt("Population") * 0.3f);
            if (lvlscience < 3)
            {
                btnSize.GetComponent<Button>().interactable = false;
            }
            else
            {
                btnSize.GetComponent<Button>().interactable = true;
            }
            isEnough = false;
        }
    }
    //if the player has enough point, let the player to level up attributes
    private void ManageButtons(GameObject button)
    {
        point = int.Parse(txtPoint.text);
        int needed = int.Parse(button.GetComponentInChildren<Text>().text);
        if (point >= needed)
        {
            isEnough = true;
            point -= needed;
            scwave.point = point;
            button.GetComponentInChildren<Text>().text = (needed + needed).ToString();
        }
        else
        {
            txtInformation.text = "Not enough gold";
        }
    }

}
