using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerUfo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    public Text countText;
    public Text winText;
    private int count;
    private Fade effectFade;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountTextUfo();
        winText.text = "";

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
        yield return new WaitForSeconds(1);
        effectFade.effectsFade.SetActive(false);
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
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountTextUfo();
        }

    }

    void EndGameLabirinto()
    {
        winText.text = "VENCEU!";
        StartCoroutine(LoadMenu());
    }


    void SetCountTextUfo()
    {
        countText.text = "Itens " + count.ToString();
        if (count >= 12)
        {
            winText.text = "VENCEU!";
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(5);
        effectFade.FadeOutToScene();
        SceneManager.LoadScene("Menu");
    }
}
