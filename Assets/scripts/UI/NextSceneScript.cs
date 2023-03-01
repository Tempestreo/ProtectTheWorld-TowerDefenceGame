using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(ClosePanel());
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
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
