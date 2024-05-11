using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Postac : MonoBehaviour
{
    public Animation animationComponent; // Komponent Animation na obiekcie
   // public AnimationClip defaultAnimationClip; // Domyúlna animacja
    //public AnimationClip alternateAnimationClip; // Alternatywna animacja
    //public AnimationClip animacja1; // Pierwsza animacja
    //public AnimationClip animacja2; // Druga animacja
    private bool isAlternateAnimationPlaying = false; // Flaga wskazujπca, czy odtwarzana jest alternatywna animacja
    private bool czyBiega = false;
    private bool czyRuszasie = false;
    public string nazwa_kamery;
    public float stan = 0;
    public GameObject obiekt;
    float nowa_rotacja = 0;
    public float nachylenie;
    public bool czyNaZiemi;
    public float distanceToGround;
    Vector3 pozycja_poprzdnia;
    //public GameObject kamera_gracza;
    Animator animator;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 terrainNormal = hit.normal;
            nachylenie = Mathf.Acos(Vector3.Dot(terrainNormal, Vector3.up)) * Mathf.Rad2Deg;
        }
        if (Math.Abs(nachylenie) < 30)
        {
            transform.rotation = Quaternion.Euler(0, nowa_rotacja, 0);
        }
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            distanceToGround = hit.distance;
            Debug.Log("Odleg≥oúÊ do pod≥oøa: " + distanceToGround);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        // Obiekt wszed≥ w obszar triggera innego obiektu
        //kolidujeZInnymObiektem = true;
        //Debug.Log("Zderzenie z innym obiektem: " + other.gameObject.name);
        stan = 1;
        //GameObject postac = GameObject.Find("postac_gracza");
        //Rigidbody rb = postac.GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
    }

    void OnTriggerExit(Collider other)
    {
        stan = 0;
        // Obiekt opuúci≥ obszar triggera innego obiektu
        //kolidujeZInnymObiektem = false;
        //Debug.Log("ZakoÒczenie zderzenia z innym obiektem: " + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)
    {
        stan = 1;
        // Ustaw zmiennπ na true, gdy obiekt nadal koliduje z innym obiektem
        //kolidujeZInnymObiektem = true;
    }
    void Start()
    {
        
        // Pobierz komponent Animator przypisany do tego obiektu
        animator = GetComponent<Animator>();

        // Sprawdü, czy komponent Animator zosta≥ znaleziony
        if (animator == null)
        {
            Debug.LogError("Komponent Animator nie zosta≥ znaleziony na tym obiekcie.");
        }
        else
        {
            Debug.Log("Komponent Animator zosta≥ znaleziony na tym obiekcie.");
        }
        // Sprawdü, czy komponent Animation jest przypisany
        GameObject postac = GameObject.Find("postac_gracza");
        Rigidbody rb = postac.GetComponent<Rigidbody>();
        Vector3 currentPosition = postac.transform.position;
        pozycja_poprzdnia = currentPosition;

    }

    private void FixedUpdate()
    {
        GameObject kamera_gracza = GameObject.Find("Main Camera");
        //kamera_gracza.transform.parent = transform;
        //Rotate rotateComponent = kamera_gracza.GetComponent<Rotate>();
        //rotateComponent.
        czyNaZiemi = Physics.Raycast(transform.position, -Vector3.up, 0.1f);
        GameObject postac = GameObject.Find("postac_gracza");
        Rigidbody rb = postac.GetComponent<Rigidbody>();
        Vector3 currentPosition = postac.transform.position;
        float rotationY = kamera_gracza.transform.eulerAngles.y;
        
        Kamera kamera = FindObjectOfType<Kamera>();
        if (kamera.obiekt_rodzaj == 0)
        {

            if (Input.GetKey(KeyCode.W))
            {
                nowa_rotacja = rotationY;
                //Debug.Log("Nacisieto idz prosto.");
            }
            if (Input.GetKey(KeyCode.S))
            {
                nowa_rotacja = rotationY + 180;
            }
            if (Input.GetKey(KeyCode.A))
            {
                nowa_rotacja = rotationY + 270;
            }
            if (Input.GetKey(KeyCode.D))
            {
                nowa_rotacja = rotationY + 90;
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                nowa_rotacja = rotationY + 45;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                nowa_rotacja = rotationY + 135;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                nowa_rotacja = rotationY + 225;
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                nowa_rotacja = rotationY + 315;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (distanceToGround < 0.5)
                {
                    currentPosition.x = currentPosition.x + (float)Math.Sin((nowa_rotacja) / (180 / Math.PI)) * (float)0.04;
                    currentPosition.z = currentPosition.z + (float)Math.Cos((nowa_rotacja) / (180 / Math.PI)) * (float)0.04;
                }
                rb.position = currentPosition;
                pozycja_poprzdnia = currentPosition;
                czyRuszasie = true;
            }
            else
            {
                // Ustawienie zmiennej bool na false, jeúli klawisz nie jest trzymany
                czyRuszasie = false;
                rb.position = pozycja_poprzdnia;
            }

            // Ustawienie zmiennej bool w komponencie Animator na podstawie zmiennej czyBiega
            animator.SetBool("ruch", czyRuszasie);
            if (Input.GetKey(KeyCode.Space) && czyRuszasie == true)
            {
                // Ustawienie zmiennej bool na true, jeúli klawisz jest trzymany
                czyBiega = true;
                if (distanceToGround<0.5)
                {
                    currentPosition.x = currentPosition.x + (float)Math.Sin((nowa_rotacja) / (180 / Math.PI)) * (float)0.11;
                    currentPosition.z = currentPosition.z + (float)Math.Cos((nowa_rotacja) / (180 / Math.PI)) * (float)0.11;
                }
                rb.position = currentPosition;
            }
            else
            {
                // Ustawienie zmiennej bool na false, jeúli klawisz nie jest trzymany
                czyBiega = false;
            }

            // Ustawienie zmiennej bool w komponencie Animator na podstawie zmiennej czyBiega
            animator.SetBool("bieg", czyBiega);

            if (stan == 0)
            {
                pozycja_poprzdnia = currentPosition;
            }
        }
        transform.rotation = Quaternion.Euler(0, nowa_rotacja, 0);

    }
}
