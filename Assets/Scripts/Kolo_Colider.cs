using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolo_Colider : MonoBehaviour
{
    public float stan = 0;
    public float ilosc_k = 0;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        stan = 1;
        ilosc_k = ilosc_k + 1;
        Debug.Log("Kontakt!");

    }
    private void OnCollisionStay(Collision collision)
    {
        // Sprawd�, czy obiekt dotyka innego obiektu
        //isTouchingObject = true;
        //Debug.Log("Enter ");
        stan = 1;
        Debug.Log("Utrzymuje kontakt.");

        // Pobierz kierunek zderzenia
        //Vector3 collisionDirection = collision.contacts[0].normal;

        // Pobierz kierunek przemieszczenia obiektu
        //Vector3 objectDirection = transform.forward;

        // Oblicz k�t zderzenia mi�dzy obiektami
        //float collisionAngle = Vector3.Angle(collisionDirection, objectDirection);

        // Wy�wietl wynik
        //Debug.Log("K�t zderzenia: " + collisionAngle + " stopni.");
    }


    private void OnCollisionExit(Collision collision)
    {
        // Sprawd�, czy obiekt przesta� dotyka� innego obiektu
        //isTouchingObject = false;
        Debug.Log("Odbite.");
        ilosc_k = ilosc_k - 1;
        if (ilosc_k < 1)
        {
            stan = 0;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
