using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoadment : MonoBehaviour
{
    public GameObject pnlEscape; 
    public GameObject pnlOptions;
    public GameObject pnlSkillTree;
    public TextMeshProUGUI currentTimeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // player prefs for freeze and speedup time skills in skilltree
        if (!PlayerPrefs.HasKey("Slowesttime"))
        {
            PlayerPrefs.SetInt("Slowesttime", 1);
        }
        if (!PlayerPrefs.HasKey("Fastesttime"))
        {
            PlayerPrefs.SetInt("Fastesttime", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pnlEscape.SetActive(true);

        }
    }

    #region Restart
    public void RestartGame()
    {
        SceneManager.LoadScene("Game Scene"); 
        Time.timeScale = 1;
    }
    public void PanelSkillTree()
    {
        pnlSkillTree.SetActive(true);
    }
    public void PanelOptions()
    {
        pnlOptions.SetActive(true);
    }
    #endregion

    public void SpeedUpTime()
    {
        if (Time.timeScale < PlayerPrefs.GetInt("Fastesttime"))
        {
            Time.timeScale += 0.5f;
            currentTimeSpeed.text = Time.timeScale.ToString();
        }
    }
    public void SlowDownTime()
    {
        if (Time.timeScale > PlayerPrefs.GetInt("Slowesttime"))
        {
            Time.timeScale -= 0.5f;
            currentTimeSpeed.text = Time.timeScale.ToString();
        }
    }
    public void pnlSetFalse()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.name == "PnlEscape")
        {
            Time.timeScale = 1;
        }
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
        
    }
    public void loadgamescene()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void loadMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }
    public void loadNextPlanetScene()
    {
        SceneManager.LoadScene("Next Planet");
    }
    public void loadExit()
    {
        Application.Quit();
    }
}
