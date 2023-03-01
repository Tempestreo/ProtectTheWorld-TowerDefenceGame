using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollscript : MonoBehaviour
{
    // Update is called once per frame
    public float paralx = 2f;
    MeshRenderer mr;
    Material mat;
    Vector2 offset;
    private void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        Vector2 offset = new Vector2(mat.mainTextureOffset.x + Random.Range(0, 5f), mat.mainTextureOffset.y + Random.Range(0, 5f));
    }
    void Update()
    {
        offset.x = transform.position.x / transform.localScale.x / paralx;
        mat.mainTextureOffset = offset;
    }
}
