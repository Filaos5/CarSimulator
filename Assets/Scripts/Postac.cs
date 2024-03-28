using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Postac : MonoBehaviour
{
    public Animation animationComponent; // Komponent Animation na obiekcie
    public AnimationClip defaultAnimationClip; // Domyœlna animacja
    public AnimationClip alternateAnimationClip; // Alternatywna animacja
    private bool isAlternateAnimationPlaying = false; // Flaga wskazuj¹ca, czy odtwarzana jest alternatywna animacja
    public Rigidbody rb;
    public string nazwa_kamery;
    public GameObject obiekt;
    //public GameObject kamera_gracza;

    void Update()
    {
        // SprawdŸ, czy naciœniêto przycisk
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Jeœli aktualnie odtwarzana jest domyœlna animacja, prze³¹cz na alternatywn¹
            if (!isAlternateAnimationPlaying)
            {
                // Odtwórz alternatywn¹ animacjê
                animationComponent.CrossFade(alternateAnimationClip.name);
                isAlternateAnimationPlaying = true;
            }
            else // Jeœli aktualnie odtwarzana jest alternatywna animacja, prze³¹cz na domyœln¹
            {
                // Odtwórz domyœln¹ animacjê
                animationComponent.CrossFade(defaultAnimationClip.name);
                isAlternateAnimationPlaying = false;
            }
        }
    }

    void Start()
    {
        
        // SprawdŸ, czy zosta³y przypisane animacje
        if (animationComponent != null && defaultAnimationClip != null && alternateAnimationClip != null)
        {
            // Dodaj animacje do komponentu Animation
            animationComponent.AddClip(defaultAnimationClip, defaultAnimationClip.name);
            animationComponent.AddClip(alternateAnimationClip, alternateAnimationClip.name);

            // Ustaw domyœln¹ animacjê na odtwarzanie
            animationComponent.Play(defaultAnimationClip.name);
        }
        else
        {
            Debug.LogWarning("Nieprawid³owe przypisanie animacji.");
        }

    }

    private void FixedUpdate()
    {
        //GameObject kamera_gracza = GameObject.Find(nazwa_kamery);
        //kamera_gracza.transform.parent = transform;
        //Rotate rotateComponent = kamera_gracza.GetComponent<Rotate>();
        //rotateComponent.
        Vector3 currentPosition = transform.position;
        float rotationY = obiekt.transform.eulerAngles.y;
        float nowa_rotacja = 0;
        if (Input.GetKey(KeyCode.W))
        {
            nowa_rotacja = rotationY;
            //Debug.Log("Nacisieto idz prosto.");
        }
        if (Input.GetKey(KeyCode.S))
        {
            nowa_rotacja = rotationY+180;
        }
        if (Input.GetKey(KeyCode.A))
        {
            nowa_rotacja = rotationY+270;
        }
        if (Input.GetKey(KeyCode.D))
        {
            nowa_rotacja = rotationY+90;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            nowa_rotacja = rotationY+45;
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
        transform.rotation = Quaternion.Euler(0f, nowa_rotacja, 0f);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            currentPosition.x = currentPosition.x + (float)Math.Sin((nowa_rotacja) / (180 / Math.PI)) * (float)0.08;
            currentPosition.z = currentPosition.z + (float)Math.Cos((nowa_rotacja) / (180 / Math.PI)) * (float)0.08;
            rb.position = currentPosition;
        }
    }
}
