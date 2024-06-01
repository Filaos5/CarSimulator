using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrzalkaGracza : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kamera;
    public string nazwa_pojazdu;
    public int rodzaj_pojazdu;
    void Start()
    {
        transform.position = kamera.transform.position;
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (rodzaj_pojazdu == 1)
        {
            GameObject obiekt = GameObject.Find(nazwa_pojazdu);
            transform.rotation = Quaternion.Euler(-90.0f, obiekt.transform.eulerAngles.y, -180.0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-90.0f, 0.0f, -180.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = kamera.transform.position;
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (rodzaj_pojazdu == 1)
        {
            GameObject obiekt = GameObject.Find(nazwa_pojazdu);
            transform.rotation = Quaternion.Euler(-90.0f, obiekt.transform.eulerAngles.y, -180.0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-90.0f, 0.0f, -180.0f);
        }
    }
}
