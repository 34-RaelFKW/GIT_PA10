using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody RB;


    public GameManager GM;

    public float jumpSpeed;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 3.5f)
        {
            thisAnimation.Play();
            RB.AddForce(transform.up * jumpSpeed);
            //transform.position += transform.up * jumpSpeed * Time.deltaTime;
        }

        if (transform.position.y <= -4)
        {
            GM.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            GM.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            GM.UpdateScore(1);
        }
    }
}
