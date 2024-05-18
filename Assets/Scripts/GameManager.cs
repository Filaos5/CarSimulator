using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject postac_gracza;
    //public GameObject prefabPostacGracza;
    // Start is called before the first frame update
    public GameObject UIMiniMapa;
    int menu;
    public Camera mainCamera; // Przypisz kamerê "mania camera" w edytorze Unity
    public Camera kameraMapa;
    public int numer_wyscigu;
    public int wyscig_stan;
    public int mapa;
    public int mapa_p;
    public TextMeshProUGUI textMeshPro;
    void Awake()
    {

    }
    void UsunScene()
    {
        // Usuñ za³adowan¹ scenê po 3 sekundach
        SceneManager.UnloadSceneAsync(0);
    }
    void Start()
    {
        PlayerPrefs.SetInt("mapa", 0);
        if (Time.timeScale == 0f)
        {
            // Wy³¹cz kamerê "mania camera"
            mainCamera.enabled = false;

            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = true;
            UIMiniMapa.SetActive(false);
        }
    }
    IEnumerator odliczanie()
    {
        Time.timeScale = 0f;
        textMeshPro.gameObject.SetActive(true);
        textMeshPro.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        wyscig_stan = 2;
        textMeshPro.text = "START!";
        yield return new WaitForSecondsRealtime(1f);
        textMeshPro.gameObject.SetActive(false);
        //StartCoroutine(start());
        //textMeshPro.text = "START!";
        //yield return new WaitForSecondsRealtime(10f);
        //yield return new WaitForSecondsRealtime(1f);
        //textMeshPro.gameObject.SetActive(false);
    }
    IEnumerator start()
    {
        textMeshPro.gameObject.SetActive(true);
        //yield return new WaitForSecondsRealtime(3f);
        textMeshPro.text = "START!";
        yield return new WaitForSecondsRealtime(2f);
        textMeshPro.gameObject.SetActive(false);
    }
    // Wy³¹cz rzucanie cieni dla wszystkich innych œwiate³ kierunkowych
    IEnumerator mapa_k()
    {
        yield return new WaitForSecondsRealtime(1f);
        mapa = 1;
    }
    IEnumerator mapa_w()
    {
        yield return new WaitForSecondsRealtime(1f);
        mapa = 0;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        mapa_p = PlayerPrefs.GetInt("mapa");
        if (mapa_p == 1 && menu==0)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            kameraMapa.enabled = true;
            mainCamera.enabled = false;
        }
        if (mapa_p == 0 && menu == 0)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            kameraMapa.enabled = false;
            mainCamera.enabled = true;
        }
        */

        if (wyscig_stan == 1)
        {
            GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag("Znacznik");

            // Przeiteruj przez wszystkie znalezione obiekty
            foreach (GameObject obj in objectsToHide)
            {
                Renderer objRenderer = obj.GetComponent<Renderer>();
                if (objRenderer != null)
                {
                    // Ustaw obiekt na niewidoczny
                    objRenderer.enabled = false;
                }
            }
            StartCoroutine(odliczanie());
            //StartCoroutine(start());
            wyscig_stan = 2;

        }
        if (wyscig_stan == 2)
        {
            
            wyscig_stan = 3;
            //StartCoroutine(start());
        }
        if (Input.GetKeyDown(KeyCode.Space) && wyscig_stan == 4)
        {
            textMeshPro.gameObject.SetActive(false);
            wyscig_stan = 0;
            GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag("Znacznik");

            // Przeiteruj przez wszystkie znalezione obiekty
            foreach (GameObject obj in objectsToHide)
            {
                Renderer objRenderer = obj.GetComponent<Renderer>();
                if (objRenderer != null)
                {
                    // Ustaw obiekt na niewidoczny
                    objRenderer.enabled = true;
                }
            }
        }
        if (Time.timeScale == 0.02f)
        {
            mainCamera.enabled = true;
            kameraMapa.enabled = false;
            UIMiniMapa.SetActive(true);
            Time.timeScale = 1f;
            mapa_p = 0;
        }
        if(Time.timeScale == 0.1f && menu==1)
        {
            UIMiniMapa.SetActive(true);
            menu = 0;
        }
        if (Time.timeScale == 0.1f)
        {
            UIMiniMapa.SetActive(false);
            Time.timeScale = 0f;
            mainCamera.enabled = false;
            kameraMapa.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Light sunLight = GameObject.Find("Sun").GetComponent<Light>();
            UIMiniMapa.SetActive(false);
            // SprawdŸ, czy œwiat³o zosta³o znalezione
            if (sunLight != null)
            {
                // Wy³¹cz œwiat³o
                //sunLight.enabled = false;
            }
            //SceneManager.LoadScene(0);
            SceneManager.LoadScene(2, LoadSceneMode.Additive);

            // Rozpocznij odliczanie czasu
            //Invoke("UsunScene", 3f);
            Cursor.visible = true;
            Time.timeScale = 0f;
            menu = 1;
        }
        if (Input.GetKeyDown(KeyCode.M) && mapa==0)
        {
            // Wy³¹cz kamerê "mania camera"
            mainCamera.enabled = false;
            PlayerPrefs.SetInt("mapa", 0);
            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = true;
            Time.timeScale = 0f;
            mapa_p = 1;
            UIMiniMapa.SetActive(false);
            StartCoroutine(mapa_k());

        }
        if (Input.GetKeyDown(KeyCode.M) && mapa == 1)
        {
            // Wy³¹cz kamerê "mania camera"
            mainCamera.enabled = true;
            PlayerPrefs.SetInt("mapa", 1);
            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = false;
            Time.timeScale = 1f;
            mapa_p = 0;
            UIMiniMapa.SetActive(true);
            StartCoroutine(mapa_w());
        }
    }
}
