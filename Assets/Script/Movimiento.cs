using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movimiento : MonoBehaviour
{
    public float Speed = 3f;
    private Rigidbody2D rb;
    public float horizontal;
    public float vertical;
    public float fuerzaSalto = 20f;
    public LayerMask layerSuelo;
    private bool puedoSaltar;
    public Transform tf;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //transform.Translate2D(0, horizontal * Time.deltaTime * Speed,0);
        ////rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        //animator.SetFloat("VelocidadX", horizontal);

        //horizontal = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        //if (Input.GetKey(KeyCode.D))
        //{
        //    animator.SetBool("Run", true);        
        //}
        //else
        //{
        //    animator.SetBool("Run", false);
        //}
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(horizontal * Time.deltaTime * Speed, 0,0 );

        animator.SetFloat("VelocidadX", horizontal);
        animator.SetFloat("VelocidadY", vertical);

        if(horizontal >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }

    }


    private void Update()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            print("Salto y espacio");

            Vector2 directionForce = Vector2.up * fuerzaSalto;
            rb.AddForce(directionForce, ForceMode2D.Impulse);
        }


        //Puedo saltar
        puedoSaltar = Physics2D.Raycast(tf.position, Vector2.down, 3f, layerSuelo);

        //if (puedoSaltar)
        //{
        //    print("Puedo saltar");
        //}
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object  
        Gizmos.color = Color.red;
        Vector3 direction = tf.TransformDirection(Vector3.down) * 3;
        Gizmos.DrawRay(tf.position, direction);
    }
  
}
