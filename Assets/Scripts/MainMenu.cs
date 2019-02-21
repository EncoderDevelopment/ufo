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
    private Fade effectFade;


    private void Start()
    {

        if (!SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            popupMenu.gameObject.SetActive(false);
            GameObject ReturnGame = GameObject.Find("ReturnGame");
            if (ReturnGame)
                EventSystem.current.SetSelectedGameObject(ReturnGame);            
        }

        effectFade = new Fade();
        effectFade.Start();
        RemoveLayerFade();
      
    }


    public void RemoveLayerFade()
    {
        StartCoroutine(WaitLayerRemove());
    }

    public IEnumerator WaitLayerRemove()
    {
        yield return new WaitForSeconds(2);
        effectFade.effectsFade.SetActive(false);

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
        Debug.Log("RETURN");
        effectFade.effectsFade.SetActive(true);
        effectFade.FadeOutToScene();
        effectFade.FadeInToScene();
        effectFade.effectsFade.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void PlayUfo() {

        effectFade.effectsFade.SetActive(true);
        effectFade.FadeOutToScene();
        WaitLayerRemove();
        SceneManager.LoadScene("Ufo");
        Time.timeScale = 1;
    }

    public void PlayLabirinto()
    {
        effectFade.effectsFade.SetActive(true);
        effectFade.FadeOutToScene();        
        SceneManager.LoadScene("Labirinto");
        Time.timeScale = 1;

    }
   

    public void QuitGame()
    {
        effectFade.FadeOutToScene();
        Debug.Log("QUIT");
        Application.Quit();

    }

   

}
