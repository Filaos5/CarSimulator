using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obrotMinimapaIcon : MonoBehaviour
{
    public Camera minimap_kamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90.0f, minimap_kamera.transform.eulerAngles.y, 0.0f);
    }
}
