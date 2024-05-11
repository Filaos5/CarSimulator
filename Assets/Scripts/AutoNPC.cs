using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AutoNPC : MonoBehaviour
{
    //private Rigidbody rb;
    // Start is called before the first frame update
    public float speed = 0;
    public float meta_x;
    public float meta_z;
    public float cel_x;
    public float cel_z;
    float stan = 0;
    public Rigidbody rb;
    float obrot = 1;
    private float[] floatArray_X = new float[5]; // Tablica float o d�ugo�ci 5
    private float[] floatArray_Z = new float[5]; // Tablica float o d�ugo�ci 5
    public int currentIndex = 0;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float pozycjaX;
    public float pozycjaZ;
    public float rotacjaZ;
    public float rotacjaX;
    public float kierunek_jazdy = 0f;
    public float kierunek = 0f;
    public float roznica;
    public int koniec=0;

    float wspolczynnik_sily = 1000;
    bool isTouchingObject = false; // Flaga informuj�ca o dotyku z obiektem
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
        floatArray_Z[4] = -1400;


        // Zwi�ksz pozycj� obiektu o 1 w osi x
        meta_x = floatArray_X[0];
        meta_z = floatArray_Z[0];


    }
    void OnTriggerEnter(Collider other)
    {
        // Obiekt wszed� w obszar triggera innego obiektu
        //kolidujeZInnymObiektem = true;
        //Debug.Log("Zderzenie z innym obiektem: " + other.gameObject.name);
        stan = 1;
    }

    void OnTriggerExit(Collider other)
    {
        stan = 0;
        // Obiekt opu�ci� obszar triggera innego obiektu
        //kolidujeZInnymObiektem = false;
        //Debug.Log("Zako�czenie zderzenia z innym obiektem: " + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)
    {
        stan = 1;
        // Ustaw zmienn� na true, gdy obiekt nadal koliduje z innym obiektem
        //kolidujeZInnymObiektem = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        obrot = 8;
    }
    private void OnCollisionExit(Collision collision)
    {
        obrot = 1;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 currentVelocity = rb.velocity;
        rb.AddForce((-currentVelocity.x / 4)* wspolczynnik_sily, (-currentVelocity.y / 5) * wspolczynnik_sily, (-currentVelocity.z / 4) * wspolczynnik_sily);
        VelocityX = currentVelocity.x;
        VelocityY = currentVelocity.y;
        VelocityZ = currentVelocity.z;
        speed = (float)Math.Sqrt(currentVelocity.x * currentVelocity.x + currentVelocity.y * currentVelocity.y + currentVelocity.z * currentVelocity.z);
        if (Math.Abs(speed) < 0.1)
        {
            wspolczynnik_sily = 10000;
        }
        else
        {
            wspolczynnik_sily = 1000;
        }
        if (Math.Abs(currentPosition.x - meta_x) > Math.Abs(currentPosition.z - meta_z))
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
        // Konwersja z radian�w na stopnie
        kierunek_jazdy = Mathf.Rad2Deg * arcTanValue;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        kierunek = currentRotation.y;
        rotacjaX = currentRotation.x + 180;
        if (rotacjaX > 360)
        {
            rotacjaX = rotacjaX - 360;
        }
        if (rotacjaX < 280 && rotacjaX > 260)
        {
            transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
        }
        if (rotacjaX < 100 && rotacjaX > 80)
        {
            transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
        }
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
        if (stan == 1)//(currentRotation.z > 270 || currentRotation.z < 90)
        {
            if (Mathf.Abs(roznica) > 180)
            {
                //Debug.Log("Jazda prawo ");
                rb.AddForce(-((float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.5) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.5) * wspolczynnik_sily));
                transform.Rotate(Vector3.up * (1f));
            }
            else
            {
                //Debug.Log("Jazda lewo ");
                rb.AddForce(-((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (speed / (float)1.5) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (speed / (float)1.5) * wspolczynnik_sily));
                transform.Rotate(Vector3.up * (-1f));
            }
            if ((Math.Abs(currentPosition.x - meta_x) + Math.Abs(currentPosition.z - meta_z)) < 60)
            {
                currentIndex = currentIndex + 1;
                if (currentIndex < floatArray_X.Length)
                {
                    meta_x = (float)floatArray_X[currentIndex];
                    meta_z = (float)floatArray_Z[currentIndex];
                }
                else
                {
                    koniec = 1;
                }
            }
            //rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10);
            if (rb.position.y < 0.2)
            {
                stan = 1;
            }
            if (stan == 1 && koniec==0)
            {

                rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 14 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 14 * wspolczynnik_sily);

            }

        }
        else
        {
            if (Mathf.Abs(roznica) > 180)
            {
                rb.AddTorque(Vector3.right * wspolczynnik_sily * obrot);
            }
            else
            {
                rb.AddTorque(Vector3.right * wspolczynnik_sily * -obrot);
            }
        }
        
    }
}
