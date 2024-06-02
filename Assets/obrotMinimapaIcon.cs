using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obrotMinimapaIcon : MonoBehaviour
{
    public Camera minimap_kamera;
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
        if (wlmapa == 0)
        {
            transform.rotation = Quaternion.Euler(90.0f, minimap_kamera.transform.eulerAngles.y, 0.0f);
            transform.localScale = new Vector3(8, 8, 4);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(16 + mapa_kamera.orthographicSize * 0.01f, 16 + mapa_kamera.orthographicSize * 0.01f, 8 + mapa_kamera.orthographicSize * 0.01f);
        }
    }
}
