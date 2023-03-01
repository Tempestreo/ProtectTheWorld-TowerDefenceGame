using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthscript : MonoBehaviour 
{ 
    Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        rotation = this.transform.rotation;
        rotation.z += 0.02f*Time.deltaTime;
        this.transform.rotation = rotation;


    }
}
