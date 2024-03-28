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
    private bool collisionOccurred = false; // Flaga informuj�ca o wyst�pieniu kolizji
    private bool isTouchingSurface = false; // Flaga informuj�ca o dotyku powierzchni
    public float x;
    public float y;
    public float z;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float rotacjaZ;
    bool isTouchingObject = false; // Flaga informuj�ca o dotyku z obiektem

    private void CheckCollision()
    {
        // Ustaw flag� na podstawie kolizji
        if (isTouchingObject)
        {
            UpdateState();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy obiekt dotyka innego obiektu
        isTouchingObject = true;
        Debug.Log("Enter ");
        stan = 1;
        // Pobierz kierunek zderzenia
        Vector3 collisionDirection = collision.contacts[0].normal;

        // Pobierz kierunek przemieszczenia obiektu
        Vector3 objectDirection = transform.forward;

        // Oblicz k�t zderzenia mi�dzy obiektami
        float collisionAngle = Vector3.Angle(collisionDirection, objectDirection);

        // Wy�wietl wynik
        Debug.Log("K�t zderzenia: " + collisionAngle + " stopni.");
    }

    private void OnCollisionExit(Collision collision)
    {
        // Sprawd�, czy obiekt przesta� dotyka� innego obiektu
        isTouchingObject = false;
        Debug.Log("Exit");
        stan = 0;
    }

    private void UpdateState()
    {
        // Ustaw stan na podstawie dotyku z innym obiektem
        int state = isTouchingObject ? 1 : 0;

        // Tutaj mo�esz wykona� dodatkowe akcje w zale�no�ci od stanu, np. zmieni� animacj�, itp.

        // Wy�wietl informacj� w konsoli
        Debug.Log("Stan: " + state);
    }
    // Start is called before the first frame update
    void Start()
    {
        isRigidbody = TryGetComponent<Rigidbody>(out rb);
// kierunek = 0f;
    }
    public float speedIncreaseAmount = 1f; // Warto�� o jak� chcemy zwi�kszy� pr�dko�� w osi X



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
        rb.AddForce(-currentVelocity.x/4, -currentVelocity.y/5, -currentVelocity.z/4);
        if (stan==0)
        {
            Debug.Log("Brak kolizji z innym obiektem.");
        }
        if (rb.position.y < 0.2)
        {
            stan = 1;
        }
        Kamera kamera = FindObjectOfType<Kamera>();
        if (1==1 && kamera.obiekt_rodzaj == 1)
        {
            if (isRigidbody)// && (Hdirection = Input.GetAxis("Vertical")) != 0)
            {
                Vector3 currentRotation = transform.rotation.eulerAngles;
                rotacjaZ = currentRotation.z;
                if (currentRotation.z > 270 || currentRotation.z < 90)
                {
                    rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10);
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 17, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 12, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 17);
                        x = (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        y = -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 150;
                        z = (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 150;
                        //rb.AddForce(0, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * przyspieszenie, 0);

                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        rb.AddForce(-((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 26), (float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 2, -((float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 26));
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
                        transform.Rotate(Vector3.up * 0.7f); // Zwi�kszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwi�kszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwi�kszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * 0.5f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * 0.3f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * 0.5f); // Zwi�kszenie rotacji w osi Y
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
                        transform.Rotate(Vector3.up * -0.7f); // Zwi�kszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwi�kszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwi�kszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * -0.5f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * -0.3f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * 50.5f); // Zwi�kszenie rotacji w osi Y
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

                // Konwersja z radian�w na stopnie
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
            /*
            if (isRigidbody)// && (Hdirection = Input.GetAxis("Vertical")) != 0)
            {
                IncreaseSpeedXYZ(kierunek);
                if (Input.GetKey(KeyCode.W))
                {
                    if (speed < 30)
                    {
                        speed = speed + (float)0.1;
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (speed > -5)
                    {
                        speed = speed - (float)0.1;
                    }
                }
                //rb.AddForce(Hdirection * Time.deltaTime * speed * kierunek * (float)Math.Sin((kierunek+0) / (180/Math.PI)), 0, Hdirection * Time.deltaTime * speed * kierunek * (float)Math.Cos((kierunek + 0) / (180 / Math.PI)));
                //rb.AddForce(Hdirection * Time.deltaTime * speed * (float)Math.Sin(kierunek/(180/Math.PI)),0, Hdirection * Time.deltaTime * speed * (float)Math.Cos((kierunek) / (180 / Math.PI))) ;

            }
            else
            {
                if (speed > 0) speed = speed - (float)0.04;
                if (speed < 0) speed = speed + (float)0.04;
            }
            if (isRigidbody) //&& (Vdirection = Input.GetAxis("Horizontal")) != 0)
            {
                //  rb.AddForce(Vdirection * Time.deltaTime * speed *0.2f * kierunek * (float)Math.Sin((kierunek + 180) / (180 / Math.PI)), 0, Vdirection * Time.deltaTime * speed * 0.2f * kierunek * (float)Math.Sin((kierunek + 90) / (180 / Math.PI)));

                if (Input.GetKey(KeyCode.D))
                {
                    if (speed > 1 && speed <= 10)
                    {
                        //kierunek = kierunek - 0.5f;
                        transform.Rotate(Vector3.up * 0.3f); // Zwi�kszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwi�kszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwi�kszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * 0.2f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * 0.1f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * (-0.2f)); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -0.3 && speed >= -1)
                    {
                        transform.Rotate(Vector3.up * (-0.1f));
                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (speed > 1 && speed <= 10)
                    {
                        //kierunek = kierunek - 0.5f;
                        transform.Rotate(Vector3.up * -0.3f); // Zwi�kszenie rotacji w osi Y
                    }
                    //transform.Rotate(Vector3.right * 1); // Zwi�kszenie rotacji w osi X
                    //transform.Rotate(Vector3.forward * 1); // Zwi�kszenie rotacji w osi Z
                    if (speed > 10)
                    {
                        transform.Rotate(Vector3.up * -0.2f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed > 0.3 && speed <= 1)
                    {
                        transform.Rotate(Vector3.up * -0.1f); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -1)
                    {
                        //kierunek = kierunek + 0.5f;
                        transform.Rotate(Vector3.up * (0.2f)); // Zwi�kszenie rotacji w osi Y
                    }
                    if (speed < -0.3 && speed >= -1)
                    {
                        transform.Rotate(Vector3.up * (0.1f));
                    }

                }

                Vector3 currentRotation = transform.rotation.eulerAngles;
                float rotationX = currentRotation.x;
                float rotationY = currentRotation.y;
                float rotationZ = currentRotation.z;
                kierunek = rotationY;
                //if (kierunek < 0f) { kierunek = kierunek + 360f; }
                //if (kierunek >360f) { kierunek = kierunek - 360f; }
                //Console.WriteLine(kierunek.ToString);
            }
            */
        }
            
    }
}


