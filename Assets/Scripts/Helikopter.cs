using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Helikopter : MonoBehaviour
{
    public float speed = 0;
    public Rigidbody rb;
    private bool isRigidbody;
    public float kierunek = 0f;
    public float kierunek_lotu = 0f;
    public int liczbaKolizji = 0;
    public float stan = 0;
    public float obrot = 1;
    public float ilosc_k = 0;
    public float x;
    public float y;
    public float z;
    public float VelocityX;
    public float VelocityY;
    public float VelocityZ;
    public float rotacjaZ;
    public float rotacjaX;
    public float rotacjaYv;
    float poprzedniaPozycjax;
    float poprzedniaPozycjay;
    float poprzedniaPozycjaz;
    float kierunekRuchuStopnie_p;
    public float kierunekRuchuStopnie;
    public float right = 0;
    public float w = 0;
    public int przod_tyl = 0; // 0 oznacza jazdê do przodu a 1 to ty³u
    public float wspolczynnik_sily = 1000;
    public float torp=0;
    public float torb = 0;
    // Start is called before the first frame update
    void Start()
    {
        isRigidbody = TryGetComponent<Rigidbody>(out rb);
        obrot = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.y>=100000)
        {
            wspolczynnik_sily = 0;
        }
        if (transform.position.y <= 0)
        {
            wspolczynnik_sily = 1000;
        }
        if (transform.position.y > 0 && transform.position.y < 100000)
        {
            w = transform.position.y / 100000;
            wspolczynnik_sily = (float)(-Math.Sqrt(1 - (w / 1 - 1) * (w / 1 - 1)) + 1) * 1000;
        }
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
        speed = (float)Math.Sqrt(currentVelocity.x * currentVelocity.x + currentVelocity.y * currentVelocity.y + currentVelocity.z * currentVelocity.z);
        rb.AddForce((-currentVelocity.x / 2 ) * wspolczynnik_sily, (-currentVelocity.y / 2 ) * wspolczynnik_sily, (-currentVelocity.z / 2 ) * wspolczynnik_sily);
        if (stan == 0)
        {
            Debug.Log("Brak kolizji z innym obiektem.");
        }
        Kamera kamera = FindObjectOfType<Kamera>();
        if (kamera.obiekt_rodzaj == 2 && kamera.nazwa_helikoptera == this.name)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            rotacjaZ = currentRotation.z + 180;

            if (rotacjaZ > 360)
            {
                rotacjaZ = rotacjaZ - 360;
            }
            rb.AddForce(-(float)Math.Sin((currentRotation.z) / (180 / Math.PI))* (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 27 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 27 * wspolczynnik_sily);
            rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 27 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 27 * wspolczynnik_sily);
            rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * 27, 0);
            //rb.AddForce(0, (float)Math.Sin((currentRotation.x + 90) / (180 / Math.PI))* wspolczynnik_sily * 27, 0);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(-(float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 20 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 20 * wspolczynnik_sily);
                rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 20 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 20 * wspolczynnik_sily);
                rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * 20, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-(float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * -10 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.z) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * -10 * wspolczynnik_sily);
                rb.AddForce((float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * -10 * wspolczynnik_sily, 0, (float)Math.Sin((currentRotation.x) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * -10 * wspolczynnik_sily);
                rb.AddForce(0, (float)Math.Cos((currentRotation.z) / (180 / Math.PI)) * (float)Math.Cos((currentRotation.x) / (180 / Math.PI)) * wspolczynnik_sily * (-10), 0);
            }
            
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.right * -1f);
                //Vector3 torqueVector = new Vector3(-((float)Math.Cos((currentRotation.y) / (180 / Math.PI))), 0, ((float)Math.Sin((currentRotation.y) / (180 / Math.PI))));
                //rb.AddTorque(torqueVector * wspolczynnik_sily * obrot);

            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.right * 1f);
                //Vector3 torqueVector = new Vector3(-((float)Math.Cos((currentRotation.y) / (180 / Math.PI))), 0, ((float)Math.Sin((currentRotation.y) / (180 / Math.PI))));
                //rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot);

            }
            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 torqueVector = new Vector3(0, 2, 0);
                rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot );
                 //transform.Rotate(Vector3.up * -1f);
                //transform.Rotate(0, -1, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 torqueVector = new Vector3(0, 2, 0);
                rb.AddTorque(torqueVector * wspolczynnik_sily * obrot );
                 //transform.Rotate(Vector3.up * 1f);
                 //transform.Rotate(0, 1, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //Vector3 torqueVector = new Vector3(((float)Math.Sin((currentRotation.y) / (180 / Math.PI))), 0, ((float)Math.Cos((currentRotation.y) / (180 / Math.PI))));
                //rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot * 5);
                transform.Rotate(Vector3.forward * -1f);

            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.forward * 1f);
                //Vector3 torqueVector = new Vector3(((float)Math.Sin((currentRotation.y) / (180 / Math.PI))), 0, ((float)Math.Cos((currentRotation.y) / (180 / Math.PI))));
                //rb.AddTorque(torqueVector * wspolczynnik_sily * obrot * 5);
            }
            Vector3 angularVelocity = rb.angularVelocity;
            rotacjaX = currentRotation.x;
            rotacjaYv=angularVelocity.y;
            if (rotacjaYv > 0)
            {
                Vector3 torqueVector = new Vector3(0, (float)0.5, 0);
                rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot);
            }
            if (rotacjaYv < 0)
            {
                Vector3 torqueVector = new Vector3(0, (float)0.5, 0);
                rb.AddTorque(torqueVector * wspolczynnik_sily * obrot);
            }
            if (rotacjaZ > 180)
            {
                torp = 0;
                Vector3 torqueVector = new Vector3((float)Math.Sin((currentRotation.y) / (180 / Math.PI)), 0, (float)Math.Cos((currentRotation.y) / (180 / Math.PI)));
                rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot * (float)0.2);
                //rb.AddTorque(Vector3.right * -0.01f, ForceMode.VelocityChange);
            }
            if (rotacjaZ < 180)
            {
                torp = 1;
                Vector3 torqueVector = new Vector3((float)Math.Sin((currentRotation.y) / (180 / Math.PI)), 0, (float)Math.Cos((currentRotation.y) / (180 / Math.PI)));
                rb.AddTorque(torqueVector * wspolczynnik_sily * obrot * (float)0.2);
                //rb.AddTorque(Vector3.right * 0.01f, ForceMode.VelocityChange);
            }
            if (rotacjaX > 180)
            {
                torb = 0;
                Vector3 torqueVector = new Vector3(-(float)Math.Cos((currentRotation.y) / (180 / Math.PI)), 0, (float)Math.Sin((currentRotation.y) / (180 / Math.PI)));
                rb.AddTorque(torqueVector * wspolczynnik_sily * -obrot*(float)0.1);
            }
            if (rotacjaX < 180)
            {
                torb = 1;
                Vector3 torqueVector = new Vector3(-(float)Math.Cos((currentRotation.y) / (180 / Math.PI)), 0, (float)Math.Sin((currentRotation.y) / (180 / Math.PI)));
                rb.AddTorque(torqueVector * wspolczynnik_sily * obrot*(float)0.1);
            }
        }
    }
}
