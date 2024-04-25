using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using System;
public class Kolo : MonoBehaviour
{
    public GameObject samochod; 
    private Quaternion aktualnaRotacja; // Zmienna przechowuj¹ca aktualn¹ rotacjê
    private Vector3 poprzedniaPozycja; // Poprzednia pozycja obiektu
    private float czasPoprzedniejPozycji; // Czas w momencie poprzedniej pozycji
    public float predkosc;
    float odleglosc;
    float czas;
    //public float stan =0;
    public float p;
    public float stan=0;
    public float kierunekRuchuStopnie;
    float aktualnaPozycjax;
    float aktualnaPozycjay;
    float aktualnaPozycjaz;
    float poprzedniaPozycjax;
    float poprzedniaPozycjay;
    float poprzedniaPozycjaz;
    public Transform obiektDoOdczytaniaRotacji;
    float r;
    public float rotacja;
    int do_przodu_do_tylu;
    
    private void OnCollisionEnter(Collision collision)
    {
        stan = 1;
        Debug.Log("Kontakt!");

    }
    private void OnCollisionStay(Collision collision)
    {
        // SprawdŸ, czy obiekt dotyka innego obiektu
        //isTouchingObject = true;
        //Debug.Log("Enter ");
        stan = 2;
        Debug.Log("Utrzymuje kontakt.");

    }


    private void OnCollisionExit(Collision collision)
    {
        // SprawdŸ, czy obiekt przesta³ dotykaæ innego obiektu
        //isTouchingObject = false;
        Debug.Log("Odbite.");
        stan = 0;
    }
    void Start()
    {
        // Pobierz pocz¹tkow¹ rotacjê obiektu
        aktualnaPozycjax = transform.position.x;
        aktualnaPozycjay = transform.position.y;
        aktualnaPozycjaz = transform.position.z;
        poprzedniaPozycjax = transform.position.x;
        poprzedniaPozycjay = transform.position.y;
        poprzedniaPozycjaz = transform.position.z;
        // Ustaw poprzedni¹ pozycjê na aktualn¹ pozycjê obiektu
        poprzedniaPozycja = transform.position;

        // Ustaw czas poprzedniej pozycji na aktualny czas
        czasPoprzedniejPozycji = Time.time;
    }
    void Update()
    {
     
        // Pobierz przesuniêcie w osi x i z
        //float przesuniecieX = Input.GetAxis("Horizontal");
        //float przesuniecieZ = Input.GetAxis("Vertical");

        // Oblicz kierunek ruchu obiektu w stopniach

    }
    private void FixedUpdate()
    {
        kierunekRuchuStopnie = Mathf.Atan2(transform.position.z - poprzedniaPozycjaz, transform.position.x - poprzedniaPozycjax) * Mathf.Rad2Deg;
        do_przodu_do_tylu = samochod.GetComponent<Jazda>().przod_tyl;
        // Wyœwietl kierunek ruchu w konsoli 
        //kierunek_a = obiektDoOdczytaniaRotacji.rotation.ToEulerAngles.
        // Wyœwietl kierunek ruchu w konsoli
        //Debug.Log("Kierunek ruchu obiektu w stopniach: " + kierunekRuchuStopnie);
        //transform.Rotate(Vector3.right * (odleglosc * 50));
        //transform.Rotate(Vector3.right * (-odleglosc * 50));
        // Oblicz prêdkoœæ jako stosunek odleg³oœci do czasu
        //predkosc = odleglosc / czas;
        odleglosc = Vector3.Distance(transform.position, poprzedniaPozycja);
        // Aktualizuj poprzedni¹ pozycjê i czas
        if (do_przodu_do_tylu == 0)
        {
            transform.Rotate(Vector3.right * (odleglosc * 80));
        }
        else
        {
            transform.Rotate(Vector3.right * (odleglosc * (-80)));

        }
        poprzedniaPozycja = transform.position;

    }
}

