using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region singleton GameManager

    //singleton methods
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        SingletonThisGameObject();
    }
    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    private void Start()
    {
        //store permanent values
        if (PlayerPrefs.HasKey("Usedskillpoints") == false)
        {
            PlayerPrefs.SetInt("Usedskillpoints", 0);
        }
        if (PlayerPrefs.HasKey("Totalexp") == false)
        {
            PlayerPrefs.SetFloat("Totalexp", 0);
        }
        if (PlayerPrefs.HasKey("Bestscore") == false)
        {
            PlayerPrefs.SetInt("Bestscore", 0);
        }
        if (PlayerPrefs.HasKey("Level") == false)
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        if (PlayerPrefs.HasKey("Resource") == false)
        {
            PlayerPrefs.SetInt("Resource", 0);
        }
        if (PlayerPrefs.HasKey("Population") == false)
        {
            PlayerPrefs.SetInt("Population", 0);
        }
        if (PlayerPrefs.HasKey("Gold") == false)
        {
            PlayerPrefs.SetInt("Gold", 0);
        }
        if (PlayerPrefs.HasKey("Protector") == false)
        {
            PlayerPrefs.SetInt("Protector", 0);
        }
        if (PlayerPrefs.HasKey("Repair") == false)
        {
            PlayerPrefs.SetInt("Repair", 0);
        }
        if (PlayerPrefs.HasKey("Rocket") == false)
        {
            PlayerPrefs.SetInt("Rocket", 0);
        }
    }
}
