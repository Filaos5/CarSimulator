using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzalka_minimapa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kamera;
    public string nazwa_pojazdu;
    public int rodzaj_pojazdu;
    public Camera minimap_kamera;
    void Start()
    {
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (rodzaj_pojazdu > 0)
        {
            GameObject obiekt = GameObject.Find(nazwa_pojazdu);
            Jazda jazdao = obiekt.GetComponent<Jazda>();
            minimap_kamera.orthographicSize = 120 + jazdao.speed * 1.2f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -obiekt.transform.eulerAngles.y + minimap_kamera.transform.eulerAngles.y);
        }
        else
        {
            minimap_kamera.orthographicSize = 120;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (rodzaj_pojazdu > 0)
        {
            GameObject obiekt = GameObject.Find(nazwa_pojazdu);
            Jazda jazdao = obiekt.GetComponent<Jazda>();
            minimap_kamera.orthographicSize = 120 + jazdao.speed * 1.2f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -obiekt.transform.eulerAngles.y + minimap_kamera.transform.eulerAngles.y);
        }
        else
        {
            minimap_kamera.orthographicSize = 120;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
