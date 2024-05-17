using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Wyscig5 : MonoBehaviour
{
    public GameObject samochod1;
    public GameObject samochod2;
    public GameObject samochod3;
    public GameObject samochod4;
    public GameObject samochod5;
    public GameObject game_manager;
    public bool dotykaCar = false;
    public int stan_wyscig = 0;
    public Camera mainCamera;
    public Transform objectToMove;
    public GameObject objectpole;
    public GameObject objectstrzalka;
    public GameObject objectcylinder;
    public string nazwa_samochodu;
    GameObject sam1;
    GameObject sam2;
    GameObject sam3;
    public TextMeshProUGUI textMeshPro;
    private float czasRozpoczecia;
    private float czasPrzejazdu;
    // Start is called before the first frame update
    private float[] pozycje_X = new float[45]; // Tablica float
    private float[] pozycje_Z = new float[45]; // Tablica float
    private void OnTriggerEnter(Collider other)
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        Kamera kamera = mainCameraObject.GetComponent<Kamera>();
        nazwa_samochodu = kamera.nazwa_samochodu;
        if (other.gameObject.name == nazwa_samochodu && stan_wyscig == 0)
        {
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Aby rozpocz¹æ wyœcig wciœnij E";
        }
        if (other.gameObject.name == nazwa_samochodu)
        {
            dotykaCar = true;
        }
        GameManager gameManager = game_manager.GetComponent<GameManager>();
        gameManager.numer_wyscigu = 5;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == nazwa_samochodu)
        {
            dotykaCar = false;
            textMeshPro.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        objectstrzalka.SetActive(false);
        objectcylinder.SetActive(false);
        textMeshPro.gameObject.SetActive(false);
        pozycje_X[0] = -1554;
        pozycje_Z[0] = 1395;
        pozycje_X[1] = -1050;
        pozycje_Z[1] = 1395;
        pozycje_X[2] = 115;
        pozycje_Z[2] = 1395;
        pozycje_X[3] = 538;
        pozycje_Z[3] = 1395;
        pozycje_X[4] = 955;
        pozycje_Z[4] = 1395;
        pozycje_X[5] = 1514;
        pozycje_Z[5] = 1395;
        pozycje_X[6] = -1554;
        pozycje_Z[6] = 825;
        pozycje_X[7] = -1050;
        pozycje_Z[7] = 825;
        pozycje_X[8] = -455;
        pozycje_Z[8] = 825;
        pozycje_X[9] = 115;
        pozycje_Z[9] = 825;
        pozycje_X[10] = 538;
        pozycje_Z[10] = 825;
        pozycje_X[11] = 955;
        pozycje_Z[11] = 825;
        pozycje_X[12] = 1514;
        pozycje_Z[12] = 825;
        pozycje_X[13] = -455;
        pozycje_Z[13] = 507;
        pozycje_X[14] = 115;
        pozycje_Z[14] = 507;
        pozycje_X[15] = 955;
        pozycje_Z[15] = 507;
        pozycje_X[16] = 1514;
        pozycje_Z[16] = 507;
        pozycje_X[17] = -1554;
        pozycje_Z[17] = 272;
        pozycje_X[18] = -1173;
        pozycje_Z[18] = 272;
        pozycje_X[19] = -1050;
        pozycje_Z[19] = 272;
        pozycje_X[20] = -455;
        pozycje_Z[20] = 272;
        pozycje_X[21] = 115;
        pozycje_Z[21] = 272;
        pozycje_X[22] = -1554;
        pozycje_Z[22] = 68;
        pozycje_X[23] = -1173;
        pozycje_Z[23] = 68;
        pozycje_X[24] = -455;
        pozycje_Z[24] = 68;
        pozycje_X[25] = -1173;
        pozycje_Z[25] = -270;
        pozycje_X[26] = -455;
        pozycje_Z[26] = -270;
        pozycje_X[27] = 115;
        pozycje_Z[27] = -270;
        pozycje_X[28] = 955;
        pozycje_Z[28] = -270;
        pozycje_X[29] = 1117;
        pozycje_Z[29] = -270;
        pozycje_X[30] = 1514;
        pozycje_Z[30] = -270;
        pozycje_X[31] = -455;
        pozycje_Z[31] = -964;
        pozycje_X[32] = 115;
        pozycje_Z[32] = -964;
        pozycje_X[33] = 1117;
        pozycje_Z[33] = -871;
        pozycje_X[34] = 1514;
        pozycje_Z[34] = -871;
        pozycje_X[35] = -520;
        pozycje_Z[35] = -2574;
        pozycje_X[36] = 30;
        pozycje_Z[36] = -2574;
        pozycje_X[37] = -1554;
        pozycje_Z[37] = -2893;
        pozycje_X[38] = -520;
        pozycje_Z[38] = -2893;
        pozycje_X[39] = 30;
        pozycje_Z[39] = -2893;
        pozycje_X[40] = 287;
        pozycje_Z[40] = -2893;
        pozycje_X[41] = 642;
        pozycje_Z[41] = -2893;
        pozycje_X[42] = 287;
        pozycje_Z[42] = -3338;
        pozycje_X[43] = 642;
        pozycje_Z[43] = -3338;
        pozycje_X[44] = 115;
        pozycje_Z[44] = -1400;
    }
    IEnumerator odliczanie()
    {
        Time.timeScale = 0f;
        textMeshPro.gameObject.SetActive(true);
        textMeshPro.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.text = "START!";
        Time.timeScale = 1f;
        czasRozpoczecia = Time.time;
        yield return new WaitForSecondsRealtime(3f);
        textMeshPro.gameObject.SetActive(false);
    }

    IEnumerator meta()
    {
        textMeshPro.gameObject.SetActive(true);
        // Wpisz tekst "jestem" do TextMeshPro
        textMeshPro.text = "Twój czas" + czasPrzejazdu + " s";
        yield return new WaitForSecondsRealtime(3f);
        textMeshPro.gameObject.SetActive(false);
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
            sam1 = Instantiate(samochod1, new Vector3(120f, 0f, -1350f), Quaternion.identity);
            sam2 = Instantiate(samochod2, new Vector3(130f, 0f, -1360f), Quaternion.identity);
            sam3 = Instantiate(samochod3, new Vector3(110f, 0f, -1370f), Quaternion.identity);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            StartCoroutine(odliczanie());
            objectpole.SetActive(false);
            objectstrzalka.SetActive(true);
            objectcylinder.SetActive(true);
            objectToMove.position = new Vector3(120f, 0f, 830f);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 1;
            dotykaCar = false;
        }

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
            Destroy(sam1);
            Destroy(sam2);
            Destroy(sam3);
            objectpole.SetActive(false);
            objectcylinder.SetActive(false);
            czasPrzejazdu = Time.time - czasRozpoczecia;
            StartCoroutine(meta());
            stan_wyscig = 0;
        }
        
    }

    
}
