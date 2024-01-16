using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumy : MonoBehaviour
{
    private float _speed = 2.5f;
    public Transform Ray;
    private bool _moveEnemyLeft=true;



    public float heather = 5f;

    
    void Update()
    {
        _moveEnumy();
        
    }
    private void _moveEnumy()
    {
        transform.Translate(Vector2.left*_speed*Time.deltaTime);

        RaycastHit2D rayinfo = Physics2D.Raycast(Ray.position, Vector2.down, 1f);

        if(rayinfo.collider==false)
        {
            if (_moveEnemyLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                _moveEnemyLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveEnemyLeft = true;
            }
        }
       
    }
    
}
