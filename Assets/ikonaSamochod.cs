using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikonaSamochod : MonoBehaviour
{
    public GameObject kamera;
    public Camera minimap_kamera;
    public string nazwa_pojazdu;
    public int rodzaj_pojazdu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90.0f, minimap_kamera.transform.eulerAngles.y, 0.0f);
        Kamera kamera_o = kamera.GetComponent<Kamera>();
        nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
        rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
        if (rodzaj_pojazdu == 1 && nazwa_pojazdu == transform.parent.name)
        {
            transform.localScale = Vector3.zero;
        }
        else
        {
            transform.localScale = new Vector3(4f, 4f, 1f);
        }
    }
}
