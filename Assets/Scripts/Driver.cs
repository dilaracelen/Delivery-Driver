using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300;
    [SerializeField] float moveSpeed = 20;
    [SerializeField] float slowSpeed = 15;
    [SerializeField] float boostSpeed = 30;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 

        transform.Rotate(0, 0, -steerAmount); // z ekseninde d�nmesi i�in. (x,y,z)
        transform.Translate(0, moveAmount, 0); // verilen analatik d�zlemde ilerlemesini sa�lar.
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
            moveSpeed = boostSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
