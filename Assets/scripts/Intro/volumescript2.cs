using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class volumescript2 : MonoBehaviour
{
    Vignette vignette;
    Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        Volume vol = GetComponent<Volume>();
        vol.profile.TryGet<Vignette>(out vignette);
        StartCoroutine(num(vignette.intensity.value));
        vol.profile.TryGet<Bloom>(out bloom);
        StartCoroutine(num2(bloom.intensity.value));
    }
    IEnumerator num(float value)
    {
        for (; value > 0; value -= 0.05f)
        {
            vignette.intensity.value = value;
            yield return new WaitForSeconds(0.08f);
        }
    }
    IEnumerator num2(float value)
    {
        for (; value >= 0; value -= 100f)
        {
            bloom.intensity.value = value;
            yield return new WaitForSeconds(0.0085f);
        }
    }
}
