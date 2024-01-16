using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
 

    public float offset=-90f;
    public GameObject bullet;
    public Transform shotpoint;


    private float shot;
    public float start;//����� ����� ����������

    public int Ammo = 7; //����������� ����


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
       



        //����� ����
        if(shot<=0 && Ammo>0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotpoint.position, transform.rotation);
                Ammo--;
                shot=start;

            }
        }else
        {
            shot-=Time.deltaTime;
        }
       
    }
}
