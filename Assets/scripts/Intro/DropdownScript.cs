using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownScript : MonoBehaviour
{
    public TMP_Dropdown dd;
    void Start()
    {
       int a = QualitySettings.GetQualityLevel();
        dd.value = a;
    }
}
