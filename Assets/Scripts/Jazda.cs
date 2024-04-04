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
    float przyspieszenie = 20;
    public float stan = 0;
    private bool collisionOccurred = false; // Flaga informuj¹ca o wyst¹pieniu kolizji
    private bool isTouchingSurface = false; // Flaga informuj¹ca o dotyku powierzchni
    public float x;
    public float y;
    public float z;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float rotacjaZ;
    float wspolczynnik_sily =1000;
    bool isTouchingObject = false; // Flaga informuj¹ca o dotyku z obiektem

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

        // Oblicz k¹t zderzenia miêdzy obiektami
        float collisionAngle = Vector3.Angle(collisionDirection, objectDirection);

        // Wyœwietl wynik
        Debug.Log("K¹t zderzenia: " + collisionAngle + " stopni.");
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
    // Start is called before the first frame update
    void Start()
    {
        isRigidbody = TryGetComponent<Rigidbody>(out rb);
// kierunek = 0f;
    }
    public float speedIncreaseAmount = 1f; // Wartoœæ o jak¹ chcemy zwiêkszyæ prêdkoœæ w osi X



    //private void OnCollisionEnter(Collision collision)
   // {
   ////     collisionOccurred = true;
    //    Debug.Log("Kolizja z obiektem: " + collision.gameObject.name);
   // }
    // Update is called once per frame
    void Update()
    {
        
        // kierunek = Hdirection / Vdirection;
    }
    private void FixedUpdate()
    {
        CheckCollision();
        float Hdirection;
        float Vdirection;
        Vector3 currentVelocity = rb.velocity;
        speed = (float)Math.Sqrt(currentVelocity.x*currentVelocity.x+currentVelocity.y *currentVelocity.y+currentVelocity.z*currentVelocity.z);
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
        if (1==1 && kamera.obiekt_rodzaj == 1  && kamera.nazwa_samochodu==this.name)
        {
            if (isRigidbody)// && (Hdirection = Input.GetAxis("Vertical")) != 0)
            {
                Vector3 currentRotation = transform.rotation.eulerAngles;
                rotacjaZ = currentRotation.z;
                if (currentRotation.z > 270 || currentRotation.z < 90)
                {
                    rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10 * wspolczynnik_sily);
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 17 * wspolczynnik_sily, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 12 * wspolczynnik_sily, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 17 * wspolczynnik_sily);
                        x = (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        y = -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 150;
                        z = (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        //rb.AddForce(0, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * przyspieszenie, 0);

                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        rb.AddForce(-((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 26 * wspolczynnik_sily), (float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 2 * wspolczynnik_sily, -((float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 26 * wspolczynnik_sily));
                        x = -(float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 26;
                        y = (float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 26;
                        z = -(float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 26;
                    }
                }

            }
            
            if (isRigidbody) //&& (Vdirection = Input.GetAxis("Horizontal")) != 0)
            {

                if (Input.GetKey(KeyCode.D))
                {
                    if (speed > 1 && speed <= 10)
                    {
                        //kierunek = kierunek - 0.5f;
                        transform.Rotate(Vector3.up * 0.7f); // Zwiêkszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwiêkszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwiêkszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * 0.5f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * 0.3f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * 0.5f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed < -0.3 && speed >= -1)
                    {
                        transform.Rotate(Vector3.up * 0.3f);
                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (speed > 1 && speed <= 10)
                    {
                        //kierunek = kierunek - 0.5f;
                        transform.Rotate(Vector3.up * -0.7f); // Zwiêkszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwiêkszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwiêkszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * -0.5f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * -0.3f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * 50.5f); // Zwiêkszenie rotacji w osi Y
                    }
                    if (speed < -0.3 && speed >= -1)
                    {
                        transform.Rotate(Vector3.up * 50.3f);
                    }

                }

                Vector3 currentRotation = transform.rotation.eulerAngles;
                float rotationX = currentRotation.x;
                float rotationY = currentRotation.y;
                float rotationZ = currentRotation.z;
                kierunek = rotationY;
                VelocityX = currentVelocity.x;
                VelocityY = currentVelocity.y;
                VelocityZ = currentVelocity.z;
                float arcTanValue = Mathf.Atan(VelocityX/ VelocityZ);

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
                if (kierunek_jazdy - kierunek < -2)
                {
                    
                    //rb.AddForce(-(float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * (przyspieszenie ), 0, (float)Math.Cos((currentRotation.y + 90) / (180 / Math.PI)) * (przyspieszenie ));
                    //rb.AddForce((float)Math.Sin((currentRotation.y + 90) / (180 / Math.PI)) * przyspieszenie, 0, 0);

                }
                //if (kierunek < 0f) { kierunek = kierunek + 360f; }
                //if (kierunek >360f) { kierunek = kierunek - 360f; }
                //Console.WriteLine(kierunek.ToString);
            }
      
        }
            
    }
}


