using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    public Text countText;          
    public Text winText;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
       
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
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Itens " + count.ToString();
        if (count >= 2)
            //... then set the text property of our winText object to "You win!"
            winText.text = "VENCEU!";
        StartCoroutine(Example());
    }


    IEnumerator Example()
    {

        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");

    }
}
