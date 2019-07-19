using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollCtrl : MonoBehaviour
{
    public float a = 0.2f;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            coll.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, a);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            coll.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1.0f);
        }
    }
}
