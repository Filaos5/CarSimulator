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
    private float[] floatArray_X = new float[5]; // Tablica float o d³ugoœci 5
    private float[] floatArray_Z = new float[5]; // Tablica float o d³ugoœci 5
    private float[] pozycje_X = new float[45]; // Tablica float
    private float[] pozycje_Z = new float[45]; // Tablica float
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
    public float pas = 5;
    int numer_wyscig=0;
    float wspolczynnik_sily = 1000;
    bool isTouchingObject = false; // Flaga informuj¹ca o dotyku z obiektem
    int[] wyscig_Array;
    int[] wyscig1_Array = new int[] { 9, 11, 28, 27, 44 };
    int[] wyscig2_Array = new int[] { 21, 20, 26, 25, 18, 17, 37, 41, 43, 42, 40, 38, 35 };
    int[] wyscig3_Array = new int[] { 21, 2, 5, 16, 15, 28, 27, 32, 31, 20, 21 };
    int[] wyscig4_Array = new int[] { 35, 38, 37, 0, 1, 7, 9, 2, 4, 28, 30, 16, 14, 21, 20 };
    int[] wyscig5_Array = new int[] { 20, 31, 32, 21, 20};
    void Start()
    {
        pozycje_X[0] = -1554;
        pozycje_Z[0] = 1395;
        pozycje_X[1] = -1050;
        pozycje_Z[1] = 1395;
        pozycje_X[2] = 115;
        pozycje_Z[2] = 1395;
        pozycje_X[3] = 538;
        pozycje_Z[3] = 1395;
        pozycje_X[4] = 955;
        pozycje_Z[4] = 1395;
        pozycje_X[5] = 1514;
        pozycje_Z[5] = 1395;
        pozycje_X[6] = -1554;
        pozycje_Z[6] = 825;
        pozycje_X[7] = -1050;
        pozycje_Z[7] = 825;
        pozycje_X[8] = -455;
        pozycje_Z[8] = 825;
        pozycje_X[9] = 115;
        pozycje_Z[9] = 825;
        pozycje_X[10] = 538;
        pozycje_Z[10] = 825;
        pozycje_X[11] = 955;
        pozycje_Z[11] = 825;
        pozycje_X[12] = 1514;
        pozycje_Z[12] = 825;
        pozycje_X[13] = -455;
        pozycje_Z[13] = 507;
        pozycje_X[14] = 115;
        pozycje_Z[14] = 507;
        pozycje_X[15] = 955;
        pozycje_Z[15] = 507;
        pozycje_X[16] = 1514;
        pozycje_Z[16] = 507;
        pozycje_X[17] = -1554;
        pozycje_Z[17] = 272;
        pozycje_X[18] = -1173;
        pozycje_Z[18] = 272;
        pozycje_X[19] = -1050;
        pozycje_Z[19] = 272;
        pozycje_X[20] = -455;
        pozycje_Z[20] = 272;
        pozycje_X[21] = 115;
        pozycje_Z[21] = 272;
        pozycje_X[22] = -1554;
        pozycje_Z[22] = 68;
        pozycje_X[23] = -1173;
        pozycje_Z[23] = 68;
        pozycje_X[24] = -455;
        pozycje_Z[24] = 68;
        pozycje_X[25] = -1173;
        pozycje_Z[25] = -270;
        pozycje_X[26] = -455;
        pozycje_Z[26] = -270;
        pozycje_X[27] = 115;
        pozycje_Z[27] = -270;
        pozycje_X[28] = 955;
        pozycje_Z[28] = -270;
        pozycje_X[29] = 1117;
        pozycje_Z[29] = -270;
        pozycje_X[30] = 1514;
        pozycje_Z[30] = -270;
        pozycje_X[31] = -455;
        pozycje_Z[31] = -964;
        pozycje_X[32] = 115;
        pozycje_Z[32] = -964;
        pozycje_X[33] = 1117;
        pozycje_Z[33] = -871;
        pozycje_X[34] = 1514;
        pozycje_Z[34] = -871;
        pozycje_X[35] = -520;
        pozycje_Z[35] = -2574;
        pozycje_X[36] = 30;
        pozycje_Z[36] = -2574;
        pozycje_X[37] = -1554;
        pozycje_Z[37] = -2893;
        pozycje_X[38] = -520;
        pozycje_Z[38] = -2893;
        pozycje_X[39] = 30;
        pozycje_Z[39] = -2893;
        pozycje_X[40] = 287;
        pozycje_Z[40] = -2893;
        pozycje_X[41] = 642;
        pozycje_Z[41] = -2893;
        pozycje_X[42] = 287;
        pozycje_Z[42] = -3338;
        pozycje_X[43] = 642;
        pozycje_Z[43] = -3338;
        pozycje_X[44] = 115;
        pozycje_Z[44] = -1400;

        GameObject gameManagerObject = GameObject.Find("GameManager");

        if (gameManagerObject != null)
        {
            // Pobierz komponent GameManager z obiektu gameManagerObject
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            numer_wyscig = gameManager.numer_wyscigu;
        }
        wyscig_Array = wyscig1_Array;
        if (numer_wyscig == 2)
        {
            wyscig_Array = wyscig2_Array;
        }
        if (numer_wyscig == 3)
        {
            wyscig_Array = wyscig3_Array;
        }
        if (numer_wyscig == 4)
        {
            wyscig_Array = wyscig4_Array;
            pozycje_Z[35] = -2610;
        }
        if (numer_wyscig == 5)
        {
            wyscig_Array = wyscig5_Array;
        }

        meta_x = pozycje_X[wyscig_Array[0]];
        meta_z = pozycje_Z[wyscig_Array[0]];
        //meta_x = floatArray_X[0];
        //meta_z = floatArray_Z[0];
        pas = 5;

    }
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
            if (currentPosition.x < meta_x)
            {
                cel_z = meta_z - pas;
            }
            if (currentPosition.x > meta_x)
            {
                cel_z = meta_z + pas;
            }
            if (currentPosition.x +100< meta_x)
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
            if (currentPosition.z < meta_z)
            {
                cel_x = meta_x + pas;
            }
            if (currentPosition.z > meta_z)
            {
                cel_x = meta_x - pas;
            }
            //cel_x = meta_x;
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
                if (currentIndex < wyscig_Array.Length)
                {
                    //meta_x = (float)floatArray_X[currentIndex];
                    //meta_z = (float)floatArray_Z[currentIndex];
                    meta_x = (float)pozycje_X[wyscig_Array[currentIndex]];
                    meta_z = (float)pozycje_Z[wyscig_Array[currentIndex]];
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
