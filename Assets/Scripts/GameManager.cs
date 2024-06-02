using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //public GameObject postac_gracza;
    //public GameObject prefabPostacGracza;
    // Start is called before the first frame update
    public GameObject UIMiniMapa;
    public GameObject slonce;
    public int menu;
    public Camera mainCamera; // Przypisz kamerê "mania camera" w edytorze Unity
    public Camera kameraMapa;
    public int numer_wyscigu;
    public Quaternion originalRotation;
    public int wyscig_stan;
    public int mapa;
    public int mapa_p;
    public TextMeshProUGUI textMeshPro;
    public float shadowDistance = 1000.0f; // Ustaw po¿¹dan¹ odleg³oœæ cieni
    //public Volume volume;  // Referencja do Volume w scenie

    //private HDShadowSettings shadowSettings;
    private bool ResetCarIsPressed = false;
    private float ResetCarTimePressed = 0.0f;
    private float ResetCarRequiredHoldTime = 5.0f;

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
        /*
        if (volume.profile.TryGet(out shadowSettings))
        {
            shadowSettings.maxShadowDistance.value = shadowDistance;
        }
        else
        {
            Debug.LogError("HDShadowSettings not found in Volume profile.");
        }
        */
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
            menu = 0;
            slonce.transform.rotation = originalRotation;
        }
        if (Time.timeScale == 0.1f && menu == 1)
        {
            UIMiniMapa.SetActive(true);
            menu = 0;
            //slonce.transform.rotation = originalRotation;
        }
        if (Time.timeScale == 0.1f)
        {
            UIMiniMapa.SetActive(false);
            Time.timeScale = 0f;
            mainCamera.enabled = false;
            kameraMapa.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menu==0)
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
            Transform objTransform = slonce.GetComponent<Transform>();
            if (mapa == 0)
            {
                originalRotation = objTransform.rotation;
                slonce.transform.rotation = Quaternion.Euler(90, 80, 0);
            }
            // Rozpocznij odliczanie czasu
            //Invoke("UsunScene", 3f);
            Cursor.visible = true;
            Time.timeScale = 0f;
            menu = 1;
        }
        if (Input.GetKeyDown(KeyCode.M) && mapa == 0)
        {
            kameraMapa.transform.position = new Vector3(mainCamera.transform.position.x, kameraMapa.transform.position.y, mainCamera.transform.position.z);
            kameraMapa.orthographicSize = 1000;
            // Wy³¹cz kamerê "mania camera"
            mainCamera.enabled = false;
            PlayerPrefs.SetInt("mapa", 0);
            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = true;
            Time.timeScale = 0f;
            mapa_p = 1;
            UIMiniMapa.SetActive(false);
            // Pobierz komponent Transform obiektu
            Transform objTransform = slonce.GetComponent<Transform>();
            originalRotation = objTransform.rotation;
            slonce.transform.rotation = Quaternion.Euler(90, 80, 0);
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
            slonce.transform.rotation = originalRotation;
            mapa_p = 0;
            UIMiniMapa.SetActive(true);
            StartCoroutine(mapa_w());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCarIsPressed = true;
            ResetCarTimePressed = Time.time;
        }
        if (Input.GetKey(KeyCode.R) && ResetCarIsPressed)
        {
            if (Time.time - ResetCarTimePressed >= ResetCarRequiredHoldTime)
            {
                Kamera kamera_o = mainCamera.GetComponent<Kamera>();
                string nazwa_pojazdu = kamera_o.nazwa_aktualnego_pojazdu;
                int rodzaj_pojazdu = kamera_o.obiekt_rodzaj;
                if (rodzaj_pojazdu == 1)
                {
                    GameObject obiekt = GameObject.Find(nazwa_pojazdu);
                    obiekt.transform.rotation = Quaternion.Euler(obiekt.transform.eulerAngles.x, obiekt.transform.eulerAngles.y, 0);
                }
                ResetCarIsPressed = false;
            }
        }
    }
}
