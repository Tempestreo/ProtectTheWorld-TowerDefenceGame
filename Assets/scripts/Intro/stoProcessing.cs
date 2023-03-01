using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class stoProcessing : MonoBehaviour
{
    public Camera denme;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(num());
    }
    IEnumerator num()
    {
        yield return new WaitForSeconds(1.5f);
        denme.gameObject.GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = false;
    }
}
