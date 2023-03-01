using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipscript : MonoBehaviour
{
    void Update()
    {
        this.transform.position += new Vector3(Time.deltaTime, 0, 0);
    }
}
