using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kamera_mapy : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Prêdkoœæ zwiêkszania pozycji y
    public GameObject objectToMove;
    public int windowWidth;
    public int windowHeight;
    float wysokosc;
    public float mouse_x;
    public float mouse_y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Pobierz wartoœæ skoku myszy
        Vector3 mousePosition = Input.mousePosition;
        mouse_x = mousePosition.x;
        mouse_y = mousePosition.y;
        // Zwiêksz lub zmniejsz pozycjê y obiektu w zale¿noœci od kierunku skoku myszy
        Vector3 pozycja = transform.position;
        wysokosc = objectToMove.transform.position.y;
        if (wysokosc <= 2000)
        {
            wysokosc = 2001;
        }
        if (wysokosc >= 20000)
        {
            wysokosc = 19999;
        }
        if (wysokosc >= 2000 && wysokosc <= 20000)
        {
            wysokosc -=  scroll * scrollSpeed * wysokosc;
        }
        pozycja.y = wysokosc;

        
        // SprawdŸ szerokoœæ i wysokoœæ okna gry
        windowWidth = Screen.width;
        windowHeight = Screen.height;
        if (pozycja.z < 14000)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                pozycja.z = pozycja.z + 20;
            }
            if (Input.GetMouseButton(0) && mouse_y > windowHeight/2)
            {
                pozycja.z = pozycja.z + (mouse_y - windowHeight / 2)*(float)0.1;
            }
        }
        if (pozycja.z > -8000)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                pozycja.z = pozycja.z - 20;
            }
            if (Input.GetMouseButton(0) && mouse_y < windowHeight / 2)
            {
                pozycja.z = pozycja.z + (mouse_y - windowHeight / 2) * (float)0.1;
            }
        }
        if (pozycja.x < 6000) {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                pozycja.x = pozycja.x + 20;
            }
            if (Input.GetMouseButton(0) && mouse_x > windowWidth / 2)
            {
                pozycja.x = pozycja.x + (mouse_x - windowWidth / 2) * (float)0.1;
            }
        }
        if (pozycja.x > -16000)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                pozycja.x = pozycja.x - 20;
            }
            if (Input.GetMouseButton(0) && mouse_x < windowWidth / 2)
            {
                pozycja.x = pozycja.x + (mouse_x - windowWidth / 2) * (float)0.1;
            }
        }
        transform.position = pozycja;
    }
}
