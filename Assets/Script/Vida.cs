using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image[] imagen;
    private float vidaMaxima = 100;

    int conta = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        
          

      if (other.gameObject.CompareTag("Bloque"))
      {
           

            imagen[conta].fillAmount = 0;
            conta++;

            //Debug.Log("contador" + conta);


            //for (int i = 0; i > 4; i++)
            //{
            ////  imagen[conta].fillAmount = 0;
            ////     Debug.Log("Choco");
            //    Debug.Log("contador" + i);
            //   i++;
            //}


        }
            
        
    }
}
