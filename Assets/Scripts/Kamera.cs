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
    Vector3 pozycja_pojazdu;
    Vector3 pozycja_postaci;
    public float lookUp;
    //Transform carplayertransform;
    Transform car_aktualny_transform;
    Transform helikopter_aktualny_transform;
    Transform samolot_aktualny_transform;
    //public Rigidbody carplayertransform_p;
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
    public string nazwa_helikoptera;
    public string nazwa_samolotu;
    public string nazwa_gracza;
    public string tagDocelowy = "Auto1"; // Tag obiektów, których odleg³oœæ chcemy sprawdziæ
    public string tagDocelowy_h = "Helikopter"; // Tag obiektów, których odleg³oœæ chcemy sprawdziæ
    public string tagDocelowy_s1 = "Samolot1"; // Tag obiektów, których odleg³oœæ chcemy sprawdziæ
    public string tagDocelowy_s2 = "Samolot2"; // Tag obiektów, których odleg³oœæ chcemy sprawdziæ
    public float odlegloscMax = 10f;
    public string nazwa_aktualnego_pojazdu;
    int wsiadanie;
    Vector3 myVector;
    Vector3 currentRotation;
    public float rotacja_auta = 0;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        GameObject targetObject = Instantiate(postac_gracza, new Vector3(100f, 0f, -1350f), Quaternion.identity);
        //GameObject targetObject = Instantiate(postac_gracza, new Vector3(-350f, 0f, -3250f), Quaternion.identity);
        targetObject.name = "postac_gracza";
        // GameObject targetObject = GameObject.Find("postac_gracza");
        //transform.position = targetObject.transform.position + myVector;
        //transform.position = postac_gracza.transform.position + myVector;
        //transform.LookAt(targetObject.transform.position);
        //transform.Rotate(lookUp, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 currentRotation = carplayertransform.rotation.eulerAngles;
        time += Time.deltaTime;
        //bool arrowKeysPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        // Jeœli którykolwiek z klawiszy strza³ek jest wciœniêty, odblokuj kursor myszy
        // if (arrowKeysPressed)
        //  {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject[] obiektyZTagiem = GameObject.FindGameObjectsWithTag(tagDocelowy);
            GameObject[] obiektyZTagiem_h = GameObject.FindGameObjectsWithTag(tagDocelowy_h);
            GameObject[] obiektyZTagiem_s1 = GameObject.FindGameObjectsWithTag(tagDocelowy_s1);
            GameObject[] obiektyZTagiem_s2 = GameObject.FindGameObjectsWithTag(tagDocelowy_s2);
            wsiadanie = 0;
            // SprawdŸ odleg³oœæ miêdzy obiektem a innymi obiektami
            foreach (GameObject obiekt in obiektyZTagiem)
            {
                float odleglosc = Vector3.Distance(transform.position, obiekt.transform.position);
                if (odleglosc <= odlegloscMax)
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest w zasiêgu. Odleg³oœæ: " + odleglosc);
                    nazwa_aktualnego_pojazdu = obiekt.name;
                    nazwa_samochodu= obiekt.name;
                    car_aktualny_transform = obiekt.transform;
                    wsiadanie = 1;
                }
                else
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest poza zasiêgiem. Odleg³oœæ: " + odleglosc);
                }
            }
            foreach (GameObject obiekt in obiektyZTagiem_h)
            {
                float odleglosc = Vector3.Distance(transform.position, obiekt.transform.position);
                if (odleglosc <= odlegloscMax)
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest w zasiêgu. Odleg³oœæ: " + odleglosc);
                    nazwa_aktualnego_pojazdu = obiekt.name;
                    nazwa_helikoptera = obiekt.name;
                    helikopter_aktualny_transform = obiekt.transform;
                    wsiadanie = 2;
                }
                else
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest poza zasiêgiem. Odleg³oœæ: " + odleglosc);
                }
            }
            foreach (GameObject obiekt in obiektyZTagiem_s1)
            {
                float odleglosc = Vector3.Distance(transform.position, obiekt.transform.position);
                if (odleglosc <= odlegloscMax)
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest w zasiêgu. Odleg³oœæ: " + odleglosc);
                    nazwa_aktualnego_pojazdu = obiekt.name;
                    nazwa_samolotu = obiekt.name;
                    samolot_aktualny_transform = obiekt.transform;
                    wsiadanie = 3;
                }
                else
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest poza zasiêgiem. Odleg³oœæ: " + odleglosc);
                }
            }
            foreach (GameObject obiekt in obiektyZTagiem_s2)
            {
                float odleglosc = Vector3.Distance(transform.position, obiekt.transform.position);
                if (odleglosc <= odlegloscMax)
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest w zasiêgu. Odleg³oœæ: " + odleglosc);
                    nazwa_aktualnego_pojazdu = obiekt.name;
                    nazwa_samolotu = obiekt.name;
                    samolot_aktualny_transform = obiekt.transform;
                    wsiadanie = 4;
                }
                else
                {
                    Debug.Log("Obiekt " + obiekt.name + " jest poza zasiêgiem. Odleg³oœæ: " + odleglosc);
                }
            }
            if (obiekt_rodzaj == 0 && time > 1 && wsiadanie>0)
            {
                obiekt_rodzaj = wsiadanie;
                time = 0;
                wsiadanie = 0;
                GameObject obiektDoZniszczenia = GameObject.Find("postac_gracza");
                Destroy(obiektDoZniszczenia);

            }
            if (obiekt_rodzaj == 1 && time > 1)
            {
                GameObject targetObject = Instantiate(postac_gracza, new Vector3(100f, 0f, -3350f), Quaternion.identity); //100f, 0f, -1350f)
                targetObject.name = "postac_gracza";
                obiekt_rodzaj = 0;
                time = 0;
                currentRotation = car_aktualny_transform.rotation.eulerAngles;
                rotationY = currentRotation.y;
                pozycja_postaci = pozycja_pojazdu + new Vector3(-(float)Math.Cos((rotationY) / (180 / Math.PI))*3, 0f, (float)Math.Sin((rotationY) / (180 / Math.PI))*3);
                //transform.position = postac_gracza.transform.position + myVector;

                targetObject.transform.position = pozycja_postaci;
                transform.LookAt(targetObject.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 2 && time > 1)
            {
                GameObject targetObject = Instantiate(postac_gracza, new Vector3(100f, 0f, -3350f), Quaternion.identity); //100f, 0f, -1350f)
                targetObject.name = "postac_gracza";
                obiekt_rodzaj = 0;
                time = 0;
                currentRotation = helikopter_aktualny_transform.rotation.eulerAngles;
                rotationY = currentRotation.y;
                pozycja_postaci = pozycja_pojazdu + new Vector3(-(float)Math.Sin((rotationY) / (180 / Math.PI)) * 8, 0f, (float)Math.Cos((rotationY) / (180 / Math.PI)) * -10);
                //transform.position = postac_gracza.transform.position + myVector;

                targetObject.transform.position = pozycja_postaci;
                transform.LookAt(targetObject.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 3 && time > 1)
            {
                GameObject targetObject = Instantiate(postac_gracza, new Vector3(100f, 0f, -3350f), Quaternion.identity); //100f, 0f, -1350f)
                targetObject.name = "postac_gracza";
                obiekt_rodzaj = 0;
                time = 0;
                currentRotation = samolot_aktualny_transform.rotation.eulerAngles;
                rotationY = currentRotation.y;
                pozycja_postaci = pozycja_pojazdu + new Vector3(-(float)Math.Cos((rotationY) / (180 / Math.PI)) * 4, 0f, (float)Math.Sin((rotationY) / (180 / Math.PI)) * 4);
                //transform.position = postac_gracza.transform.position + myVector;

                targetObject.transform.position = pozycja_postaci;
                transform.LookAt(targetObject.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 4 && time > 1)
            {
                GameObject targetObject = Instantiate(postac_gracza, new Vector3(100f, 0f, -3350f), Quaternion.identity); //100f, 0f, -1350f)
                targetObject.name = "postac_gracza";
                obiekt_rodzaj = 0;
                time = 0;
                currentRotation = helikopter_aktualny_transform.rotation.eulerAngles;
                rotationY = currentRotation.y;
                pozycja_postaci = pozycja_pojazdu + new Vector3(-(float)Math.Cos((rotationY) / (180 / Math.PI)) * 6, 0f, (float)Math.Sin((rotationY) / (180 / Math.PI)) * 6);
                //transform.position = postac_gracza.transform.position + myVector;

                targetObject.transform.position = pozycja_postaci;
                transform.LookAt(targetObject.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
        }
        Cursor.lockState = CursorLockMode.None;
        Vector3 mousePos = Input.mousePosition;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        zmianax = zmianax + (mouseX) * 3;
        zmianay = zmianay - (mouseY) * (float)0.1;
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
        //Vector3 currentVelocity = carplayertransform_p.velocity;
       //GameObject obiekt_s = GameObject.Find(nazwa_aktualnego_pojazdu);
        //rotationY = currentRotation.y;
        //rotationY = obiekt_s.transform.rotation.y;
        ///rotacja_auta = car_aktualny_transform.rotation.eulerAngles.y;
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
                if (obiekt_rodzaj == 2)
                {
                    myVector = new Vector3((-15 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax +90) / (180 / Math.PI)), 4 + zmianay*2, (-15 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax +90) / (180 / Math.PI))); // dla auta
                }
                if (obiekt_rodzaj == 3)
                {
                    myVector = new Vector3((-20 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax) / (180 / Math.PI)), 5 + zmianay*2, (-20 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax) / (180 / Math.PI))); // dla auta
                }
                if (obiekt_rodzaj == 4)
                {
                    myVector = new Vector3((-50 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax) / (180 / Math.PI)), 10 + zmianay*3, (-50 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax) / (180 / Math.PI))); // dla samolotu
                }
                if (obiekt_rodzaj == 5)
                {
                    myVector = new Vector3((-100 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((rotationY + zmianax) / (180 / Math.PI)), 20 + zmianay*5, (-100 * (float)Math.Cos(zmianay / 4)) * (float)Math.Cos((rotationY + zmianax) / (180 / Math.PI))); // dla samolotu
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
                if (obiekt_rodzaj == 2)
                {
                    myVector = new Vector3((-15 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((zmianax +90) / (180 / Math.PI)), 4 + zmianay, (-15 * (float)Math.Cos(zmianay / 3)) * (float)Math.Cos((zmianax +90) / (180 / Math.PI))); // dla auta
                }
                if (obiekt_rodzaj == 3)
                {
                    myVector = new Vector3((-20 * (float)Math.Cos(zmianay / 4)) * (float)Math.Sin((zmianax) / (180 / Math.PI)), 5 + zmianay, (-20 * (float)Math.Cos(zmianay / 3)) * (float)Math.Cos((zmianax) / (180 / Math.PI))); // dla auta
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
                GameObject targetObject0 = GameObject.Find("postac_gracza");
                transform.position = targetObject0.transform.position + myVector;
                //transform.position = postac_gracza.transform.position + myVector;
                transform.LookAt(targetObject0.transform.position);
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 1)
            {
                GameObject targetObject1 = GameObject.Find(nazwa_samochodu);
                //targetObject1.chil
                transform.position = targetObject1.transform.position + myVector;
                pozycja_pojazdu = targetObject1.transform.position;
                transform.LookAt(targetObject1.transform.position);
                rotationY = targetObject1.transform.rotation.eulerAngles.y;
                transform.Rotate(lookUp, 0, 1);
            }
            if (obiekt_rodzaj == 2)
            {
                GameObject targetObject1 = GameObject.Find(nazwa_helikoptera);
                transform.position = targetObject1.transform.position + myVector;
                pozycja_pojazdu = targetObject1.transform.position;
                transform.LookAt(targetObject1.transform.position);
                rotationY = targetObject1.transform.rotation.eulerAngles.y;
                transform.Rotate(lookUp, 0, 1);
            }
        if (obiekt_rodzaj == 3)
        {
            GameObject targetObject1 = GameObject.Find(nazwa_samolotu);
            transform.position = targetObject1.transform.position + myVector;
            pozycja_pojazdu = targetObject1.transform.position;
            transform.LookAt(targetObject1.transform.position);
            rotationY = targetObject1.transform.rotation.eulerAngles.y;
            transform.Rotate(lookUp, 0, 1);
        }
        if (obiekt_rodzaj == 4)
        {
            GameObject targetObject1 = GameObject.Find(nazwa_samolotu);
            transform.position = targetObject1.transform.position + myVector;
            pozycja_pojazdu = targetObject1.transform.position;
            transform.LookAt(targetObject1.transform.position);
            rotationY = targetObject1.transform.rotation.eulerAngles.y;
            transform.Rotate(lookUp, 0, 1);
        }

    }
}
