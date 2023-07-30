using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour
{
    //the logo that appears at the start of the game
    void Start()
    {
        Invoke("NextScene", 3);
    }
    private void FixedUpdate()
    {
        this.transform.position += new Vector3(0,-1.5f,0);
    }
    void NextScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
