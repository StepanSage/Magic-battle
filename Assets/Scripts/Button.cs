using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Button : MonoBehaviour
{


    public float speed;
    public float destoytime;//����� ����������� 
    public float damag= 1;//���� 
    public float RadiusRay = 0.1f;//����� ���� 
    public LayerMask ObjectMask;
    
    
   

    private void Start()
    {
        Invoke("DestroyAmmo", destoytime);
    }



    void Update()
    {
        InfoDamag();



    }

    public void InfoDamag()
    {

       


            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, RadiusRay, ObjectMask);// ������� ���

            if (hitinfo.collider != null)//���� ��� �������� � ���������
            {
                if (hitinfo.collider.CompareTag("Enemy"))//���� ��� �������� � ��������� � ����� 
                {
                    hitinfo.collider.GetComponent<Statistics>().TakeDamag(damag);// ���������� �����
                    Destroy(gameObject);
                }
                Destroy(gameObject);
            }
            transform.Translate(Vector2.up * speed * Time.deltaTime);//����������� ���� ������ ���� 
        
    }

   

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
