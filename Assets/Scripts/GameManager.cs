using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject postac_gracza;
    //public GameObject prefabPostacGracza;
    // Start is called before the first frame update
    public GameObject UIMiniMapa;
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

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
