using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyTrap : MonoBehaviour
{

    [SerializeField]private float speed;
    bool isWait=false;
    bool isHidder = false;
    [SerializeField] Transform point;
    [SerializeField] float WaitTime;

    void Start()
    {
        point.transform.position = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
    }

    
    void Update()
    {
        if(isWait==false)
        {
            transform.position= Vector3.MoveTowards(transform.position,point.position,speed*Time.deltaTime);
        }
        if(transform.position==point.position)
        { 
            if(isHidder)
            {
                point.transform.position=new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
                isHidder= false;
            }else
            {
                point.transform.position=new Vector3(transform.position.x,transform.position.y-1f, transform.position.z);
                isHidder= true;
                
            }
            isWait=true;
            StartCoroutine(Waiting());
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(WaitTime);
            isWait=false;

        }
    }
}
