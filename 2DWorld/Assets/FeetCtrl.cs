using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {
    public GameObject DustPrefab;
    public Transform DustPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("T");
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Trigger");
            Instantiate(DustPrefab, DustPos.position, Quaternion.identity);
        }
    }

}
