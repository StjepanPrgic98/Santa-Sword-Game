using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] int level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bat")
        {
            Bat bat = collision.GetComponent<Bat>();

            if(level <= bat.GetLevel()) 
            {
                ReduceNumberOfPresents();
                Destroy(gameObject);         
            }
        }
    }


    public int GetLevel()
    {
        return level;
    }

    void ReduceNumberOfPresents()
    {
        FindObjectOfType<PresentField>().ReducePresents();
    }
}
