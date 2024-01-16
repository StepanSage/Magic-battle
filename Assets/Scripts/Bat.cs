using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Transform[] point;
   
    public float speed = 5f;


    void Start()
    {
        gameObject.transform.position=new Vector3(point[0].position.x, point[0].position.y, transform.position.z);
    }

   
    void Update()
    {
        _moveBat();
    }


    void _moveBat()
    {
        transform.position = Vector3.MoveTowards(transform.position, point[0].position, speed * Time.deltaTime);

        if (transform.position == point[0].position)
        {
            Transform tepm = point[0];
            point[0] = point[1];
            point[1]= tepm;
        }
    }
}
