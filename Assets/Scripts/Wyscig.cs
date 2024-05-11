using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Wyscig : MonoBehaviour
{
    public GameObject samochod1;
    public GameObject samochod2;
    public GameObject samochod3;
    public bool dotykaCar = false;
    public int stan_wyscig = 0;
    public Camera mainCamera;
    public Transform objectToMove;
    public GameObject objectpole;
    public GameObject objectstrzalka;
    public GameObject objectcylinder;
    public string nazwa_samochodu;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Auto1"))
        {
            dotykaCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Auto1"))
        {
            dotykaCar = false;
        }
    }
    void Start()
    {
        objectstrzalka.SetActive(false);
        objectcylinder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && dotykaCar == true && stan_wyscig==0)
        {
            
            GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
            Kamera kamera = mainCameraObject.GetComponent<Kamera>();
            nazwa_samochodu = kamera.nazwa_samochodu;
            GameObject obj = GameObject.Find(nazwa_samochodu);
            // Ustaw rotacjê obiektu na 0
            obj.transform.rotation = Quaternion.identity;
            Instantiate(samochod1, new Vector3(120f, 0f, -1350f), Quaternion.identity);
            Instantiate(samochod2, new Vector3(130f, 0f, -1360f), Quaternion.identity);
            Instantiate(samochod3, new Vector3(110f, 0f, -1370f), Quaternion.identity);
            objectpole.SetActive(false);
            objectstrzalka.SetActive(true);
            objectcylinder.SetActive(true);
            objectToMove.position = new Vector3(120f, 0f, 830f);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 1;
            dotykaCar = false;
        }
        /*
        floatArray_X[0] = 120;
        floatArray_X[1] = 960;
        floatArray_X[2] = 960;
        floatArray_X[3] = 120;
        floatArray_X[4] = 120;
        floatArray_Z[0] = 830;
        floatArray_Z[1] = 830;
        floatArray_Z[2] = -260;
        floatArray_Z[3] = -260;
        floatArray_Z[4] = -1400;
        */

        if (dotykaCar == true && stan_wyscig == 1)
        {
            objectToMove.position = new Vector3(960f, 0f, 830f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 2;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 2)
        {
            objectToMove.position = new Vector3(960f, 0f, -260f);
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            stan_wyscig = 3;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 3)
        {
            objectToMove.position = new Vector3(120f, 0f, -260f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 4;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 4)
        {
            objectToMove.position = new Vector3(120f, 0f, -1385f);
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            objectstrzalka.SetActive(false);
            objectpole.SetActive(true);
            stan_wyscig = 5;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 5)
        {   
            //GameObject obiektDoZniszczenia = GameObject.Find(samochod1);
            //Destroy(obiektDoZniszczenia);
            //Destroy(samochod1);
            //Destroy(samochod2);
            //Destroy(samochod3);
            objectpole.SetActive(false);
            objectcylinder.SetActive(false);

        }
        
    }

    
}
