using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzalka : MonoBehaviour
{
    public int d=0;
    public Vector3 scaleIncrement = new Vector3(0.2f, 0.05f, 0.0667f);
    public float skala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
     private void FixedUpdate()
     {
         skala = transform.localScale.x;
         if (transform.localScale.x > 40)
         {
             d = 1;
         }
         if (transform.localScale.x < 20)
         {
             d = 0;
         }
         if (d == 0)
         {
             transform.localScale += new Vector3(0.2f, 0.05f, 0.0667f);
         }
         if (d == 1)
         {
             transform.localScale -= new Vector3(0.2f, 0.05f, 0.0667f);
         }
         //transform.Rotate(-1, 1f, 2f);
     }
    
}
