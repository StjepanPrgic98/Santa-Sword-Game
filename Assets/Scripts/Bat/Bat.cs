using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            Destroy(gameObject);
            FindObjectOfType<PresentField>().ReducePresents();
        }
    }
}
