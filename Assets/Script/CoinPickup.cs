using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private bool playerCome;
    
    private void Update()
    {
        if (playerCome)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 1.5f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerCome = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCome = false;
        }
    }
}
