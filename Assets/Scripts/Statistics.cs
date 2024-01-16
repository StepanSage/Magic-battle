using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public float Heather;
   

    
    void Update()
    {
        _destroyDeadEnemy();
    }

    public void TakeDamag(float damag)
    {
        Heather -= damag;
    }
    public void _destroyDeadEnemy()
        {
            if (Heather <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
   
