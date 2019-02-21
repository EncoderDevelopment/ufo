using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SplashGameController : MonoBehaviour
{
    private Fade effectFade;
    
    void Start()
    {
        effectFade = new Fade();
        effectFade.Start();
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(5);
        effectFade.FadeOutToScene();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
        
    }

    
}
