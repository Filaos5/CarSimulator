using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kamera_mapy : MonoBehaviour
{
    public float scrollSpeed = 1f; // Pr�dko�� zwi�kszania pozycji y
    public Camera objectToMove;
    public int windowWidth;
    public int windowHeight;
    public float wysokosc;
    public float mouse_x;
    public float mouse_y;
    public GameManager gameManager;
    int menu = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Pobierz warto�� skoku myszy
        Vector3 mousePosition = Input.mousePosition;
        mouse_x = mousePosition.x;
        mouse_y = mousePosition.y;
        // Zwi�ksz lub zmniejsz pozycj� y obiektu w zale�no�ci od kierunku skoku myszy
        Vector3 pozycja = transform.position;
        wysokosc = objectToMove.orthographicSize;
        menu = gameManager.menu;
        if (menu == 0)
        {
            
            if (wysokosc <= 100)
            {
                wysokosc = 101;
            }
            if (wysokosc >= 8000)
            {
                wysokosc = 7999;
            }
            if (wysokosc >= 100 && wysokosc <= 8000)
            {

                wysokosc -= scroll * scrollSpeed * wysokosc;
            }
        }
        if (menu == 1)
        {
            wysokosc = 101;
        }
        objectToMove.orthographicSize = wysokosc;

        
        // Sprawd� szeroko�� i wysoko�� okna gry
        windowWidth = Screen.width;
        windowHeight = Screen.height;
        if (pozycja.z < 14000)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                pozycja.z = pozycja.z + 20 + objectToMove.orthographicSize * 0.03f;
            }
            if (Input.GetMouseButton(0) && mouse_y > windowHeight/2)
            {
                pozycja.z = pozycja.z + (mouse_y - windowHeight / 2)*(float)0.1 + objectToMove.orthographicSize * 0.03f;
            }
        }
        if (pozycja.z > -8000)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                pozycja.z = pozycja.z - 20 - objectToMove.orthographicSize * 0.03f;
            }
            if (Input.GetMouseButton(0) && mouse_y < windowHeight / 2)
            {
                pozycja.z = pozycja.z + (mouse_y - windowHeight / 2) * (float)0.1 - objectToMove.orthographicSize * 0.03f;
            }
        }
        if (pozycja.x < 6000) {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                pozycja.x = pozycja.x + 20 + objectToMove.orthographicSize * 0.03f;
            }
            if (Input.GetMouseButton(0) && mouse_x > windowWidth / 2)
            {
                pozycja.x = pozycja.x + (mouse_x - windowWidth / 2) * (float)0.1 + objectToMove.orthographicSize * 0.03f;
            }
        }
        if (pozycja.x > -16000)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                pozycja.x = pozycja.x - 20 - objectToMove.orthographicSize * 0.03f;
            }
            if (Input.GetMouseButton(0) && mouse_x < windowWidth / 2)
            {
                pozycja.x = pozycja.x + (mouse_x - windowWidth / 2) * (float)0.1 - objectToMove.orthographicSize * 0.03f;
            }
        }
        transform.position = pozycja;
    }
}
