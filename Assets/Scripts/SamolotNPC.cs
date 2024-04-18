using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class SamolotNPC : MonoBehaviour
{
    public Rigidbody rb;
    public float cel_x;
    public float cel_y;
    public float cel_z;
    int randomNumber = 0;
    public float RotacjaX;
    public float RotacjaY;
    public float RotacjaZ;
    public float pozycjaX;
    public float pozycjaZ;
    public float kierunek_lotu = 0f;
    public float kierunek = 0f;
    public float roznica;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = 0;
        currentPosition.y = 500;
        currentPosition.z = -5000;
        cel_x = UnityEngine.Random.Range(-6000, 6001);
        cel_z = UnityEngine.Random.Range(-6000, 6001);
        cel_y = UnityEngine.Random.Range(400, 800);
        rb.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        Vector3 currentPosition = transform.position;
        Vector3 currentVelocity = rb.velocity;
        //rb.AddForce(-currentVelocity.x / 8, -currentVelocity.y / 10, -currentVelocity.z / 8);
        // Vector3 currentVelocity = rb.velocity;
        //currentPosition.x = 0;
        //currentPosition.y = currentPosition.y + 10;
        //currentPosition.z = currentPosition.z +20;
        //rb.position = currentPosition;

        if ((Math.Abs(currentPosition.x - cel_x) + Math.Abs(currentPosition.z - cel_z)) < 1000)
        {
            cel_x = UnityEngine.Random.Range(-6000, 6001);
            cel_z = UnityEngine.Random.Range(-6000, 6001);
            cel_y = UnityEngine.Random.Range(400, 800);
        }
        if (currentPosition.y < cel_y)
        {
            currentPosition.y = currentPosition.y + (float)0.1;
        }
        if (currentPosition.y > cel_y)
        {
            currentPosition.y = currentPosition.y - (float)0.1;
        }
        

        float arcTanValue = Mathf.Atan2((cel_x - currentPosition.x), (cel_z - currentPosition.z));
        pozycjaZ = currentPosition.z;
        pozycjaX = currentPosition.x;
        // Konwersja z radianów na stopnie
        kierunek_lotu = Mathf.Rad2Deg * arcTanValue;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        kierunek = currentRotation.y;
        currentPosition.x = currentPosition.x + (float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 3;
        currentPosition.z = currentPosition.z + (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 3;
;        rb.position = currentPosition;
        if (kierunek_lotu < 0)
        {
            kierunek_lotu = kierunek_lotu + 360f;
        }
        if (kierunek < 0)
        {
            kierunek = kierunek + 360f;
        }
        float roznica1 = (kierunek - kierunek_lotu);
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
                transform.Rotate(Vector3.up * (0.1f));
            }
            else
            {
                transform.Rotate(Vector3.up * (-0.1f));
            }
            if (transform.rotation.eulerAngles.x > 0f)
            {
                // Zmniejsz rotacjê w osi x o 0.1 na ka¿dej klatce
                transform.Rotate(Vector3.left * 0.1f);
            }

            // SprawdŸ czy rotacja w osi z jest wiêksza od zera
            if (transform.rotation.eulerAngles.z > 0f)
            {
                // Zmniejsz rotacjê w osi z o 0.1 na ka¿dej klatce
                transform.Rotate(Vector3.forward * -0.1f);
            }
            if (transform.rotation.eulerAngles.x < 0f)
            {
                // Zmniejsz rotacjê w osi x o 0.1 na ka¿dej klatce
                transform.Rotate(Vector3.left * (-0.1f));
            }

            // SprawdŸ czy rotacja w osi z jest wiêksza od zera
            if (transform.rotation.eulerAngles.z < 0f)
            {
                // Zmniejsz rotacjê w osi z o 0.1 na ka¿dej klatce
                transform.Rotate(Vector3.forward * 0.1f);
            }
            //rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 10, -(float)Math.Sin((currentRotation.x + 0) / (180 / Math.PI)) * 5, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 10);

            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            //rb.AddForce((float)Math.Sin((currentRotation.y + 0) / (180 / Math.PI)) * 300, 0, (float)Math.Cos((currentRotation.y + 0) / (180 / Math.PI)) * 300);
            RotacjaX =currentRotation.x;
            RotacjaY=currentRotation.y;
            RotacjaZ=currentRotation.z;

        }
    }
}
