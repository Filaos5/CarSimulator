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
    }

    public void ExitMenu(int index)
    {
        Cursor.visible = false;
        SceneManager.UnloadSceneAsync(2);
        Light sunLight = GameObject.Find("Sun").GetComponent<Light>();
        GameObject UIMiniMapa = GameObject.Find("UIMiniMapa");
        // Sprawd�, czy �wiat�o zosta�o znalezione
        if (sunLight != null)
        {
            // Wy��cz �wiat�o
            sunLight.enabled = true;
        }

        // Rozpocznij odliczanie czasu
        //Invoke("UsunScene", 3f);
        Cursor.visible = false;
        Time.timeScale = 1f;
        //UIMiniMapa.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
