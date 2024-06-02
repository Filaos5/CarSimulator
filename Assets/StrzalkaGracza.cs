using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrzalkaGracza : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kamera;
    public string nazwa_pojazdu;
    public int rodzaj_pojazdu;
    public Camera mapa_kamera;
    void Start()
    {
        transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y + 110, kamera.transform.position.z);
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
        transform.localScale = new Vector3(50 + mapa_kamera.orthographicSize * 0.03f, 50 + mapa_kamera.orthographicSize * 0.03f, 1 + mapa_kamera.orthographicSize * 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y + 110, kamera.transform.position.z);
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
        transform.localScale = new Vector3(50 + mapa_kamera.orthographicSize * 0.03f, 50 + mapa_kamera.orthographicSize * 0.03f, 1 + mapa_kamera.orthographicSize * 0.03f);
    }
}
