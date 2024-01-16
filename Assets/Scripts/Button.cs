using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Button : MonoBehaviour
{


    public float speed;
    public float destoytime;//время уничтожения 
    public float damag= 1;//урон 
    public float RadiusRay = 0.1f;//длина луча 
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

       


            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, RadiusRay, ObjectMask);// создает луч

            if (hitinfo.collider != null)//если луч попадает в коллайдер
            {
                if (hitinfo.collider.CompareTag("Enemy"))//если луч попадает в коллайдер с тегом 
                {
                    hitinfo.collider.GetComponent<Statistics>().TakeDamag(damag);// ненесениие урона
                    Destroy(gameObject);
                }
                Destroy(gameObject);
            }
            transform.Translate(Vector2.up * speed * Time.deltaTime);//напровление пули полета пули 
        
    }

   

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
