using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Wyscig1 : MonoBehaviour
{
    public GameObject samochod1;
    public GameObject samochod2;
    public GameObject samochod3;
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
    private float[] pozycje_X = new float[45]; // Tablica float
    private float[] pozycje_Z = new float[45]; // Tablica float
    private GameObject[] obiektyPoziomu;
    private GameObject[] obiektyZnaczniki;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        Kamera kamera = mainCameraObject.GetComponent<Kamera>();
        GameManager gameManager = game_manager.GetComponent<GameManager>();
        nazwa_samochodu = kamera.nazwa_samochodu;
        if (other.gameObject.name == nazwa_samochodu && stan_wyscig == 0 && gameManager.wyscig_stan==0)
        {
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.text = "Aby rozpocz¹æ wyœcig wciœnij E";
        }
        if (other.gameObject.name == nazwa_samochodu)
        {
            dotykaCar = true;
        }
        
        gameManager.numer_wyscigu = 1;
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

    private void PokazPoziom(GameObject[] obiektyPoziom)
    {
        //GameObject[] obiektyPoziomu = GameObject.FindGameObjectsWithTag(tagPoziomu);
        foreach (GameObject obiekt in obiektyPoziom)
        {
            obiekt.SetActive(true);
        }
    }
    private void UkryjPoziom(GameObject[] obiektyPoziom)
    {
        //GameObject[] obiektyPoziomu = GameObject.FindGameObjectsWithTag(tagPoziomu);
        foreach (GameObject obiekt in obiektyPoziom)
        {
            obiekt.SetActive(false);
        }
    }
    void Start()
    {
        objectstrzalka.SetActive(false);
        objectcylinder.SetActive(false);
        textMeshPro.gameObject.SetActive(false);
        obiektyPoziomu = GameObject.FindGameObjectsWithTag("Level1");
        obiektyZnaczniki = GameObject.FindGameObjectsWithTag("Znacznik");
        UkryjPoziom(obiektyPoziomu);

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
        yield return new WaitForSecondsRealtime(1f);
        //Time.timeScale = 1f;
        czasRozpoczecia = Time.time;
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
            GameManager gameManager = game_manager.GetComponent<GameManager>();
            if (gameManager.wyscig_stan == 0)
            {
                gameManager.wyscig_stan = 1;
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
                //StartCoroutine(odliczanie());
                //objectpole.SetActive(false);
                objectstrzalka.SetActive(true);
                objectcylinder.SetActive(true);
                objectToMove.position = new Vector3(120f, 0f, 830f);
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                stan_wyscig = 1;
                dotykaCar = false;
                czasRozpoczecia = Time.time;
                PokazPoziom(obiektyPoziomu);
                UkryjPoziom(obiektyZnaczniki);
            }
            
            
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
            //objectpole.SetActive(true);
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
            //objectpole.SetActive(true);
            objectcylinder.SetActive(false);
            czasPrzejazdu = Time.time - czasRozpoczecia;
            //StartCoroutine(meta());
            stan_wyscig = 0;
            GameManager gameManager = game_manager.GetComponent<GameManager>();
            gameManager.wyscig_stan = 4;
            textMeshPro.gameObject.SetActive(true);
            // Wpisz tekst "jestem" do TextMeshPro
            textMeshPro.text = "Twój czas" + czasPrzejazdu + " sekund, SPACJA zakoñcz";
            UkryjPoziom(obiektyPoziomu);
            PokazPoziom(obiektyZnaczniki);
        }
        
    }

    
}
