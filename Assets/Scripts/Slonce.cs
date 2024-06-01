using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slonce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(-0.1f * Time.timeScale, 0f, 0f);
        transform.Rotate(-0.02f * Time.timeScale, 0f, 0f);
        //transform.Rotate(-0.005f * Time.timeScale, 0f, 0f);
    }
}
