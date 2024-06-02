using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikonaSamochod : MonoBehaviour
{
    public GameObject kamera;
    public Camera minimap_kamera;
    public string nazwa_pojazdu;
    public int rodzaj_pojazdu;
    public GameObject mapa;
    public Camera mapa_kamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameManager gameManager = mapa.GetComponent<GameManager>();
        int wlmapa = gameManager.mapa_p;
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (wlmapa == 0)
        {
            transform.rotation = Quaternion.Euler(90.0f, minimap_kamera.transform.eulerAngles.y, 0.0f);
            if (rodzaj_pojazdu == 1 && nazwa_pojazdu == transform.parent.name)
            {
                transform.localScale = Vector3.zero;
            }
            else
            {
                transform.localScale = new Vector3(4f, 4f, 1f);
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            if (rodzaj_pojazdu == 1 && nazwa_pojazdu == transform.parent.name)
            {
                transform.localScale = Vector3.zero;
            }
            else
            {
                transform.localScale = new Vector3(4 + mapa_kamera.orthographicSize * 0.01f, 4 + mapa_kamera.orthographicSize * 0.01f, 1 + mapa_kamera.orthographicSize * 0.01f);
            }
        }
    }
}
