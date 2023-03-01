using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneLoaderScript : MonoBehaviour
{
    SceneLoadment scScene;

    void Start()
    {
        scScene = FindObjectOfType<SceneLoadment>();
        scScene.loadMenuScene();
    }
    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
