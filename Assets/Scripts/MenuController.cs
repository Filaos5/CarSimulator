using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        Cursor.visible = false;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("mapa", 0);
    }

    public void LoadMap(int index)
    {
        PlayerPrefs.SetInt("mapa", 1);
        Time.timeScale = 0f;
        SceneManager.LoadScene(index);
        Cursor.visible = true;
        Time.timeScale = 0.1f;
    }

    public void LoadMapAdd(int index)
    {
        Cursor.visible = false;
        SceneManager.UnloadSceneAsync(2);
        Light sunLight = GameObject.Find("Sun").GetComponent<Light>();
        GameObject UIMiniMapa = GameObject.Find("UIMiniMapa");
        PlayerPrefs.SetInt("mapa", 1);
        // Sprawdü, czy úwiat≥o zosta≥o znalezione
        if (sunLight != null)
        {
            // Wy≥πcz úwiat≥o
            sunLight.enabled = true;
        }
        Time.timeScale = 0.1f;
    }

    public void ExitMenu(int index)
    {
        SceneManager.UnloadSceneAsync(2);
        Light sunLight = GameObject.Find("Sun").GetComponent<Light>();
        GameObject UIMiniMapa = GameObject.Find("UIMiniMapa");
        // Sprawdü, czy úwiat≥o zosta≥o znalezione
        if (sunLight != null)
        {
            // Wy≥πcz úwiat≥o
            sunLight.enabled = true;
        }
        Time.timeScale = 0.02f;
        /*
        int mapa_p = PlayerPrefs.GetInt("mapa");
        if (mapa_p == 1)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
            //UIMiniMapa.SetActive(false);
        }
        if (mapa_p == 0)
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
            //UIMiniMapa.SetActive(true);
        }
        */
        // Rozpocznij odliczanie czasu
        //Invoke("UsunScene", 3f);



    }

    public void Exit()
    {
        Application.Quit();
    }
}
