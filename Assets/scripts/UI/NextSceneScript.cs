using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSceneScript : MonoBehaviour
{
    void Start()
    {
        //the black panel that appears(and disappers in seconds) when the scene change
       StartCoroutine(ClosePanel());
        Destroy(this.gameObject, 2);
    }

    void Update()
    {
        
    }
    IEnumerator ClosePanel()
    {
        for (; 0 < this.transform.GetComponent<Image>().color.a; this.transform.GetComponent<Image>().color -= new Color(0, 0, 0, 0.05f))
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
