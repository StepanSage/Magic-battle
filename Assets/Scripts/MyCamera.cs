using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private float SpeedCamera=3f;
    public Transform target; 
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);//полжение камеры.
    }

    
    void LateUpdate()
    {
        Vector3 postion = target.position;//позиция объекта слежки 
        postion.z=transform.position.z;//положение игрока по позицции зет 
        transform.position = Vector3.Lerp(transform.position, postion, SpeedCamera * Time.deltaTime);//передвижене камеры.
    }
}
