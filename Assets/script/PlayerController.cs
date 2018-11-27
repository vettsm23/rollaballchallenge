using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
            }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetAllText();
        }
    }

    private void SetAllText()
    {
        throw new NotImplementedException();
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count>12)
        {
            winText.text = "You won the game with a score of " + count.ToString();
        }
    }
}
