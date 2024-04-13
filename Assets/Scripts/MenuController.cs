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
    }

    public void Exit()
    {
        Application.Quit();
    }
}
