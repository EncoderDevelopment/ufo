using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerLabirinto : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    public Text countText;
    public Text winText;    
    public float targetTime;
    public bool endGame;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targetTime = 90.0f;
        SetTimeTextLabirinto();
        winText.text = "";
        endGame = false;

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Fim"))
        {
            Debug.Log("COLLIDER");
            other.gameObject.SetActive(false);
            endGame = true;
            StartCoroutine(LoadMenu());
        }
    }
              
    void SetTimeTextLabirinto()
    {
        if (!endGame)
        {
            targetTime -= Time.deltaTime;
            countText.text = targetTime.ToString();
        }
        else {
            Debug.Log("WIN");
            winText.text = "VENCEU!";
            countText.text = targetTime.ToString();
        }

        if (targetTime <= 0.0f)
        {
            countText.text = "0.0000".ToString();
            winText.text = "PERDEU!";
            StartCoroutine(LoadMenu());
        }
    }
    
    void LateUpdate()
    {
        SetTimeTextLabirinto();
    }


    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
