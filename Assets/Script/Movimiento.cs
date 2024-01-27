using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movimiento : MonoBehaviour
{
    public float Speed = 3f;
    private Rigidbody2D rb;
    private float horizontal;
    public float fuerzaSalto = 20f;
    public LayerMask layerSuelo;
    private bool puedoSaltar;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    { 
       horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        
        salto();
    }


    void salto()
    {

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            Vector2 salto = Vector2.up * fuerzaSalto;
            rb.AddForce(salto, ForceMode2D.Impulse);
        }

        puedoSaltar = Physics2D.Raycast(transform.position, Vector2.down, 2000f, layerSuelo);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector2.down);
    }
}
