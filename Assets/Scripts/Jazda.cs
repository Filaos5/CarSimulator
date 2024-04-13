using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.Collections;

public class Jazda : MonoBehaviour
{
    public float speed = 0;
    public Rigidbody rb;
    private bool isRigidbody;
    public float kierunek=0f;
    public float kierunek_jazdy = 0f;
    public int liczbaKolizji = 0;
    float przyspieszenie = 20;
    public float stan = 0;
    public float ilosc_k = 0;
    private bool collisionOccurred = false; // Flaga informuj¹ca o wyst¹pieniu kolizji
    private bool isTouchingSurface = false; // Flaga informuj¹ca o dotyku powierzchni
    public float x;
    public float y;
    public float z;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float rotacjaZ;
    public float rotacjaX;
    float poprzedniaPozycjax;
    float poprzedniaPozycjay;
    float poprzedniaPozycjaz;
    float kierunekRuchuStopnie_p;
    public float kierunekRuchuStopnie;
    public int przod_tyl=0; // 0 oznacza jazdê do przodu a 1 to ty³u
    float wspolczynnik_sily =1000;
    bool isTouchingObject = false; // Flaga informuj¹ca o dotyku z obiektem

    //public bool kolidujeZInnymObiektem = false;
    void OnTriggerEnter(Collider other)
    {
        // Obiekt wszed³ w obszar triggera innego obiektu
        //kolidujeZInnymObiektem = true;
        //Debug.Log("Zderzenie z innym obiektem: " + other.gameObject.name);
        stan = 1;
    }

    void OnTriggerExit(Collider other)
    {
        stan = 0;
        // Obiekt opuœci³ obszar triggera innego obiektu
        //kolidujeZInnymObiektem = false;
        //Debug.Log("Zakoñczenie zderzenia z innym obiektem: " + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)
    {
        stan = 1;
        // Ustaw zmienn¹ na true, gdy obiekt nadal koliduje z innym obiektem
        //kolidujeZInnymObiektem = true;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        poprzedniaPozycjax = transform.position.x;
        poprzedniaPozycjay = transform.position.y;
        poprzedniaPozycjaz = transform.position.z;
        isRigidbody = TryGetComponent<Rigidbody>(out rb);
// kierunek = 0f;
    }
    public float speedIncreaseAmount = 1f; // Wartoœæ o jak¹ chcemy zwiêkszyæ prêdkoœæ w osi X


    void Update()
    {
    
    }
    private void FixedUpdate()
    {
        //CheckCollision();
        float Hdirection;
        float Vdirection;
        Vector3 currentVelocity = rb.velocity;
        kierunekRuchuStopnie_p = Mathf.Atan2(transform.position.z - poprzedniaPozycjaz, transform.position.x - poprzedniaPozycjax) * Mathf.Rad2Deg;
        kierunekRuchuStopnie = -kierunekRuchuStopnie_p + 90;
        if (kierunekRuchuStopnie < 0)
        {
            kierunekRuchuStopnie = kierunekRuchuStopnie + 360;
        }
        poprzedniaPozycjax = transform.position.x;
        poprzedniaPozycjay = transform.position.y;
        poprzedniaPozycjaz = transform.position.z;
        // Wyœwietl kierunek ruchu w konsoli
        Debug.Log("Kierunek ruchu obiektu w stopniach: " + kierunekRuchuStopnie);
        speed = (float)Math.Sqrt(currentVelocity.x*currentVelocity.x+currentVelocity.y *currentVelocity.y+currentVelocity.z*currentVelocity.z);
        if (Math.Abs(speed) < 0.1)
        {
            wspolczynnik_sily = 10000;
        }
        else
        {
            wspolczynnik_sily = 1000;
        }
        rb.AddForce((-currentVelocity.x/4)* wspolczynnik_sily, (-currentVelocity.y/5) * wspolczynnik_sily, (-currentVelocity.z/4) * wspolczynnik_sily);
        if (stan==0)
        {
            Debug.Log("Brak kolizji z innym obiektem.");
        }
        if (rb.position.y < 0.2)
        {
            stan = 1;
        }
        Kamera kamera = FindObjectOfType<Kamera>();
        if (kamera.obiekt_rodzaj == 1  && kamera.nazwa_samochodu==this.name)
        {
            if (isRigidbody)// && (Hdirection = Input.GetAxis("Vertical")) != 0)
            {
                Vector3 currentRotation = transform.rotation.eulerAngles;
                rotacjaZ = currentRotation.z+180;
                if (rotacjaZ > 360)
                {
                    rotacjaZ = rotacjaZ - 360;
                }
                if (stan==1) //&& (currentRotation.x > -80 && currentRotation.x < 80)) (rotacjaZ > 110) && (rotacjaZ < 250) && 
                {
                    //rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10 * wspolczynnik_sily);
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 17 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 12 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 17 * wspolczynnik_sily);
                        //x = (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        //y = -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 150;
                        //z = (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        //rb.AddForce(0, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * przyspieszenie, 0);

                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        rb.AddForce(-((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 15 * wspolczynnik_sily), (float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 2 * wspolczynnik_sily, -((float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 15 * wspolczynnik_sily));
                        // x = -(float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 26;
                        // y = (float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 26;
                        //z = -(float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 26;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        if (przod_tyl == 0)
                        {
                            rb.AddForce(-((float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.6) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.6) * wspolczynnik_sily));
                            transform.Rotate(Vector3.up * 1f);
                        }
                        else
                        {
                            rb.AddForce(((float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.6) * wspolczynnik_sily), 0, ((float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (speed / (float)1.6) * wspolczynnik_sily));
                            transform.Rotate(Vector3.up * (-1f));
                        }

                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        if (przod_tyl == 0)
                        {
                            rb.AddForce(-((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (speed / 2) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (speed / 2) * wspolczynnik_sily));
                            //kierunek = kierunek - 0.5f;
                            transform.Rotate(Vector3.up * -1f);
                        }
                        else
                        {
                            rb.AddForce(((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (speed / 2) * wspolczynnik_sily), 0, ((float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (speed / 2) * wspolczynnik_sily));
                            transform.Rotate(Vector3.up * 1f);
                        }


                    }

                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        rb.AddTorque(Vector3.right * wspolczynnik_sily * 7);
                        //rb.AddTorque(Vector3.)
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        rb.AddTorque(Vector3.right * wspolczynnik_sily * -7);
                    }
                }

                //Vector3 currentRotation = transform.rotation.eulerAngles;
                float rotationX = currentRotation.x;
                float rotationY = currentRotation.y;
                float rotationZ = currentRotation.z;
                kierunek = rotationY;
                VelocityX = currentVelocity.x;
                VelocityY = currentVelocity.y;
                VelocityZ = currentVelocity.z;
                float arcTanValue = Mathf.Atan(VelocityX / VelocityZ);

                // Konwersja z radianów na stopnie
                kierunek_jazdy = Mathf.Rad2Deg * arcTanValue;
                if (kierunek_jazdy < 0) kierunek_jazdy = kierunek_jazdy + 360;
                if (kierunek_jazdy > 360) kierunek_jazdy = kierunek_jazdy - 360;
                if (kierunek < 0) kierunek_jazdy = kierunek + 360;
                if (kierunek > 360) kierunek_jazdy = kierunek - 360;
                if (kierunek_jazdy - kierunek > 2)
                {
                    //rb.AddForce(-(float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (przyspieszenie/2), 0, (float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (przyspieszenie / 2));


                }
               // if (kierunek_jazdy - kierunek < -2)
                //{

                    //rb.AddForce(-(float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (przyspieszenie ), 0, (float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (przyspieszenie ));
                    //rb.AddForce((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * przyspieszenie, 0, 0);

                //}
                if (Math.Abs(kierunek - kierunekRuchuStopnie) < 90 || Math.Abs(kierunek - kierunekRuchuStopnie) > 280)
                {
                    przod_tyl = 0; //
                }
                else
                {
                    przod_tyl = 1;
                }


            }


        }
            
    }
}


