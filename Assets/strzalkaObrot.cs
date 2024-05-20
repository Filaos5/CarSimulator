using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzalkaObrot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var y =  transform.parent.rotation.eulerAngles.y;
        transform.localRotation = Quaternion.Inverse(transform.parent.rotation);
        transform.rotation = Quaternion.Euler(0.0f, y, 0.0f);
    }
}
