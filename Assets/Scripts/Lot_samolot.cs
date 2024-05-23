using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lot_samolot : MonoBehaviour
{
    public float speed = 0;
    public float speed_c = 0;
    public Rigidbody rb;
    private bool isRigidbody;
    public float kierunek = 0f;
    public float kierunek_jazdy = 0f;
    public int liczbaKolizji = 0;
    float przyspieszenie = 20;
    public float stan = 0;
    public float obrot = 1;
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
    public float right = 0;
    float poprzedniaPozycjax;
    float poprzedniaPozycjay;
    float poprzedniaPozycjaz;
    float kierunekRuchuStopnie_p;
    public float kierunekRuchuStopnie;
    public int przod_tyl = 0; // 0 oznacza jazdê do przodu a 1 to ty³u
    float wspolczynnik_sily = 1000;
    bool isTouchingObject = false; // Flaga informuj¹ca o dotyku z obiektem
    public AudioClip dzwiek; // DŸwiêk do odtworzenia
    private bool warunek = false; // Warunek do sprawdzenia
    private float glosnosc = 0.5f; // G³oœnoœæ dŸwiêku
    // Start is called before the first frame update
    void Start()
    {
        poprzedniaPozycjax = transform.position.x;
        poprzedniaPozycjay = transform.position.y;
        poprzedniaPozycjaz = transform.position.z;
        isRigidbody = TryGetComponent<Rigidbody>(out rb);
    }

    // Update is called once per frame
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
        speed_c = (float)Math.Sqrt(currentVelocity.x * currentVelocity.x + currentVelocity.y * currentVelocity.y + currentVelocity.z * currentVelocity.z);
        speed = (float)Math.Sqrt(currentVelocity.x * currentVelocity.x + currentVelocity.z * currentVelocity.z);
        if (Math.Abs(speed) < 0.1)
        {
            wspolczynnik_sily = 10000;
        }
        else
        {
            wspolczynnik_sily = 1000;
        }
        rb.AddForce((-currentVelocity.x * 2) * wspolczynnik_sily, (-currentVelocity.y * 5) * wspolczynnik_sily, (-currentVelocity.z * 2) * wspolczynnik_sily);
        if (stan == 0)
        {
            Debug.Log("Brak kolizji z innym obiektem.");
        }
        if (rb.position.y < 0.2)
        {
            stan = 1;
        }
        Kamera kamera = FindObjectOfType<Kamera>();
        if (kamera.obiekt_rodzaj == 4 && kamera.nazwa_samolotu == this.name)
        {
            if (isRigidbody)// && (Hdirection = Input.GetAxis("Vertical")) != 0)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    // SprawdŸ, czy dŸwiêk nie jest obecnie odtwarzany
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        // Odtwórz dŸwiêk z odpowiedni¹ g³oœnoœci¹
                        GetComponent<AudioSource>().clip = dzwiek;
                        GetComponent<AudioSource>().volume = 1.0f; // Ustaw g³oœnoœæ na 100%
                        GetComponent<AudioSource>().Play();
                        warunek = false; // Wy³¹cz warunek, aby unikn¹æ ponownego odtwarzania
                    }
                }
                else
                {
                    // SprawdŸ, czy dŸwiêk nie jest obecnie odtwarzany
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        // Odtwórz dŸwiêk z odpowiedni¹ g³oœnoœci¹
                        GetComponent<AudioSource>().clip = dzwiek;
                        GetComponent<AudioSource>().volume = 0.6f; // Ustaw g³oœnoœæ na 50%
                        GetComponent<AudioSource>().Play();
                    }
                }
                Vector3 currentRotation = transform.rotation.eulerAngles;
                rotacjaZ = currentRotation.z + 180;

                if (rotacjaZ > 360)
                {
                    rotacjaZ = rotacjaZ - 360;
                }
                //rb.AddForce(-(float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * speed * 3 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * speed * 3 * wspolczynnik_sily);
                rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)2.6 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)2.6 * wspolczynnik_sily);
                rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * speed* (float)2.6, 0);

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    rb.AddForce(-(float)Math.Cos((currentRotation.x) / (180 / Math.PI))* (float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * 500 * wspolczynnik_sily, (float)Math.Sin((currentRotation.x) / (180 / Math.PI))*(float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * 500 * wspolczynnik_sily, (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 500 * wspolczynnik_sily);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce((float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * 300 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * 500 * wspolczynnik_sily, -(float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 300 * wspolczynnik_sily);

                }
                if (Input.GetKey(KeyCode.E))
                {
                    if (speed > 1)
                    {
                        if (przod_tyl == 0)
                        {
                            transform.Rotate(Vector3.up * 0.2f);
                            rb.AddForce(-((float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (speed * (float)1.5) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (speed * (float)1.5) * wspolczynnik_sily));
                        }
                        else
                        {
                            transform.Rotate(Vector3.up * -0.2f);
                            rb.AddForce(-((float)Math.Sin((currentRotation.y - 90) / (180 / Math.PI)) * (speed * (float)1.5) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y - 90) / (180 / Math.PI)) * (speed * (float)1.5) * wspolczynnik_sily));
                        }
                    }
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    if (speed > 1)
                    {
                        if (przod_tyl == 0)
                        {
                            transform.Rotate(Vector3.up * -0.2f);
                            rb.AddForce(-((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (speed * (float)2.5) * wspolczynnik_sily), 0, -((float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (speed * (float)2.5) * wspolczynnik_sily));
                        }
                        else
                        {
                            transform.Rotate(Vector3.up * 0.2f);
                            rb.AddForce(-((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (speed * (float)2.5) * wspolczynnik_sily), 0, (-(float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (speed * (float)2.5) * wspolczynnik_sily));
                        }
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    if (speed > 1)
                    {
                        transform.Rotate(Vector3.right * 0.2f);
                        rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)4 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)4 * wspolczynnik_sily);
                        rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * speed * (float)4, 0);
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (speed > 1)
                    {
                        transform.Rotate(Vector3.right * -0.2f);
                        rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)4 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * speed * (float)4 * wspolczynnik_sily);
                        rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * speed * (float)4, 0);
                    }
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    if (speed > 1)
                    {
                        transform.Rotate(Vector3.forward * -0.3f);
                    }
                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    if (speed > 1)
                    {
                        transform.Rotate(Vector3.forward * 0.3f);
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


                }
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
