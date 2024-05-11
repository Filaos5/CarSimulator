using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wyscig : MonoBehaviour
{
    public GameObject samochod1;
    public GameObject samochod2;
    public GameObject samochod3;
    public bool dotykaCar = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Auto1"))
        {
            dotykaCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Auto1"))
        {
            dotykaCar = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Utwórz instancjê obiektu prefabrykatu w pozycji (0, 0, 100) i bez obrotu
            Instantiate(samochod1, new Vector3(120f, 0f, -1350f), Quaternion.identity);
        }
    }
}
