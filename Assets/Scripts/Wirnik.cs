using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wirnik : MonoBehaviour
{
    public GameObject kamera;
    public GameObject gameObject;
    public string nazwa_helikoptera;
    int rodzaj_pojazdu;
    //char l1;
   // char l2;
    
    // Start is called before the first frame update
    void Start()
    {
        string nazwa = this.name;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_helikoptera = kamera_o.nazwa_helikoptera;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        //l1 = this.name[11];
        if (rodzaj_pojazdu == 2 && (this.name[11]== nazwa_helikoptera[11]))
        {
            transform.Rotate(0, 27, 0);
        }

    }
}
