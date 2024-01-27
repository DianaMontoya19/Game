using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject cameraB, cameraA;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        cameraB.SetActive(false);
        if (other.CompareTag("Player"))
        {
            cameraA.SetActive(false);
            cameraB.SetActive(false);
        }
    }
}
