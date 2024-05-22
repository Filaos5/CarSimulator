using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Wyscig4 : MonoBehaviour
{
    public GameObject samochod1;
    public GameObject samochod2;
    public GameObject samochod3;
    public GameObject samochod4;
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
    GameObject sam4;
    public TextMeshProUGUI textMeshPro;
    private float czasRozpoczecia;
    private float czasPrzejazdu;
    // Start is called before the first frame update
    private float[] pozycje_X = new float[45]; // Tablica float
    private float[] pozycje_Z = new float[45]; // Tablica float
    private GameObject[] obiektyPoziomu;
    private void OnTriggerEnter(Collider other)
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        Kamera kamera = mainCameraObject.GetComponent<Kamera>();
        GameManager gameManager = game_manager.GetComponent<GameManager>();
        nazwa_samochodu = kamera.nazwa_samochodu;
        if (other.gameObject.name == nazwa_samochodu && stan_wyscig == 0 && gameManager.wyscig_stan == 0)
        {
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Aby rozpocz�� wy�cig wci�nij E";
        }
        if (other.gameObject.name == nazwa_samochodu && gameManager.wyscig_stan == 0)
        {
            dotykaCar = true;
        }

        gameManager.numer_wyscigu = 4;
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager gameManager = game_manager.GetComponent<GameManager>();
        if (other.gameObject.name == nazwa_samochodu && gameManager.wyscig_stan == 0)
        {
            dotykaCar = false;
            textMeshPro.gameObject.SetActive(false);
        }
    }

    private void PokazPoziom()
    {
        //GameObject[] obiektyPoziomu = GameObject.FindGameObjectsWithTag(tagPoziomu);
        foreach (GameObject obiekt in obiektyPoziomu)
        {
            obiekt.SetActive(true);
        }
    }
    private void UkryjPoziom()
    {
        //GameObject[] obiektyPoziomu = GameObject.FindGameObjectsWithTag(tagPoziomu);
        foreach (GameObject obiekt in obiektyPoziomu)
        {
            obiekt.SetActive(false);
        }
    }
    void Start()
    {
        objectstrzalka.SetActive(false);
        objectcylinder.SetActive(false);
        textMeshPro.gameObject.SetActive(false);
        obiektyPoziomu = GameObject.FindGameObjectsWithTag("Level4");
        UkryjPoziom();
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
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        czasRozpoczecia = Time.time;
        textMeshPro.gameObject.SetActive(false);
    }

    IEnumerator meta()
    {
        textMeshPro.gameObject.SetActive(true);
        // Wpisz tekst "jestem" do TextMeshPro
        textMeshPro.text = "Tw�j czas" + czasPrzejazdu + " s";
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
            // Ustaw rotacj� obiektu na 0
            obj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            sam1 = Instantiate(samochod1, new Vector3(-1060f, 0f, -2610f), Quaternion.identity);
            sam2 = Instantiate(samochod2, new Vector3(-1050f, 0f, -2605f), Quaternion.identity);
            sam3 = Instantiate(samochod3, new Vector3(-1040f, 0f, -2615f), Quaternion.identity);
            sam4 = Instantiate(samochod4, new Vector3(-1030f, 0f, -2610f), Quaternion.identity);
            sam1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            sam2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            sam3.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            sam4.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            StartCoroutine(odliczanie());
            objectpole.SetActive(false);
            objectstrzalka.SetActive(true);
            objectcylinder.SetActive(true);
            objectToMove.position = new Vector3(pozycje_X[35], 0f, -2610);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 1;
            dotykaCar = false;
            czasRozpoczecia = Time.time;
            PokazPoziom();
            //{ 35, 38, 37, 0, 1, 7, 9, 2, 4, 28, 30, 16, 14, 21, 20 };
        }
        if (dotykaCar == true && stan_wyscig == 1)
        {
            objectToMove.position = new Vector3(pozycje_X[38], 0f, pozycje_Z[38]);
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            stan_wyscig = 2;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 2)
        {
            objectToMove.position = new Vector3(pozycje_X[37], 20f, pozycje_Z[37]);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            stan_wyscig = 3;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 3)
        {
            objectToMove.position = new Vector3(pozycje_X[0], 0f, pozycje_Z[0]);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 4;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 4)
        {
            objectToMove.position = new Vector3(pozycje_X[1], 0f, pozycje_Z[1]);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 5;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 5)
        {
            objectToMove.position = new Vector3(pozycje_X[7], 0f, pozycje_Z[7]);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 6;
            dotykaCar = false;
        }
        //{ 35, 38, 37, 0, 1, 7, 9, 2, 4, 28, 30, 16, 14, 21, 20 };
        if (dotykaCar == true && stan_wyscig == 6)
        {
            objectToMove.position = new Vector3(pozycje_X[9], 0f, pozycje_Z[9]);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            stan_wyscig = 7;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 7)
        {
            objectToMove.position = new Vector3(pozycje_X[2], 0f, pozycje_Z[2]);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 8;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 8)
        {
            objectToMove.position = new Vector3(pozycje_X[4], 0f, pozycje_Z[4]);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 9;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 9)
        {
            objectToMove.position = new Vector3(pozycje_X[28], 0f, pozycje_Z[28]);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            stan_wyscig = 10;
            dotykaCar = false;
        }
        //{ 35, 38, 37, 0, 1, 7, 9, 2, 4, 28, 30, 16, 14, 21, 20 };
        if (dotykaCar == true && stan_wyscig == 10)
        {
            objectToMove.position = new Vector3(pozycje_X[30], 0f, pozycje_Z[30]);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            stan_wyscig = 11;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 11)
        {
            objectToMove.position = new Vector3(pozycje_X[16], 0f, pozycje_Z[16]);
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            stan_wyscig = 12;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 12)
        {
            objectToMove.position = new Vector3(pozycje_X[14], 0f, pozycje_Z[14]);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            stan_wyscig = 13;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 13)
        {
            objectToMove.position = new Vector3(pozycje_X[21], 0f, pozycje_Z[21]);
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            stan_wyscig = 14;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 14)
        {
            objectToMove.position = new Vector3(pozycje_X[20], 0f, pozycje_Z[20]);
            objectstrzalka.SetActive(false);
            //objectpole.SetActive(true);
            stan_wyscig = 15;
            dotykaCar = false;
        }
        if (dotykaCar == true && stan_wyscig == 15)
        {
            Destroy(sam1);
            Destroy(sam2);
            Destroy(sam3);
            Destroy(sam4);
            objectpole.SetActive(true);
            objectcylinder.SetActive(false);
            czasPrzejazdu = Time.time - czasRozpoczecia;
            stan_wyscig = 0;
            GameManager gameManager = game_manager.GetComponent<GameManager>();
            gameManager.wyscig_stan = 4;
            textMeshPro.gameObject.SetActive(true);
            // Wpisz tekst "jestem" do TextMeshPro
            textMeshPro.text = "Tw�j czas" + czasPrzejazdu + " sekund, SPACJA zako�cz";
            objectToMove.position = new Vector3(-1070f, 0f, -2610f);
            UkryjPoziom();
        }

    }

    
}
