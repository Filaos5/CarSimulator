using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Unity.Collections;
public class Kamera : MonoBehaviour
{
    public GameObject postac_gracza;
    public Vector3 distance;
    public float lookUp;
    public Transform carplayertransform;
    public Rigidbody carplayertransform_p;
    public float pozycja_myszy_x = 0;
    float pozycja_myszy_y = 0;
    public float zmianax = 0;
    public float zmianay = 0;
    float mouseX = 0;
    float mouseY = 0;
    public int obiekt_rodzaj =0; // 0 postaæ, 1 auto, 2 helikopter, 3 samolot ma³y, 4 samolot du¿y, 5 Starship
    float rotacja_zapisana=0;
    public float licznik_myszy = 0;
    float rotuj = 0;
    public float rotationY;
    public string nazwa_samochodu;
    public string nazwa_gracza;
    Vector3 myVector;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        GameObject targetObject = GameObject.Find(nazwa_gracza);
        transform.position = targetObject.transform.position + myVector;
        //transform.position = postac_gracza.transform.position + myVector;
        transform.LookAt(postac_gracza.transform.position);
        transform.Rotate(lookUp, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //bool arrowKeysPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        // Jeœli którykolwiek z klawiszy strza³ek jest wciœniêty, odblokuj kursor myszy
        // if (arrowKeysPressed)
        //  {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (obiekt_rodzaj == 0 && time > 1)
            {
                obiekt_rodzaj = 1;
                time = 0;

            }
            if (obiekt_rodzaj == 1 && time > 1)
            {
                obiekt_rodzaj = 0;
                time = 0;
            }
        }
        Cursor.lockState = CursorLockMode.None;
        //     mouseX = 0;
        //     mouseY = 0;
        //}
        //  else
        //  {
        Vector3 mousePos = Input.mousePosition;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        zmianax = zmianax + (mouseX) * 3;
        zmianay = zmianay + (mouseY) * (float)0.1;
        licznik_myszy = licznik_myszy + 1;
        if (pozycja_myszy_x != mouseX || pozycja_myszy_y != mouseY)
        {
            pozycja_myszy_x = mouseX;
            pozycja_myszy_y = mouseY;
            licznik_myszy = 0;
            //rotuj = 0;
            Debug.Log("Licznik zero.");
        }
        //  }

        if (zmianay < -2.9)
        {
            zmianay = (float)-2.9;
        }
        if (zmianay > 4)
        {
            zmianay = 4;
        }
        Vector3 currentVelocity = carplayertransform_p.velocity;
        Vector3 currentRotation = carplayertransform.rotation.eulerAngles;
        rotationY = currentRotation.y;
        //if (currentVelocity.x == 0 && currentVelocity.z == 0)
        //{
        if (obiekt_rodzaj > 0 && obiekt_rodzaj < 5)
        {
            if (licznik_myszy > 100)
            {
                if (rotuj == 1)
                {
                    zmianax = zmianax - rotationY;
                    rotacja_zapisana = rotationY;
                    rotuj = 0;
                    Debug.Log("Rotowanie1.");
                }
                if (zmianax < -180)
                {
                    zmianax = zmianax + 360;
                }
                if (zmianax > 180)
                {
                    zmianax = zmianax - 360;
                }
                if (zmianax > 0)
                {
                    zmianax = zmianax - (float)0.5;
                }
                if (zmianax < 0)
                {
                    zmianax = zmianax + (float)0.5;
                }
                if (zmianax > -1 && zmianax < 1)
                {
                    zmianax = 0;
                }
                //* (float)Math.Cos(zmianay*20))
                if (obiekt_rodzaj == 1)
                {
                    myVector = new Vector3((-10 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax) / (180 / Math.PI)), 3 + zmianay, (-10 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax) / (180 / Math.PI))); // dla auta
                }
                if (obiekt_rodzaj == 4)
                {
                    myVector = new Vector3((-50 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax) / (180 / Math.PI)), 10 + zmianay, (-50 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax) / (180 / Math.PI))); // dla samolotu
                }
            }
            else
            {
                if (rotuj == 0)
                {
                    zmianax = zmianax + rotationY;
                    rotacja_zapisana = rotationY;
                    rotuj = 1;
                    Debug.Log("Rotowanie2.");
                }
                if (obiekt_rodzaj == 1)
                {
                    myVector = new Vector3((-10 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((zmianax) / (180 / Math.PI)), 3 + zmianay, (-10 * (float)Math.Cos(zmianay / 3)) * (float)Math.Cos((zmianax) / (180 / Math.PI))); // dla auta
                }
                if (obiekt_rodzaj == 4)
                {
                    myVector = new Vector3((-50 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((zmianax) / (180 / Math.PI)), 10 + zmianay, (-50 * (float)Math.Cos(zmianay / 3)) * (float)Math.Cos((zmianax) / (180 / Math.PI))); // dla samolotu
                }
            }
        }
            if (obiekt_rodzaj == 0)
            {
                myVector = new Vector3((-3 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((zmianax) / (180 / Math.PI)), 2 + zmianay, (-3 * (float)Math.Cos(zmianay / 3)) * (float)Math.Cos((zmianax) / (180 / Math.PI))); // pieszo
                GameObject targetObject = GameObject.Find(nazwa_gracza);
                transform.position = targetObject.transform.position + myVector;
                //transform.position = postac_gracza.transform.position + myVector;
                transform.LookAt(postac_gracza.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 1)
            {
                GameObject targetObject = GameObject.Find(nazwa_samochodu);
                transform.position = targetObject.transform.position + myVector;
                transform.LookAt(targetObject.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
    }
}
