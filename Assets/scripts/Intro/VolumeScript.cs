using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeScript : MonoBehaviour
{

    Vignette vignette;
    Bloom bloom;
    public void changeintensity()
    {
        Volume vol = GetComponent<Volume>();
        vol.profile.TryGet<Vignette>(out vignette);
        StartCoroutine(num(vignette.intensity.value));
        vol.profile.TryGet<Bloom>(out bloom);
        StartCoroutine(num2(bloom.intensity.value));

    }
    IEnumerator num(float value)
    {
        for (; value < 1; value += 0.05f)
        {
            vignette.intensity.value = value;
            yield return new WaitForSeconds(0.08f);
        }
    }
    IEnumerator num2(float value)
    {
        for (; value < 10000; value += 10f)
        {
            bloom.intensity.value = value;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
