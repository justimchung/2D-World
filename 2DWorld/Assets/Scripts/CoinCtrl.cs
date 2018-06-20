using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour {
    public GameObject CoinPickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(CoinPickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
