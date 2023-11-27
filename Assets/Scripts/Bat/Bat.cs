using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] int level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            Present present = collision.GetComponent<Present>();

            if(level <= present.GetLevel()) { Destroy(gameObject); }
        }

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public int GetLevel()
    {
        return level;
    }
}
