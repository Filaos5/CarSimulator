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
    public Camera mainCamera; // Przypisz kamer� "mania camera" w edytorze Unity
    public Camera kameraMapa;
    public int numer_wyscigu;
    public int mapa;
    public int mapa_p;
    void Awake()
    {

    }
    void UsunScene()
    {
        // Usu� za�adowan� scen� po 3 sekundach
        SceneManager.UnloadSceneAsync(0);
    }
    void Start()
    {
        PlayerPrefs.SetInt("mapa", 0);
        if (Time.timeScale == 0f)
        {
            // Wy��cz kamer� "mania camera"
            mainCamera.enabled = false;

            // W��cz kamer� "kamera_mapa"
            kameraMapa.enabled = true;
            UIMiniMapa.SetActive(false);
        }
    }
    // Wy��cz rzucanie cieni dla wszystkich innych �wiate� kierunkowych
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
        if(Time.timeScale == 0.02f)
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
            // Sprawd�, czy �wiat�o zosta�o znalezione
            if (sunLight != null)
            {
                // Wy��cz �wiat�o
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
            // Wy��cz kamer� "mania camera"
            mainCamera.enabled = false;
            PlayerPrefs.SetInt("mapa", 0);
            // W��cz kamer� "kamera_mapa"
            kameraMapa.enabled = true;
            Time.timeScale = 0f;
            mapa_p = 1;
            UIMiniMapa.SetActive(false);
            StartCoroutine(mapa_k());

        }
        if (Input.GetKeyDown(KeyCode.M) && mapa == 1)
        {
            // Wy��cz kamer� "mania camera"
            mainCamera.enabled = true;
            PlayerPrefs.SetInt("mapa", 1);
            // W��cz kamer� "kamera_mapa"
            kameraMapa.enabled = false;
            Time.timeScale = 1f;
            mapa_p = 0;
            UIMiniMapa.SetActive(true);
            StartCoroutine(mapa_w());
        }
    }
}
