using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject popupMenu;
    private bool startButton = false;
    float timeLeft = 0.1f;

    private void Start()
    {

        if (!SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            popupMenu.gameObject.SetActive(false);
            GameObject ReturnGame = GameObject.Find("ReturnGame");
            if (ReturnGame)
                EventSystem.current.SetSelectedGameObject(ReturnGame);            
        }

    }



    private void Update()
    {
        PauseGame();
    }



    public void PauseGame() {

        if (!SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            if (Input.GetButton("XboxB") || Input.GetKeyDown(KeyCode.Escape))
            {                
                popupMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                Debug.Log("MENU INVISIBLE 1" + popupMenu.gameObject.activeSelf);                
            }
            else if (Input.GetButton("XboxStart") || Input.GetKeyDown(KeyCode.M))
            {
                popupMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("MENU VISIBLE 2" + popupMenu.gameObject.activeSelf);
            }

        }                       

    }


    public void ResumeGame() {
        popupMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReurnMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 0;
    }

    public void PlayUfo() {
        SceneManager.LoadScene("Ufo");
        
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
