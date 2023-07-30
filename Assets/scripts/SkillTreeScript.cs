using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillTreeScript : MonoBehaviour
{
    public Sprite slowDownTime;
    public Sprite speedUpTime;
    public Button[,] Skills = new Button[6, 4];
    public GameObject pnlDescription;
    void Start()
    {
        this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Skills[i, j] = this.transform.GetChild(i + 1).GetChild(3 - j).GetComponent<Button>();
                Skills[i, j].interactable = false;
            }
        }       
        
        //adding skills into the array
        if (PlayerPrefs.GetInt("Resource") < 4)
        {
            Skills[0, PlayerPrefs.GetInt("Resource")].interactable = true;
        }
        if (PlayerPrefs.GetInt("Population") < 4)
        {
            Skills[1, PlayerPrefs.GetInt("Population")].interactable = true;
        }
        if (PlayerPrefs.GetInt("Gold") < 4)
        {
            Skills[2, PlayerPrefs.GetInt("Gold")].interactable = true;
        }
        if (PlayerPrefs.GetInt("Protector") < 4)
        {
            Skills[3, PlayerPrefs.GetInt("Protector")].interactable = true;
        }
        if (PlayerPrefs.GetInt("Repair") < 4)
        {
            Skills[4, PlayerPrefs.GetInt("Repair")].interactable = true;
        }
        if (PlayerPrefs.GetInt("Rocket") < 4)
        {
            Skills[5, PlayerPrefs.GetInt("Rocket")].interactable = true;
        }
    }
    private void Update()
    {
        //if the last skills (speeduptime and slowdowntime) are ready, then change their interactableness.  
        if (PlayerPrefs.GetInt("Resource") == 4 && PlayerPrefs.GetInt("Population") == 4 && PlayerPrefs.GetInt("Gold") == 4 && !PlayerPrefs.HasKey("Speeduptime"))
        {
            this.transform.GetChild(7).GetComponent<Button>().interactable = true;
        }
        else
        {
            this.transform.GetChild(7).GetComponent<Button>().interactable = false;

        }
        if (PlayerPrefs.GetInt("Protector") == 4 && PlayerPrefs.GetInt("Repair") == 4 && PlayerPrefs.GetInt("Rocket") == 4 && !PlayerPrefs.HasKey("Slowdowntime"))
        {
            this.transform.GetChild(8).GetComponent<Button>().interactable = true;
        }
        else
        {
            this.transform.GetChild(8).GetComponent<Button>().interactable = false;
        }
    }
    public void ButtonEvent()
    {
        //Upgrading skills
        GameObject Button = EventSystem.current.currentSelectedGameObject;
        if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Resource") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[0, PlayerPrefs.GetInt("Resource")].interactable = false;
            PlayerPrefs.SetInt("Resource", PlayerPrefs.GetInt("Resource") + 1);
            if (PlayerPrefs.GetInt("Resource") < 4)
            {
                Skills[0, PlayerPrefs.GetInt("Resource")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Population") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[1, PlayerPrefs.GetInt("Population")].interactable = false;
            PlayerPrefs.SetInt("Population", PlayerPrefs.GetInt("Population") + 1);
            if (PlayerPrefs.GetInt("Population") < 4)
            {
                Skills[1, PlayerPrefs.GetInt("Population")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Gold") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[2, PlayerPrefs.GetInt("Gold")].interactable = false;
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1);
            if (PlayerPrefs.GetInt("Gold") < 4)
            {
                Skills[2, PlayerPrefs.GetInt("Gold")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Protector") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[3, PlayerPrefs.GetInt("Protector")].interactable = false;
            PlayerPrefs.SetInt("Protector", PlayerPrefs.GetInt("Protector") + 1);
            if (PlayerPrefs.GetInt("Protector") < 4)
            {
                Skills[3, PlayerPrefs.GetInt("Protector")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Repair") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[4, PlayerPrefs.GetInt("Repair")].interactable = false;
            PlayerPrefs.SetInt("Repair", PlayerPrefs.GetInt("Repair") + 1);
            if (PlayerPrefs.GetInt("Repair") < 4)
            {
                Skills[4, PlayerPrefs.GetInt("Repair")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Rocket") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            Skills[5, PlayerPrefs.GetInt("Rocket")].interactable = false;
            PlayerPrefs.SetInt("Rocket", PlayerPrefs.GetInt("Rocket") + 1);
            if (PlayerPrefs.GetInt("Rocket") < 4)
            {
                Skills[5, PlayerPrefs.GetInt("Rocket")].interactable = true;
            }
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Slowdowntime") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            this.transform.GetChild(7).GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("Slowdowntime", 0);
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
            PlayerPrefs.SetInt("Slowesttime", 0);
        }
        else if (Button.transform.GetChild(0).GetComponent<Text>().text.EndsWith("Speeduptime") && PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints") > 0)
        {
            PlayerPrefs.SetInt("Usedskillpoints", PlayerPrefs.GetInt("Usedskillpoints") + 1);
            this.transform.GetChild(8).GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("Speeduptime", 0);
            this.transform.GetChild(9).GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetInt("Level") - PlayerPrefs.GetInt("Usedskillpoints")).ToString();
            PlayerPrefs.SetInt("Fastesttime", 2);
        }
        pnlDescription.SetActive(false);
    }
    //upgrade information pannels
    public void ButtonResource()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[0,0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase resource per resource level and decrease resource usage per person.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Resource";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void ButtonPopulation()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[1, 0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase population growth rate per science level and decrease resource usage per person.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Population";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void ButtonGold()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[2, 0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase gold income per destroyed meteorite.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Gold";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void ButtonProtector()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[3, 0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase protector health point by 1";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Protector";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void ButtonRepair()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[4, 0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase repair rate per round.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Repair";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void ButtonRocket()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = Skills[5, 0].GetComponent<Image>().sprite;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will increase rocket fire rate per second.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Upgrade Rocket";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);
        
        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void SpeedUpTime()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = speedUpTime;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will let you speed up the time.";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Unlock Slowdowntime";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);

        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
    public void SlowDownTime()
    {
        pnlDescription.transform.GetChild(0).GetComponent<Image>().sprite = slowDownTime;
        pnlDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "This skill will let you slow down the time";
        pnlDescription.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Unlock Speeduptime";
        pnlDescription.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ButtonEvent);

        if (pnlDescription.activeSelf == false)
        {
            pnlDescription.SetActive(true);
        }
    }
}
