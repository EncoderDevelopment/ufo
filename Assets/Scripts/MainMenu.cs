using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayUfo() {
        SceneManager.LoadScene("Ufo");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLabirinto()
    {
        SceneManager.LoadScene("Labirinto");

    }

   

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }

}
