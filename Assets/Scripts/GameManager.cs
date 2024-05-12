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
    public int mapa;
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

    }
    // Wy³¹cz rzucanie cieni dla wszystkich innych œwiate³ kierunkowych
    IEnumerator mapa_k()
    {
        yield return new WaitForSecondsRealtime(3f);
        mapa = 1;
    }
    IEnumerator mapa_w()
    {
        yield return new WaitForSecondsRealtime(3f);
        mapa = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f && menu==1)
        {
            UIMiniMapa.SetActive(true);
            menu = 0;
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

            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = true;
            Time.timeScale = 0f;
            UIMiniMapa.SetActive(false);
            StartCoroutine(mapa_k());

        }
        if (Input.GetKeyDown(KeyCode.M) && mapa == 1)
        {
            // Wy³¹cz kamerê "mania camera"
            mainCamera.enabled = true;

            // W³¹cz kamerê "kamera_mapa"
            kameraMapa.enabled = false;
            Time.timeScale = 1f;
            UIMiniMapa.SetActive(true);
            StartCoroutine(mapa_w());
        }
    }
}
