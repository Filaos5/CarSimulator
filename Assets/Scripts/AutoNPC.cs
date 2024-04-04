using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AutoNPC : MonoBehaviour
{
    //private Rigidbody rb;
    // Start is called before the first frame update
    public float meta_x;
    public float meta_z;
    public float cel_x;
    public float cel_z;
    float stan = 0;
    public Rigidbody rb;
    private float[] floatArray_X = new float[5]; // Tablica float o d³ugoœci 5
    private float[] floatArray_Z = new float[5]; // Tablica float o d³ugoœci 5
    public int currentIndex = 0;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float pozycjaX;
    public float pozycjaZ;
    public float kierunek_jazdy = 0f;
    public float kierunek = 0f;
    public float roznica;
    float wspolczynnik_sily = 1000;
    bool isTouchingObject = false; // Flaga informuj¹ca o dotyku z obiektem
    void Start()
    {
        floatArray_X[0] = 120;
        floatArray_X[1] = 960;
        floatArray_X[2] = 960;
        floatArray_X[3] = 120;
        floatArray_X[4] = 120;
        floatArray_Z[0] = 830;
        floatArray_Z[1] = 830;
        floatArray_Z[2] = -260;
        floatArray_Z[3] = -260;
        floatArray_Z[4] = -1350;


        // Zwiêksz pozycjê obiektu o 1 w osi x
        meta_x = floatArray_X[0];
        meta_z = floatArray_Z[0];


    }
    private void CheckCollision()
    {
        // Ustaw flagê na podstawie kolizji
        if (isTouchingObject)
        {
            UpdateState();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt dotyka innego obiektu
        isTouchingObject = true;
        Debug.Log("Enter ");
        stan = 1;
        // Pobierz kierunek zderzenia
        Vector3 collisionDirection = collision.contacts[0].normal;

        // Pobierz kierunek przemieszczenia obiektu
        Vector3 objectDirection = transform.forward;
    }

    private void OnCollisionExit(Collision collision)
    {
        // SprawdŸ, czy obiekt przesta³ dotykaæ innego obiektu
        isTouchingObject = false;
        Debug.Log("Exit");
        stan = 0;
    }

    private void UpdateState()
    {
        // Ustaw stan na podstawie dotyku z innym obiektem
        int state = isTouchingObject ? 1 : 0;

        // Tutaj mo¿esz wykonaæ dodatkowe akcje w zale¿noœci od stanu, np. zmieniæ animacjê, itp.

        // Wyœwietl informacjê w konsoli
        Debug.Log("Stan: " + state);
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        CheckCollision();
        Vector3 currentPosition = transform.position;
        Vector3 currentVelocity = rb.velocity;
        rb.AddForce((-currentVelocity.x / 4)* wspolczynnik_sily, (-currentVelocity.y / 5) * wspolczynnik_sily, (-currentVelocity.z / 4) * wspolczynnik_sily);
        VelocityX = currentVelocity.x;
        VelocityY = currentVelocity.y;
        VelocityZ = currentVelocity.z;
        if(Math.Abs(currentPosition.x - meta_x) > Math.Abs(currentPosition.z - meta_z))
        {
            cel_z = meta_z;
            if(currentPosition.x +100< meta_x)
            {
                cel_x = currentPosition.x+100;
            }
            else
            {
                cel_x = meta_x;
            }
            if (currentPosition.x > meta_x +100)
            {
                cel_x = currentPosition.x - 100;
            }
        }
        else
        {
            cel_x = meta_x;
            if (currentPosition.z + 100 < meta_z)
            {
                cel_z = currentPosition.z + 100;
            }
            else
            {
                cel_z = meta_z;
            }
            if (currentPosition.z > meta_z + 100)
            {
                cel_z = currentPosition.z - 100;
            }
        }
        float arcTanValue = Mathf.Atan2((cel_x- currentPosition.x), (cel_z - currentPosition.z));
        pozycjaZ=currentPosition.z;
        pozycjaX=currentPosition.x;
        // Konwersja z radianów na stopnie
        kierunek_jazdy = Mathf.Rad2Deg * arcTanValue;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        kierunek = currentRotation.y;

        //if (kierunek < kierunek_jazdy)
        // {
        //    kierunek = kierunek + 360f;
        //  }
        //kierunek_jazdy = 30f;
        if (kierunek_jazdy < 0)
        {
            kierunek_jazdy = kierunek_jazdy + 360f;
        }
        if (kierunek < 0)
        {
            kierunek = kierunek + 360f;
        }
        float roznica1 = (kierunek - kierunek_jazdy);
        if (roznica1 < 0)
        {
            roznica = roznica1 + 360;
        }
        else
        {
            roznica = roznica1;
        }
        if (currentRotation.z > 270 || currentRotation.z < 90)
        {
            if (Mathf.Abs(roznica) > 180)
            {
                Debug.Log("Jazda prawo ");
                transform.Rotate(Vector3.up * (0.7f));
            }
            else
            {
                Debug.Log("Jazda lewo ");
                transform.Rotate(Vector3.up * (-0.7f));
            }
            if ((Math.Abs(currentPosition.x - meta_x) + Math.Abs(currentPosition.z - meta_z)) < 100)
            {
                currentIndex = currentIndex + 1;
                if (currentIndex < floatArray_X.Length)
                {
                    meta_x = (float)floatArray_X[currentIndex];
                    meta_z = (float)floatArray_Z[currentIndex];
                }
            }
            //rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10);
            if (rb.position.y < 0.2)
            {
                stan = 1;
            }
            if (stan == 1)
            {

                rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 25* wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 15 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 25 * wspolczynnik_sily);

            }
        }
    }
}
