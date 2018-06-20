using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : MonoBehaviour {
    public GameObject crateFrag;
	
    private void CreateFragment(Vector2 pos)
    {
        Vector2 posnew = pos;
        posnew.x -= 0.3f;
        GameObject f1 = Instantiate(crateFrag, posnew, Quaternion.identity);
        posnew = pos;
        posnew.x += 0.3f;
        GameObject f2 = Instantiate(crateFrag, posnew, Quaternion.identity);
        FragmentCtrl fc = f2.GetComponent<FragmentCtrl>();
        fc.JumpForce.x *= -1;

        posnew = pos;
        posnew.x -= 0.3f;
        posnew.y += 0.3f;
        GameObject f3 = Instantiate(crateFrag, posnew, Quaternion.identity);
        posnew = pos;
        posnew.x += 0.3f;
        posnew.y += 0.3f;
        GameObject f4 = Instantiate(crateFrag, posnew, Quaternion.identity);
        fc = f4.GetComponent<FragmentCtrl>();
        fc.JumpForce.x *= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Breakable"))
        {
            CreateFragment(collision.gameObject.transform.position);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
